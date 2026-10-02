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

/// Интеграционные тесты: главная страница + EF Core (InMemory)
public class IndexIntegrationTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;

    public IndexIntegrationTests()
    {
        var dbName = "TestDb_" + Guid.NewGuid();

        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    //Снимаем ВСЕ регистрации ShelterContext
                    services.RemoveAll<ShelterContext>();
                    services.RemoveAll<DbContextOptions<ShelterContext>>();
                    services.RemoveAll<DbContextOptions>();
                    services.RemoveAll(typeof(DbContextOptions<>));
                    services.RemoveAll(typeof(IDbContextOptionsConfiguration<>));
                    services.RemoveAll(typeof(IDbContextFactory<>));

                    //Снимаем внутренние EF-сервисы и Npgsql-сервисы
                    var efAndNpgsql = services
                        .Where(d =>
                            d.ServiceType == typeof(IDatabaseProvider) ||
                            d.ServiceType.FullName?.StartsWith("Npgsql") == true ||
                            d.ServiceType.FullName?.StartsWith("Microsoft.EntityFrameworkCore") == true ||
                            d.ServiceType.FullName?.StartsWith("Microsoft.Extensions.DependencyInjection.IDbContextOptionsConfiguration") == true)
                        .ToList();

                    foreach (var d in efAndNpgsql)
                        services.Remove(d);

                    //Изолированный провайдер ТОЛЬКО для InMemory
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

    private async Task SeedAsync(Action<ShelterContext> seed)
    {
        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<ShelterContext>();
        seed(ctx);
        await ctx.SaveChangesAsync();
    }

    // Интеграционный тест 1. Список животных загружается из базы данных
    [Fact]
    public async Task Index_LoadsAnimals_FromDatabase()
    {
        await SeedAsync(ctx =>
        {
            ctx.Animals.AddRange(
                new Animal { Name = "Барсик", Species = 1, Breed = "метис", Gender = 0, Age = 12, Size = 0, Status = 0 },
                new Animal { Name = "Мурка", Species = 1, Breed = "британская", Gender = 1, Age = 24, Size = 0, Status = 0 }
            );
        });
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/");
        var html = WebUtility.HtmlDecode(await response.Content.ReadAsStringAsync());

        response.IsSuccessStatusCode.Should().BeTrue();
        html.Should().Contain("Барсик");
        html.Should().Contain("Мурка");
    }

    // Интеграционный тест 2. Карточки формируются на основе данных из таблицы animals
    [Fact]
    public async Task Index_CardsAreBuilt_FromAnimalsTable()
    {
        await SeedAsync(ctx =>
        {
            ctx.Animals.Add(new Animal
            {
                Name = "Рекс",
                Species = 0,           // собака
                Breed = "овчарка",
                Gender = 0,            // мальчик
                Age = 36,              // 3 года
                Size = 2,              // крупный
                Status = 0
            });
        });
        var client = _factory.CreateClient();

        var html = WebUtility.HtmlDecode(await client.GetStringAsync("/"));

        //все поля карточки на странице
        html.Should().Contain("Рекс");
        html.Should().Contain("Собака");
        html.Should().Contain("овчарка");
        html.Should().Contain("Мальчик");
        html.Should().Contain("3 г. 0 мес.");
        html.Should().Contain("Крупный");
    }

    // Интеграционный тест 3. Фотографии подгружаются из таблицы photos
    [Fact]
    public async Task Index_LoadsPhotos_FromPhotosTable()
    {
        await SeedAsync(ctx =>
        {
            var animal = new Animal
            {
                Name = "Тимоша",
                Species = 1,
                Breed = "метис",
                Gender = 0,
                Age = 6,
                Size = 0,
                Status = 0
            };
            ctx.Animals.Add(animal);
            ctx.SaveChanges();

            ctx.Photos.Add(new Photo
            {
                AnimalId = animal.Id,
                FilePath = "/images/timosha.jpg",
                IsMain = true
            });
        });
        var client = _factory.CreateClient();

        var html = WebUtility.HtmlDecode(await client.GetStringAsync("/"));

        html.Should().Contain("/images/timosha.jpg",
            "главное фото должно попасть в HTML карточки");
    }

    // Интеграционный тест 4. Животные со статусом «пристроен» не отображаются в списке карточек.
    [Fact]
    public async Task Index_DoesNotShow_AdoptedAnimals()
    {
        await SeedAsync(ctx =>
        {
            ctx.Animals.AddRange(
                new Animal { Name = "Доступный", Species = 0, Breed = "метис", Gender = 0, Age = 12, Size = 1, Status = 0 },
                new Animal { Name = "Пристроен", Species = 0, Breed = "овчарка", Gender = 0, Age = 24, Size = 1, Status = 2 }
            );
        });
        var client = _factory.CreateClient();

        var html = WebUtility.HtmlDecode(await client.GetStringAsync("/"));

        html.Should().Contain("Доступный");
        html.Should().NotContain("Пристроен",
            "животные со статусом 2 (пристроен) не должны попадать в список");
    }

    // Интеграционный тест 5. Открытие главной страницы без авторизации
    [Fact]
    public async Task Index_IsAccessible_WithoutAuth()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/");

        response.StatusCode.Should().Be(HttpStatusCode.OK,
            "страница должна открываться без авторизации");
    }
}