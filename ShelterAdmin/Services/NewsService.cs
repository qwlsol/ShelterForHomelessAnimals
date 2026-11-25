using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterAdmin.Services;

public class NewsService : INewsService
{
    private ShelterContext _context; 

    public NewsService(ShelterContext context)
    {
        _context = context;
    }

    public List<News> GetAll()
    {
        return _context.News.OrderByDescending(n => n.PublishedAt).ToList();
    }

    public void Add(News news)
    {
        _context.News.Add(news);
        _context.SaveChanges();
    }

    public void Update(News news)
    {
        var existing = _context.News.Find(news.Id);
        if (existing != null)
        {
            existing.Title = news.Title;
            existing.Content = news.Content;
            existing.DetailedContent = news.DetailedContent;
            existing.ImagePath = news.ImagePath;
            existing.PublishedAt = news.PublishedAt;
            existing.AnimalId = news.AnimalId;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var news = _context.News.Find(id);
        if (news != null)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }
    }
}