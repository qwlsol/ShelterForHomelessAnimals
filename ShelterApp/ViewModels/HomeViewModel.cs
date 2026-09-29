using ShelterApp.Models;

namespace ShelterApp.ViewModels;

public class HomeViewModel
{
    public List<Animal> Animals { get; set; } = new();
}