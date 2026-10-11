using ShelterApp.Models;

namespace ShelterApp.Repositories;

public interface IAdoptionRepository
{
    void AddAdoptionRequest(Adopter adopter, AdoptionRequest request);
}