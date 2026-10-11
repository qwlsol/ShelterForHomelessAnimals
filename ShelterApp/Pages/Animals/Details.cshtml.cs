using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterApp.Models;
using ShelterApp.Repositories;

namespace ShelterApp.Pages.Animals;

public class DetailsModel : PageModel
{
    private readonly IAnimalRepository _repo;

    public Animal? Animal { get; private set; }
    public string? SuccessMessage { get; private set; }


    public DetailsModel(IAnimalRepository repo) => _repo = repo;

    public IActionResult OnGet(int id)
    {
        Animal = _repo.GetAnimalById(id);
        if (Animal == null) return Page();
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