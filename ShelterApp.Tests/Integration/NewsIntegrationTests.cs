using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.Integration;

[TestClass]
public class NewsIntegrationTests
{
    // Тест 1. Загрузка списка из БД
    [TestMethod]
    public void GetAll_LoadsFromDatabase()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.AddRange(
            new News { Title = "Новость 1", Content = "Текст 1", PublishedAt = DateTime.Now },
            new News { Title = "Новость 2", Content = "Текст 2", PublishedAt = DateTime.Now }
        );
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetAll();

        Assert.AreEqual(2, result.Count);
    }

    // Тест 2. Сортировка новостей
    [TestMethod]
    public void GetAll_ReturnsNewsInDescendingOrder()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.AddRange(
            new News { Title = "Старая", PublishedAt = DateTime.Now.AddDays(-5) },
            new News { Title = "Новая", PublishedAt = DateTime.Now }
        );
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetAll();

        Assert.AreEqual("Новая", result[0].Title);
        Assert.AreEqual("Старая", result[1].Title);
    }

    // Тест 3. Отображение текста новости
    [TestMethod]
    public void GetById_ReturnsCorrectNewsData()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.Add(new News
        {
            Id = 5,
            Title = "Заголовок",
            Content = "Полный текст",
            PublishedAt = new DateTime(2026, 10, 10)
        });
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetById(5);

        Assert.IsNotNull(result);
        Assert.AreEqual("Заголовок", result.Title);
        Assert.AreEqual("Полный текст", result.Content);
        Assert.AreEqual(new DateTime(2026, 10, 10), result.PublishedAt);
    }

    // Тест 4. Связь новости с животным
    [TestMethod]
    public void GetById_ReturnsAnimalId_WhenLinked()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.Add(new News { Id = 1, Title = "Связанная", AnimalId = 5 });
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetById(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(5, result.AnimalId);
    }
}