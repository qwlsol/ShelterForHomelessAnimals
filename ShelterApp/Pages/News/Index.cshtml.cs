using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Pages.News
{
    public class IndexModel : PageModel
    {
        private readonly INewsRepository _repo;
        public NewsListViewModel ViewModel { get; set; } = new();

        public IndexModel(INewsRepository repo) => _repo = repo;

        public void OnGet()
        {
            try
            {
                ViewModel.News = _repo.GetAll();
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = $"Ошибка загрузки новостей: {ex.Message}";
            }
        }
    }
}