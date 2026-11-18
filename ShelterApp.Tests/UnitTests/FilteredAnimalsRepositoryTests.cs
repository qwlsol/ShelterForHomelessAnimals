using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class FilteredAnimalsRepositoryTests
{
    //фильтрация по виду
    [TestMethod]
    public void GetFilteredAnimals_BySpecies_ReturnsOnlyCats()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0 },
            new Animal { Id = 2, Name = "Шарик", Species = 0, Status = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { Species = 1 };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Барсик", result[0].Name);
    }

    //фильтрация по полу
    [TestMethod]
    public void GetFilteredAnimals_ByGender_ReturnsOnlyGirls()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Мурка", Species = 1, Gender = 1, Status = 0 },
            new Animal { Id = 2, Name = "Барсик", Species = 1, Gender = 0, Status = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { Gender = 1 };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Мурка", result[0].Name);
    }

    //фильтрация по размеру
    [TestMethod]
    public void GetFilteredAnimals_BySize_ReturnsOnlySmall()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Малыш", Species = 1, Size = 0, Status = 0 },
            new Animal { Id = 2, Name = "Гигант", Species = 1, Size = 2, Status = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { Size = 0 };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Малыш", result[0].Name);
    }

    //фильтрация по возрасту (диапазон)
    [TestMethod]
    public void GetFilteredAnimals_ByAgeRange_ReturnsAnimalsInRange()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Котенок", Species = 1, Age = 6, Status = 0 },
            new Animal { Id = 2, Name = "Взрослый", Species = 1, Age = 18, Status = 0 },
            new Animal { Id = 3, Name = "Старый", Species = 1, Age = 30, Status = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { AgeFrom = 12, AgeTo = 24 };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Взрослый", result[0].Name);
    }

    //комбинированные фильтры
    [TestMethod]
    public void GetFilteredAnimals_WithMultipleFilters_ReturnsCorrectSelection()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Идеал", Species = 1, Gender = 1, Size = 0, Status = 0 },
            new Animal { Id = 2, Name = "Не тот вид", Species = 0, Gender = 1, Size = 0, Status = 0 },
            new Animal { Id = 3, Name = "Не тот пол", Species = 1, Gender = 0, Size = 0, Status = 0 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { Species = 1, Gender = 1, Size = 0 };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Идеал", result[0].Name);
    }

    //пустой результат
    [TestMethod]
    public void GetFilteredAnimals_WhenNoMatch_ReturnsEmptyList()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.Add(new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0 });
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { SearchQuery = "НесуществующаяКличка" };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(0, result.Count);
    }

    //исключение пристроенных
    [TestMethod]
    public void GetFilteredAnimals_ExcludesAdopted()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Свободен", Species = 1, Status = 0 },
            new Animal { Id = 2, Name = "Пристроен", Species = 1, Status = 2 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        var filter = new AnimalFilterViewModel { Species = 1 };
        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Свободен", result[0].Name);
    }
}