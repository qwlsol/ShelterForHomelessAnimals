using ShelterApp.Models;

namespace ShelterApp.ViewModels
{
    public class NewsDetailsViewModel
    {
        public News News { get; set; } = null!;
        public Animal? RelatedAnimal { get; set; }
    }
}
