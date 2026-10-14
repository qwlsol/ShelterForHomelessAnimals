using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Models;

namespace ShelterApp.Tests.UnitTests;

// Unit-тесты карточки животного.
[TestClass]
public class AnimalCardTests
{
    // Тест 1. Формирование карточки животного.
    // Данные модели поступают в представление, карточка формируется корректно.
    [TestMethod]
    public void AnimalCard_IsFormedCorrectly_FromModel()
    {
        var animal = new Animal
        {
            Id = 1,
            Name = "Тимоша",
            Species = 1,
            Breed = "метис",
            Gender = 0,
            Age = 6,
            Size = 0,
            Description = "Пушистый малыш.",
            Status = 0
        };

        var isCardReady =
            !string.IsNullOrWhiteSpace(animal.Name) &&
            !string.IsNullOrWhiteSpace(animal.Breed) &&
            !string.IsNullOrWhiteSpace(animal.Description) &&
            !string.IsNullOrWhiteSpace(animal.SpeciesText) &&
            !string.IsNullOrWhiteSpace(animal.GenderText) &&
            !string.IsNullOrWhiteSpace(animal.SizeText) &&
            !string.IsNullOrWhiteSpace(animal.AgeText);

        Assert.IsTrue(isCardReady, "все поля для карточки должны быть заполнены");
        Assert.AreEqual("Тимоша", animal.Name);
    }

    // Тест 2. На карточке отображается главная фотография животного.
    [TestMethod]
    public void MainPhoto_ReturnsPhotoWithIsMainTrue()
    {
        var animal = new Animal
        {
            Id = 5,
            Name = "Тимоша",
            Photos = new List<Photo>
            {
                new Photo { Id = 1, AnimalId = 5, FilePath = "/images/timosha-1.jpg", IsMain = false },
                new Photo { Id = 2, AnimalId = 5, FilePath = "/images/timosha-main.jpg", IsMain = true },
                new Photo { Id = 3, AnimalId = 5, FilePath = "/images/timosha-3.jpg", IsMain = false }
            }
        };

        var mainPhoto = animal.MainPhoto;

        Assert.AreEqual("/images/timosha-main.jpg", mainPhoto,
            "должна вернуться фотография с IsMain = true");
    }

    [TestMethod]
    public void MainPhoto_ReturnsFirstPhoto_WhenNoMainFlagged()
    {
        var animal = new Animal
        {
            Photos = new List<Photo>
            {
                new Photo { Id = 1, FilePath = "/images/1.jpg", IsMain = false },
                new Photo { Id = 2, FilePath = "/images/2.jpg", IsMain = false }
            }
        };

        Assert.AreEqual("/images/1.jpg", animal.MainPhoto);
    }

    [TestMethod]
    public void MainPhoto_ReturnsNull_WhenNoPhotos()
    {
        var animal = new Animal { Photos = new List<Photo>() };
        Assert.IsNull(animal.MainPhoto);
    }

    // Тест 3. На карточке отображается кличка, вид, порода, пол, возраст и размер животного.
    [TestMethod]
    public void AnimalCard_Contains_AllRequiredFields()
    {
        var animal = new Animal
        {
            Name = "Мурка",
            Species = 1,       // кошка
            Breed = "британская",
            Gender = 1,        // девочка
            Age = 24,          // 2 года
            Size = 0           // маленький
        };

        Assert.AreEqual("Мурка", animal.Name);             // кличка
        Assert.AreEqual("Кошка", animal.SpeciesText);      // вид
        Assert.AreEqual("британская", animal.Breed);       // порода
        Assert.AreEqual("Девочка", animal.GenderText);     // пол
        Assert.AreEqual("2 г. 0 мес.", animal.AgeText);    // возраст
        Assert.AreEqual("Маленький", animal.SizeText);     // размер
    }

    [DataTestMethod]
    [DataRow(0, "Собака")]
    [DataRow(1, "Кошка")]
    public void SpeciesText_IsCorrect(int species, string expected)
    {
        Assert.AreEqual(expected, new Animal { Species = species }.SpeciesText);
    }

    [DataTestMethod]
    [DataRow(0, "Мальчик")]
    [DataRow(1, "Девочка")]
    public void GenderText_IsCorrect(int gender, string expected)
    {
        Assert.AreEqual(expected, new Animal { Gender = gender }.GenderText);
    }

    [DataTestMethod]
    [DataRow(0, "Маленький")]
    [DataRow(1, "Средний")]
    [DataRow(2, "Крупный")]
    public void SizeText_IsCorrect(int size, string expected)
    {
        Assert.AreEqual(expected, new Animal { Size = size }.SizeText);
    }

    [DataTestMethod]
    [DataRow(6, "6 мес.")]
    [DataRow(11, "11 мес.")]
    [DataRow(12, "1 г. 0 мес.")]
    [DataRow(24, "2 г. 0 мес.")]
    [DataRow(36, "3 г. 0 мес.")]
    public void AgeText_IsCorrect(int age, string expected)
    {
        Assert.AreEqual(expected, new Animal { Age = age }.AgeText);
    }
}