using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterAdmin.Services;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class AdminLogicTests
{
    //проверка загрузки животных (включая пристроенных)
    [TestMethod]
    public void GetAllAnimalsForAdmin_ReturnsAllAnimals_IncludingAdopted()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Status = 0 },
            new Animal { Id = 2, Name = "Мурка", Status = 2 } //пристроена
        );
        context.SaveChanges();

        var service = new AnimalService(context);

        var result = service.GetAllAnimalsForAdmin();

        Assert.AreEqual(2, result.Count, "Админ должен видеть всех животных");
    }

    //проверка сортировки по дате
    [TestMethod]
    public void GetAllAnimalsForAdmin_SortsByArrivalDateDescending()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Старый", ArrivalDate = DateTime.Now.AddDays(-10) },
            new Animal { Id = 2, Name = "Новый", ArrivalDate = DateTime.Now.AddDays(-1) }
        );
        context.SaveChanges();

        var service = new AnimalService(context);

        var result = service.GetAllAnimalsForAdmin();

        Assert.AreEqual("Новый", result[0].Name);
    }
}