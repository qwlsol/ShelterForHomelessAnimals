using Microsoft.EntityFrameworkCore;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterApp.Repositories;

public class AnimalPgRepository : IAnimalRepository
{
    private readonly ShelterContext _context;

    public AnimalPgRepository(ShelterContext context) => _context = context;

    public List<Animal> GetAvailableAnimals()
    {
        return _context.Animals
            .Include(a => a.Photos)
            .Where(a => a.Status != 2)
            .OrderByDescending(a => a.ArrivalDate)
            .ToList();
    }
}