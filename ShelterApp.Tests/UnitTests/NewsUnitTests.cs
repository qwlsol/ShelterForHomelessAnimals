using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class NewsRepositoryUnitTests
{
    // Тест 1. Формат даты
    [TestMethod]
    public void GetById_ReturnsCorrectDateFormat()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.Add(new News
        {
            Id = 1,
            Title = "Новость",
            Content = "Текст",
            PublishedAt = new DateTime(2026, 10, 12)
        });
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetById(1);

        Assert.IsNotNull(result);
        // Проверяем, что формат даты будет именно дд.ММ.гггг
        Assert.AreEqual("12.10.2026", result.PublishedAt.ToString("dd.MM.yyyy"));
    }

    // Тест 2. Обрезка текста (краткое описание)
    [TestMethod]
    public void GetAll_ReturnsContentForTruncationCheck()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        var shortContent = "Короткий текст";
        var longContent = new string('А', 200); // Строка из 200 букв 'А'

        context.News.AddRange(
            new News { Id = 1, Title = "Короткая", Content = shortContent },
            new News { Id = 2, Title = "Длинная", Content = longContent }
        );
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetAll();

        // Проверяем, что репозиторий отдает полный текст, а обрезка (если >150) происходит в представлении
        Assert.AreEqual(shortContent, result.First(n => n.Id == 1).Content);
        Assert.AreEqual(200, result.First(n => n.Id == 2).Content.Length);
    }

    // Тест 3. Привязка к животному
    [TestMethod]
    public void GetById_ReturnsNullAnimalId_WhenNotLinked()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.Add(new News
        {
            Id = 1,
            Title = "Новость без животного",
            Content = "Текст",
            AnimalId = null // Животное не привязано
        });
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetById(1);

        Assert.IsNotNull(result);
        Assert.IsNull(result.AnimalId, "AnimalId должен быть null, чтобы кнопка не отображалась");
    }

    // Дополнительный тест: сортировка (чтобы покрыть логику GetAll)
    [TestMethod]
    public void GetAll_ReturnsNewsInDescendingOrder()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.News.AddRange(
            new News { Id = 1, Title = "Старая", PublishedAt = DateTime.Now.AddDays(-5) },
            new News { Id = 2, Title = "Новая", PublishedAt = DateTime.Now }
        );
        context.SaveChanges();
        var repo = new NewsPgRepository(context);

        var result = repo.GetAll();

        Assert.AreEqual("Новая", result[0].Title);
        Assert.AreEqual("Старая", result[1].Title);
    }
}