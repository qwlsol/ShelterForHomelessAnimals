using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.Integration;

[TestClass]
public class SimilarAnimalsIntegrationTests
{
    // Тест 9. Подбор похожих из БД
    [TestMethod]
    public void GetSimilarAnimals_FromDatabase_ReturnsOtherCatsOnly()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 2, Name = "Мурка", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 1 },
            new Animal { Id = 3, Name = "Пушок", Species = 1, Status = 0, Age = 12, Size = 0, Gender = 0 },
            new Animal { Id = 4, Name = "Пристроен", Species = 1, Status = 2, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 5, Name = "Шарик", Species = 0, Status = 0, Age = 24, Size = 1, Gender = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var result = repo.GetSimilarAnimals(currentAnimalId: 1);

        Assert.IsTrue(result.Any(a => a.Id == 2), "Мурка должна быть в списке");
        Assert.IsTrue(result.Any(a => a.Id == 3), "Пушок должен быть в списке");
        Assert.IsFalse(result.Any(a => a.Id == 1), "Текущее животное не должно быть в списке");
        Assert.IsFalse(result.Any(a => a.Id == 4), "Пристроенное животное не должно быть в списке");
        Assert.IsFalse(result.Any(a => a.Id == 5), "Собака не должна быть в списке");
    }

    // Тест 10. Ограничение выдачи в БД
    [TestMethod]
    public void GetSimilarAnimals_WithMoreThanSixInDb_ReturnsExactlySix()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        for (int i = 1; i <= 15; i++)
        {
            context.Animals.Add(new Animal
            {
                Id = i,
                Name = $"Кот{i}",
                Species = 1,
                Status = 0,
                Age = 24,
                Size = 1,
                Gender = 0
            });
        }
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var result = repo.GetSimilarAnimals(currentAnimalId: 1);

        Assert.AreEqual(6, result.Count, "Должно вернуться ровно 6 записей");
    }
}