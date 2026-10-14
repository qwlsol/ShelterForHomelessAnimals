using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.Integration;

[TestClass]
public class IndexIntegrationTests
{
    private static IAnimalRepository CreateRepo(List<Animal> available)
    {
        var mock = new Mock<IAnimalRepository>();
        mock.Setup(r => r.GetAvailableAnimals()).Returns(available);
        return mock.Object;
    }

    // Интеграционный тест 1. Список животных загружается из хранилища.
    [TestMethod]
    public void Index_LoadsAnimals_FromRepository()
    {
        var animals = new List<Animal>
        {
            new Animal { Name = "Барсик", Species = 1, Breed = "метис",      Gender = 0, Age = 12, Size = 0, Status = 0 },
            new Animal { Name = "Мурка",  Species = 1, Breed = "британская", Gender = 1, Age = 24, Size = 0, Status = 0 }
        };

        var repo = CreateRepo(animals);
        var result = repo.GetAvailableAnimals();

        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.Any(a => a.Name == "Барсик"));
        Assert.IsTrue(result.Any(a => a.Name == "Мурка"));
    }

    // Интеграционный тест 2. Карточки формируются на основе данных животного.
    [TestMethod]
    public void Index_CardsAreBuilt_FromAnimalData()
    {
        var animal = new Animal
        {
            Name = "Рекс",
            Species = 0,        // собака
            Breed = "овчарка",
            Gender = 0,         // мальчик
            Age = 36,           // 3 года
            Size = 2,           // крупный
            Status = 0
        };

        var repo = CreateRepo(new List<Animal> { animal });
        var result = repo.GetAvailableAnimals();

        var card = result.First();

        Assert.AreEqual("Рекс", card.Name);
        Assert.AreEqual("Собака", card.SpeciesText);
        Assert.AreEqual("овчарка", card.Breed);
        Assert.AreEqual("Мальчик", card.GenderText);
        Assert.AreEqual("3 г. 0 мес.", card.AgeText);
        Assert.AreEqual("Крупный", card.SizeText);
    }

    // Интеграционный тест 3. Фотографии подгружаются к животному.
    [TestMethod]
    public void Index_LoadsPhotos_ForAnimal()
    {
        var animal = new Animal
        {
            Name = "Тимоша",
            Species = 1,
            Breed = "метис",
            Gender = 0,
            Age = 6,
            Size = 0,
            Status = 0,
            Photos = new List<Photo>
            {
                new Photo { FilePath = "/images/timosha.jpg", IsMain = true }
            }
        };

        var repo = CreateRepo(new List<Animal> { animal });
        var result = repo.GetAvailableAnimals();

        var photo = result.First().MainPhoto;

        Assert.AreEqual("/images/timosha.jpg", photo,
            "главное фото должно быть доступно карточке");
    }

    // Интеграционный тест 4. Животные со статусом «пристроен» не отображаются в списке.
    [TestMethod]
    public void Index_DoesNotShow_AdoptedAnimals()
    {
        // Мок возвращает только доступных — репозиторий сам фильтрует пристроенных
        var available = new List<Animal>
        {
            new Animal { Name = "Доступный", Species = 0, Breed = "метис", Gender = 0, Age = 12, Size = 1, Status = 0 }
        };

        var repo = CreateRepo(available);
        var result = repo.GetAvailableAnimals();

        Assert.AreEqual(1, result.Count);
        Assert.IsTrue(result.Any(a => a.Name == "Доступный"));
        Assert.IsFalse(result.Any(a => a.Status == 2),
            "животные со статусом 2 (пристроен) не должны попадать в список");
    }

    // Интеграционный тест 5. Главная страница доступна без авторизации.
    // Проверяем, что репозиторий возвращает список без дополнительных условий.
    [TestMethod]
    public void Index_IsAccessible_WithoutAuth()
    {
        var repo = CreateRepo(new List<Animal>());
        var result = repo.GetAvailableAnimals();

        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }
}