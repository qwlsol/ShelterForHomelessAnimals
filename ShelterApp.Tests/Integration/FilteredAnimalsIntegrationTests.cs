using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.Integration;

[TestClass]
public class FilteredAnimalsIntegrationTests
{
    //полный цикл фильтрации через БД, в результате должна пройти только одна кошка
    [TestMethod]
    public void GetFilteredAnimals_FullCycle_ReturnsExpectedCount()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.AddRange(
            //кошка, девочка, маленькая, 10 мес
            new Animal { Id = 1, Name = "Мурка", Species = 1, Gender = 1, Size = 0, Age = 10, Status = 0 },

            //кошка, мальчик, маленький, 12 мес
            new Animal { Id = 2, Name = "Барсик", Species = 1, Gender = 0, Size = 0, Age = 12, Status = 0 },

            //кошка, девочка, средняя, 8 мес
            new Animal { Id = 3, Name = "Ласка", Species = 1, Gender = 1, Size = 1, Age = 8, Status = 0 },

            //собака, девочка, маленькая, 9 мес
            new Animal { Id = 4, Name = "Жучка", Species = 0, Gender = 1, Size = 0, Age = 9, Status = 0 },

            //кошка, девочка, маленькая, 10 мес, пристроена
            new Animal { Id = 5, Name = "Пристроена", Species = 1, Gender = 1, Size = 0, Age = 10, Status = 2 }
        );
        context.SaveChanges();
        var repo = new AnimalPgRepository(context);

        //кошка, девочка, маленькая, от 6 до 11 месяцев
        var filter = new AnimalFilterViewModel
        {
            Species = 1,
            Gender = 1,
            Size = 0,
            AgeFrom = 6,
            AgeTo = 11
        };

        var result = repo.GetFilteredAnimals(filter);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Мурка", result[0].Name);
    }
}