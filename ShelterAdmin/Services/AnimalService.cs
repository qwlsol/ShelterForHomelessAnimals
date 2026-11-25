using Microsoft.EntityFrameworkCore;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterAdmin.Services;

public class AnimalService
{
    private readonly ShelterContext _context;

    public AnimalService(ShelterContext context)
    {
        _context = context;
    }

    public List<Animal> GetAllAnimalsForAdmin()
    {
        return _context.Animals
            .OrderByDescending(a => a.ArrivalDate)
            .ToList();
    }
}