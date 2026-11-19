using ShelterApp.Models;

namespace ShelterApp.ViewModels
{
    public class NewsListViewModel
    {
        public List<News> News { get; set; } = new();
        public string? ErrorMessage { get; set; }
    }
}
