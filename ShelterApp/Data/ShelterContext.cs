using Microsoft.EntityFrameworkCore;
using ShelterApp.Models;

namespace ShelterApp.Data;

public class ShelterContext : DbContext
{
    public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) { }

    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Photo> Photos => Set<Photo>();
    public DbSet<Adopter> Adopters => Set<Adopter>();
    public DbSet<Application> Applications => Set<Application>();
}