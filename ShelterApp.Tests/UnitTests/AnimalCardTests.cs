using FluentAssertions;
using ShelterApp.Models;
using Xunit;

namespace ShelterApp.Tests.UnitTests;
// Unit-тесты карточки животного.
public class AnimalCardTests
{
    // Тест 1. Формирование карточки животного.
    // Данные модели поступают в представление, карточка формируется корректно.
    [Fact]
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

        isCardReady.Should().BeTrue("все поля для карточки должны быть заполнены");
        animal.Name.Should().Be("Тимоша");
    }

    // Тест 2. На карточке отображается главная фотография животного.
    [Fact]
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

        mainPhoto.Should().Be("/images/timosha-main.jpg",
            "должна вернуться фотография с IsMain = true");
    }

    [Fact]
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

        animal.MainPhoto.Should().Be("/images/1.jpg");
    }

    [Fact]
    public void MainPhoto_ReturnsNull_WhenNoPhotos()
    {
        var animal = new Animal { Photos = new List<Photo>() };
        animal.MainPhoto.Should().BeNull();
    }

   
    // Тест 3. На карточке отображается кличка, вид, порода, пол, возраст и размер животного
    [Fact]
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

        animal.Name.Should().Be("Мурка");            // кличка
        animal.SpeciesText.Should().Be("Кошка");     // вид
        animal.Breed.Should().Be("британская");      // порода
        animal.GenderText.Should().Be("Девочка");    // пол
        animal.AgeText.Should().Be("2 г. 0 мес.");   // возраст
        animal.SizeText.Should().Be("Маленький");    // размер
    }

    [Theory]
    [InlineData(0, "Собака")]
    [InlineData(1, "Кошка")]
    public void SpeciesText_IsCorrect(int species, string expected)
        => new Animal { Species = species }.SpeciesText.Should().Be(expected);

    [Theory]
    [InlineData(0, "Мальчик")]
    [InlineData(1, "Девочка")]
    public void GenderText_IsCorrect(int gender, string expected)
        => new Animal { Gender = gender }.GenderText.Should().Be(expected);

    [Theory]
    [InlineData(0, "Маленький")]
    [InlineData(1, "Средний")]
    [InlineData(2, "Крупный")]
    public void SizeText_IsCorrect(int size, string expected)
        => new Animal { Size = size }.SizeText.Should().Be(expected);

    [Theory]
    [InlineData(6, "6 мес.")]
    [InlineData(11, "11 мес.")]
    [InlineData(12, "1 г. 0 мес.")]
    [InlineData(24, "2 г. 0 мес.")]
    [InlineData(36, "3 г. 0 мес.")]
    public void AgeText_IsCorrect(int age, string expected)
        => new Animal { Age = age }.AgeText.Should().Be(expected);
}