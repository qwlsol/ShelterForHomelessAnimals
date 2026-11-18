using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterApp.Repositories;

public class NewsPgRepository : INewsRepository
{
    private readonly ShelterContext _context;

    public NewsPgRepository(ShelterContext context) => _context = context;

    public List<News> GetAll()
    {
        return _context.News
            .OrderByDescending(n => n.PublishedAt)
            .ToList();
    }

    public News? GetById(int id)
    {
        return _context.News.FirstOrDefault(n => n.Id == id);
    }
}