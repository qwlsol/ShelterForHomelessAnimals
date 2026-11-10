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
    public Animal? GetAnimalById(int id)
    {
        return _context.Animals
            .Include(a => a.Photos)
            .FirstOrDefault(a => a.Id == id);
    }
    public List<Animal> GetSimilarAnimals(int currentAnimalId, int limit = 6)
    {
        var currentAnimal = _context.Animals
            .FirstOrDefault(a => a.Id == currentAnimalId);

        if (currentAnimal == null)
            return new List<Animal>();

        return _context.Animals
            .Include(a => a.Photos)
            .Where(a => a.Species == currentAnimal.Species
                     && a.Status != 2
                     && a.Id != currentAnimalId)
            .OrderByDescending(a => a.Age == currentAnimal.Age)
            .ThenByDescending(a => a.Gender == currentAnimal.Gender)
            .Take(limit)
            .ToList();
    }
}