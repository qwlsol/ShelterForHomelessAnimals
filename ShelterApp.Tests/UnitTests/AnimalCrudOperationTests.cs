using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class AnimalCrudOperationTests
{
    //проверка что новое животное корректно сохраняется в базу данных
    [TestMethod]
    public void AddAnimal_SavesToDatabase()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        IAnimalService service = new AnimalService(context);

        var vm = new AnimalEditViewModel
        {
            Name = "Тестик",
            Species = 1,
            Age = 5,
            Breed = "метис"
        };

        service.AddAnimal(vm);

        Assert.AreEqual(1, context.Animals.Count());
        var saved = context.Animals.First();
        Assert.AreEqual("Тестик", saved.Name);
        Assert.AreEqual(5, saved.Age);
    }

    //проверка что изменения в карточке животного корректно применяются и сохраняются
    [TestMethod]
    public void UpdateAnimal_ChangesDataInDatabase()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.Add(new Animal { Id = 1, Name = "Старое", Species = 0, Status = 0 });
        context.SaveChanges();

        IAnimalService service = new AnimalService(context);

        var vm = new AnimalEditViewModel
        {
            Id = 1,
            Name = "Новое",
            Species = 1,
            Status = 1,
            Age = 10
        };

        service.UpdateAnimal(vm);

        var updatedAnimal = context.Animals.Find(1);
        Assert.IsNotNull(updatedAnimal);
        Assert.AreEqual("Новое", updatedAnimal.Name);
        Assert.AreEqual(1, updatedAnimal.Species);
        Assert.AreEqual(1, updatedAnimal.Status);
    }

    //проверка что животное удаляется из базы данных
    [TestMethod]
    public void DeleteAnimal_RemovesFromDatabase()
    {
        var options = new DbContextOptionsBuilder<ShelterContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        using var context = new ShelterContext(options);

        context.Animals.Add(new Animal { Id = 1, Name = "Удаляемое" });
        context.SaveChanges();

        IAnimalService service = new AnimalService(context);

        service.DeleteAnimal(1);

        Assert.AreEqual(0, context.Animals.Count());
    }
}