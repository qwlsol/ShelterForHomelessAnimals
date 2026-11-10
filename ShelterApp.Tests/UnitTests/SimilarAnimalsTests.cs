using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class SimilarAnimalsTests
{
    // Тест 1. Фильтрация по виду животного
    [TestMethod]
    public void GetSimilarAnimals_ForCat_ReturnsOnlyCats()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 2, Name = "Мурка", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 1 },
            new Animal { Id = 3, Name = "Шарик", Species = 0, Status = 0, Age = 24, Size = 1, Gender = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var result = repo.GetSimilarAnimals(currentAnimalId: 1, limit: 6);

        foreach (var animal in result)
        {
            Assert.AreEqual(1, animal.Species, "В списке должны быть только кошки");
        }
        Assert.IsFalse(result.Any(a => a.Id == 3), "Собака не должна попасть в список");
    }

    // Тест 2. Исключение текущего животного
    [TestMethod]
    public void GetSimilarAnimals_ExcludesCurrentAnimal()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 2, Name = "Мурка", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 1 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var result = repo.GetSimilarAnimals(currentAnimalId: 1);

        Assert.IsFalse(result.Any(a => a.Id == 1), "Текущее животное не должно быть в списке");
        Assert.IsTrue(result.Any(a => a.Id == 2), "Мурка должна быть в списке");
    }

    // Тест 3. Исключение пристроенных
    [TestMethod]
    public void GetSimilarAnimals_ExcludesAdopted()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 2, Name = "Мурка", Species = 1, Status = 2, Age = 24, Size = 1, Gender = 1 },
            new Animal { Id = 3, Name = "Пушок", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var result = repo.GetSimilarAnimals(currentAnimalId: 1);

        Assert.IsFalse(result.Any(a => a.Id == 2), "Пристроенное животное не должно попасть в список");
        Assert.IsTrue(result.Any(a => a.Id == 3), "Пушок должен быть в списке");
    }

    // Тест 4. Ограничение по количеству
    [TestMethod]
    public void GetSimilarAnimals_ReturnsMaxSixRecords()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        for (int i = 1; i <= 10; i++)
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

        var result = repo.GetSimilarAnimals(currentAnimalId: 1, limit: 6);

        Assert.AreEqual(6, result.Count, "Должно вернуться ровно 6 записей");
    }

    // Тест 5. Сортировка по количеству совпадений (возраст, пол)
    [TestMethod]
    public void GetSimilarAnimals_SortsByMatchedAttributes()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 2, Name = "Совпадение", Species = 1, Status = 0, Age = 24, Size = 1, Gender = 0 },
            new Animal { Id = 3, Name = "Частично", Species = 1, Status = 0, Age = 24, Size = 0, Gender = 1 },
            new Animal { Id = 4, Name = "Нет", Species = 1, Status = 0, Age = 5, Size = 0, Gender = 1 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var result = repo.GetSimilarAnimals(currentAnimalId: 1);

        int index2 = result.FindIndex(a => a.Id == 2);
        int index3 = result.FindIndex(a => a.Id == 3);
        int index4 = result.FindIndex(a => a.Id == 4);

        Assert.IsTrue(index2 < index3, "Совпадение по возрасту+полу должно быть выше, чем только по возрасту");
        Assert.IsTrue(index3 < index4, "Совпадение по возрасту должно быть выше, чем без совпадений");
    }
}