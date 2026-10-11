using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterApp.Repositories;

public class AdoptionPgRepository : IAdoptionRepository
{
    private readonly ShelterContext _context;
    public AdoptionPgRepository(ShelterContext context) => _context = context;

    public void AddAdoptionRequest(Adopter adopter, AdoptionRequest request)
    {
        _context.Adopters.Add(adopter);
        _context.SaveChanges(); 

        request.AdopterId = adopter.Id;
        request.ApplicationDate = DateTime.UtcNow;
        request.Status = 0; // «на рассмотрении»

        _context.AdoptionRequests.Add(request);
        _context.SaveChanges();
    }
}