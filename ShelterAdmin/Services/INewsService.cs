using ShelterApp.Models;

namespace ShelterAdmin.Services;

public interface INewsService
{
    List<News> GetAll();
    void Add(News news);
    void Update(News news);
    void Delete(int id);
}