using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ShelterApp.Data;
using ShelterApp.Models;
using System.Net;
using Xunit;

namespace ShelterApp.Tests.Integration;

public class AdoptionFormIntegrationTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;

    public AdoptionFormIntegrationTests()
    {
        var dbName = "AdoptionTestDb_" + Guid.NewGuid();

        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddRazorPages(options =>
                    {
                        options.Conventions.ConfigureFilter(
                            new Microsoft.AspNetCore.Mvc.IgnoreAntiforgeryTokenAttribute());
                    });

                    services.RemoveAll<ShelterContext>();
                    services.RemoveAll<DbContextOptions<ShelterContext>>();
                    services.RemoveAll<DbContextOptions>();
                    services.RemoveAll(typeof(DbContextOptions<>));
                    services.RemoveAll(typeof(IDbContextOptionsConfiguration<>));
                    services.RemoveAll(typeof(IDbContextFactory<>));

                    var efAndNpgsql = services
                        .Where(d =>
                            d.ServiceType == typeof(IDatabaseProvider) ||
                            d.ServiceType.FullName?.StartsWith("Npgsql") == true ||
                            d.ServiceType.FullName?.StartsWith("Microsoft.EntityFrameworkCore") == true)
                        .ToList();
                    foreach (var d in efAndNpgsql) services.Remove(d);

                    var inMemoryProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    services.AddDbContext<ShelterContext>(opt =>
                        opt.UseInMemoryDatabase(dbName)
                           .UseInternalServiceProvider(inMemoryProvider));
                });
            });
    }

    public void Dispose() => _factory.Dispose();

    private async Task<int> SeedAnimalAsync(string name = "Тимоша")
    {
        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<ShelterContext>();
        var animal = new Animal
        {
            Name = name,
            Species = 1,
            Breed = "метис",
            Gender = 0,
            Age = 6,
            Size = 0,
            Status = 0
        };
        ctx.Animals.Add(animal);
        ctx.Photos.Add(new Photo { Animal = animal, FilePath = "/images/timosha.jpg", IsMain = true });
        await ctx.SaveChangesAsync();
        return animal.Id;
    }

    // Интеграционный тест 1 открытие формы заявки
    [Fact]
    public async Task Create_Form_Opens_WithAnimalData()
    {
        var animalId = await SeedAnimalAsync("Тимоша");
        var client = _factory.CreateClient();

        var response = await client.GetAsync($"/Adoption/Create?animalId={animalId}");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        response.IsSuccessStatusCode.Should().BeTrue();
        html.Should().Contain("Тимоша");
        html.Should().Contain("/images/timosha.jpg");
    }

    // Интеграционный тест 2 сохранение усыновителя
    [Fact]
    public async Task Submit_Saves_Adopter()
    {
        var animalId = await SeedAnimalAsync();
        var client = _factory.CreateClient();

        var form = new Dictionary<string, string>
        {
            ["Form.AnimalId"] = animalId.ToString(),
            ["Form.AnimalName"] = "Тимоша",
            ["Form.AnimalPhotoPath"] = "/images/timosha.jpg",
            ["Form.FullName"] = "Иванова Мария",
            ["Form.Phone"] = "+7 900 000 00 00",
            ["Form.Email"] = "maria@mail.ru"
        };

        var response = await client.PostAsync("/Adoption/Create", new FormUrlEncodedContent(form));
        response.IsSuccessStatusCode.Should().BeTrue();

        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<ShelterContext>();
        var adopter = ctx.Adopters.FirstOrDefault(a => a.Phone == "+7 900 000 00 00");

        adopter.Should().NotBeNull();
        adopter!.FullName.Should().Be("Иванова Мария");
    }

    // Интеграционный тест 3 сохранение заявки
    [Fact]
    public async Task Submit_Saves_AdoptionRequest_WithStatusPending()
    {
        var animalId = await SeedAnimalAsync();
        var client = _factory.CreateClient();

        var form = new Dictionary<string, string>
        {
            ["Form.AnimalId"] = animalId.ToString(),
            ["Form.AnimalName"] = "Тимоша",
            ["Form.AnimalPhotoPath"] = "/images/timosha.jpg",
            ["Form.FullName"] = "Петров Иван",
            ["Form.Phone"] = "+7 911 111 11 11",
            ["Form.Email"] = ""
        };

        var response = await client.PostAsync("/Adoption/Create", new FormUrlEncodedContent(form));
        response.IsSuccessStatusCode.Should().BeTrue();

        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<ShelterContext>();
        var request = ctx.AdoptionRequests.FirstOrDefault(r => r.AnimalId == animalId);

        request.Should().NotBeNull();
        request!.Status.Should().Be(0); 
        request.AdopterId.Should().BeGreaterThan(0);
    }
}