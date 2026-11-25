using ShelterAdmin.Services;
using ShelterApp.Models;

namespace ShelterAdmin.ViewModels;

public class NewsEditViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public string? DetailedContent { get; set; }
    public string? ImagePath { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.Now;
    public int? AnimalId { get; set; }
    public string? ErrorMessage { get; set; }

    public bool Save(INewsService service)
    {
        try
        {
            var news = new News
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content,
                DetailedContent = this.DetailedContent,
                ImagePath = this.ImagePath,

                PublishedAt = DateTime.SpecifyKind(this.PublishedAt, DateTimeKind.Unspecified),

                AnimalId = this.AnimalId
            };

            if (Id == 0)
                service.Add(news);
            else
                service.Update(news);

            return true;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Ошибка: {ex.InnerException?.Message ?? ex.Message}";
            return false;
        }
    }
}