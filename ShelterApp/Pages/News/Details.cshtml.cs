using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Pages.News
{
    public class DetailsModel : PageModel
    {
        private readonly INewsRepository _newsRepo;
        private readonly IAnimalRepository _animalRepo;
        public NewsDetailsViewModel ViewModel { get; set; } = new();

        public DetailsModel(INewsRepository newsRepo, IAnimalRepository animalRepo)
        {
            _newsRepo = newsRepo;
            _animalRepo = animalRepo;
        }

        public IActionResult OnGet(int id)
        {
            var news = _newsRepo.GetById(id);
            if (news == null) return NotFound();

            ViewModel.News = news;

            if (news.AnimalId.HasValue)
            {
                ViewModel.RelatedAnimal = _animalRepo.GetAnimalById(news.AnimalId.Value);
            }

            return Page();
        }
    }
}