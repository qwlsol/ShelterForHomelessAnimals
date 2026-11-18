using ShelterApp.Models;

namespace ShelterApp.Repositories
{
    public interface INewsRepository
    {
        List<News> GetAll();
        News? GetById(int id);
    }
}
