using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterApp.Tests.Integration;

[TestClass]
public class AdminNewsIntegrationTests
{
    // Тест 1. Добавление и чтение. Создаём новость через Save с реальным сервисом, затем через LoadNews проверяем.
    [TestMethod]
    public void AddAndRead_News_InDatabase()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);
        var service = new NewsService(context);

        var editVm = new NewsEditViewModel { Title = "Новость 1", Content = "Текст 1" };

        editVm.Save(service); // Добавляем

        var listVm = new NewsListViewModel();
        listVm.LoadNews(service); // Читаем

        Assert.AreEqual(1, listVm.NewsList.Count);
        Assert.AreEqual("Новость 1", listVm.NewsList[0].Title);
    }

    // Тест 2. Удаление.
    [TestMethod]
    public void Delete_News_RemovesFromDatabase()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);
        var service = new NewsService(context);

        var news = new News { Title = "Для удаления" };
        context.News.Add(news);
        context.SaveChanges();

        var listVm = new NewsListViewModel();
        listVm.LoadNews(service);
        listVm.SelectedNews = listVm.NewsList[0];

        listVm.DeleteSelectedNews(service);

       
        Assert.AreEqual(0, context.News.Count());
        Assert.AreEqual(0, listVm.NewsList.Count);
    }
}