using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterApp.Models;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Pages.Animals;

public class DetailsModel : PageModel
{
    private readonly IAnimalRepository _repo;

    public Animal? Animal { get; private set; }
    public SimilarAnimalsViewModel SimilarViewModel { get; private set; } = new();
    public string? SuccessMessage { get; private set; }


    public DetailsModel(IAnimalRepository repo) => _repo = repo;

    public IActionResult OnGet(int id)
    {
        Animal = _repo.GetAnimalById(id);
        if (Animal == null) return Page();

        var similar = _repo.GetSimilarAnimals(id, 6);

        SimilarViewModel = new SimilarAnimalsViewModel
        {
            CurrentAnimalId = id,
            SimilarAnimals = similar
        };

        return Page();
    }

    public IActionResult OnPostApply(int id)
    {
        Animal = _repo.GetAnimalById(id);
        if (Animal == null) return NotFound();

        if (!ModelState.IsValid) return Page();

        
        return Page();
    }

    
}