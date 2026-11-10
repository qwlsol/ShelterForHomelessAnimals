using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterApp.Models;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Pages.Adoption;

public class CreateModel : PageModel
{
    private readonly IAnimalRepository _animals;
    private readonly IAdoptionRepository _adoptions;

    [BindProperty] public AdoptionFormViewModel Form { get; set; } = new();
    public string? SuccessMessage { get; set; }

    public CreateModel(IAnimalRepository animals, IAdoptionRepository adoptions)
    {
        _animals = animals;
        _adoptions = adoptions;
    }

    //открытие формы с подставленной кличкой и фото
    public IActionResult OnGet(int animalId)
    {
        var animal = _animals.GetAnimalById(animalId);
        if (animal == null) return NotFound();

        Form = new AdoptionFormViewModel
        {
            AnimalId = animal.Id,
            AnimalName = animal.Name,
            AnimalPhotoPath = animal.MainPhoto
        };
        return Page();
    }

    //приём данных формы
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            var animal = _animals.GetAnimalById(Form.AnimalId);
            Form.AnimalName = animal?.Name ?? "";
            Form.AnimalPhotoPath = animal?.MainPhoto;
            return Page();
        }

        var adopter = new Adopter
        {
            FullName = Form.FullName,
            Phone = Form.Phone,
            Email = Form.Email
        };

        var request = new AdoptionRequest
        {
            AnimalId = Form.AnimalId
        };

        _adoptions.AddAdoptionRequest(adopter, request);

        SuccessMessage = "Ваша заявка отправлена. Сотрудник приюта свяжется с вами.";
        ModelState.Clear();
        return Page();
    }
}