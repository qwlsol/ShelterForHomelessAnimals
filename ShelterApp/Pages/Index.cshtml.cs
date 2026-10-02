using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Pages;

public class IndexModel : PageModel
{
    private readonly IAnimalRepository _repo;
    private readonly ILogger<IndexModel> _logger;

    public HomeViewModel ViewModel { get; private set; } = new();

    public string? ErrorMessage { get; private set; }

    public IndexModel(IAnimalRepository repo, ILogger<IndexModel> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public void OnGet()
    {
        try
        {
            ViewModel = new HomeViewModel
            {
                Animals = _repo.GetAvailableAnimals()
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка загрузки главной страницы");
            ErrorMessage = $"Ошибка: {ex.Message}";
        }
    }
}