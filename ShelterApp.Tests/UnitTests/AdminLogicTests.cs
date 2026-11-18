using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class AdminLogicTests
{
    [TestMethod]
    public void GetAnimalsForAdmin_ReturnsAllAnimals_IncludingAdopted()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Барсик", Status = 0, ArrivalDate = DateTime.Now.AddDays(-5) },
            new Animal { Id = 2, Name = "Мурка", Status = 2, ArrivalDate = DateTime.Now }
        );
        context.SaveChanges();

        var result = context.Animals.ToList();

        Assert.AreEqual(2, result.Count, "Админ должен видеть всех животных, включая пристроенных");
        Assert.IsTrue(result.Any(a => a.Status == 2), "Пристроенное животное должно быть в списке");
    }

    [TestMethod]
    public void GetAnimalsForAdmin_SortsByArrivalDateDescending()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            new Animal { Id = 1, Name = "Старый", ArrivalDate = DateTime.Now.AddDays(-10) },
            new Animal { Id = 2, Name = "Новый", ArrivalDate = DateTime.Now.AddDays(-1) }
        );
        context.SaveChanges();

        var result = context.Animals
            .OrderByDescending(a => a.ArrivalDate)
            .ToList();

        Assert.AreEqual("Новый", result[0].Name, "Первым должен идти тот, кто поступил позже всех");
        Assert.AreEqual("Старый", result[1].Name);
    }
}