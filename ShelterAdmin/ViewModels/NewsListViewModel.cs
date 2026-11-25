using ShelterAdmin.Services;
using ShelterApp.Models;

namespace ShelterAdmin.ViewModels;

public class NewsListViewModel
{
    public List<News> NewsList { get; set; } = new();
    public News? SelectedNews { get; set; }
    public string? ErrorMessage { get; set; }

    public void LoadNews(NewsService service)
    {
        try
        {
            NewsList = service.GetAll();
            ErrorMessage = null;
        }
        catch (Exception)
        {
            NewsList.Clear();
            ErrorMessage = "Не удалось загрузить новости. Проверьте подключение к БД.";
        }
    }

    public void DeleteSelectedNews(NewsService service)
    {
        if (SelectedNews == null) return;

        try
        {
            service.Delete(SelectedNews.Id);
            NewsList.Remove(SelectedNews);
            ErrorMessage = null;
        }
        catch (Exception)
        {
            ErrorMessage = "Не удалось удалить новость. Проверьте подключение к БД.";
        }
    }
}