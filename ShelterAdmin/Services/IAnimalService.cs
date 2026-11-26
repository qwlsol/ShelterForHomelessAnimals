using ShelterApp.Models;
using ShelterAdmin.ViewModels;

namespace ShelterAdmin.Services;

public interface IAnimalService
{
    List<Animal> GetAllAnimalsForAdmin();
    void AddAnimal(AnimalEditViewModel vm);
    void UpdateAnimal(AnimalEditViewModel vm);
    void DeleteAnimal(int id);
}
