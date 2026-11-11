using ShelterApp.Models;
using ShelterApp.ViewModels;

namespace ShelterApp.Repositories;

public interface IAnimalRepository
{
    List<Animal> GetAvailableAnimals();
    Animal? GetAnimalById(int id);
    List<Animal> GetSimilarAnimals(int currentAnimalId, int limit = 6);
    List<Animal> GetFilteredAnimals(AnimalFilterViewModel filter);
}