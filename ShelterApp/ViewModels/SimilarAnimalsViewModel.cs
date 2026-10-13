using ShelterApp.Models;

namespace ShelterApp.ViewModels;

public class SimilarAnimalsViewModel
{
    public List<Animal> SimilarAnimals { get; set; } = new();

    public int CurrentAnimalId { get; set; }
}