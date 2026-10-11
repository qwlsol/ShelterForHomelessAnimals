using Microsoft.EntityFrameworkCore;
using Npgsql;
using ShelterApp.Data;
using ShelterApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var dataSource = new NpgsqlDataSourceBuilder(connectionString)
{
    ConnectionStringBuilder = { ClientEncoding = "UTF8" }
}.Build();

builder.Services.AddDbContext<ShelterContext>(options =>
    options.UseNpgsql(dataSource));

builder.Services.AddScoped<IAnimalRepository, AnimalPgRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
public partial class Program { }