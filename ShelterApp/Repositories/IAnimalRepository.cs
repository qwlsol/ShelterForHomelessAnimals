using ShelterApp.Models;

namespace ShelterApp.Repositories;

public interface IAnimalRepository
{
    List<Animal> GetAvailableAnimals();
}