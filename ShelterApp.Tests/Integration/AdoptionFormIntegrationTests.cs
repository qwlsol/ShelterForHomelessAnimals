using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages.Adoption;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.Integration;

[TestClass]
public class AdoptionFormIntegrationTests
{
    private static CreateModel CreatePageModel(IAnimalRepository animals, IAdoptionRepository adoptions)
    {
        var page = new CreateModel(animals, adoptions);
        page.PageContext = new PageContext { HttpContext = new DefaultHttpContext() };
        return page;
    }

    private static IAnimalRepository AnimalRepoWith(Animal animal)
    {
        var mock = new Mock<IAnimalRepository>();
        mock.Setup(r => r.GetAnimalById(animal.Id)).Returns(animal);
        return mock.Object;
    }

    // Интеграционный тест 1. Открытие формы заявки — для конкретного animalId.
    [TestMethod]
    public void Create_Form_Opens_WithAnimalData()
    {
        var animal = new Animal
        {
            Id = 1,
            Name = "Тимоша",
            Photos = new List<Photo>
            {
                new Photo { FilePath = "/images/timosha.jpg", IsMain = true }
            }
        };

        // Мок настроен на animalId = 1
        var mockAnimals = new Mock<IAnimalRepository>();
        mockAnimals.Setup(r => r.GetAnimalById(1)).Returns(animal);

        var adoptionRepo = new Mock<IAdoptionRepository>().Object;
        var page = CreatePageModel(mockAnimals.Object, adoptionRepo);

        page.OnGet(1);

        Assert.AreEqual(1, page.Form.AnimalId);
        Assert.AreEqual("Тимоша", page.Form.AnimalName);
        Assert.AreEqual("/images/timosha.jpg", page.Form.AnimalPhotoPath);

        // Проверяем, что запрос был именно по animalId = 1
        mockAnimals.Verify(r => r.GetAnimalById(1), Times.Once);
    }

    // Интеграционный тест 2. Сохранение усыновителя с конкретными данными.
    [TestMethod]
    public void Submit_Saves_Adopter_WithCorrectData()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockAdoptions = new Mock<IAdoptionRepository>();

        Adopter? savedAdopter = null;
        mockAdoptions.Setup(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 900 000 00 00"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 1)))
            .Callback<Adopter, AdoptionRequest>((a, _) => savedAdopter = a);

        var page = CreatePageModel(AnimalRepoWith(animal), mockAdoptions.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00",
            Email = "maria@mail.ru"
        };

        page.OnPost();

        Assert.IsNotNull(savedAdopter);
        Assert.AreEqual("Иванова Мария", savedAdopter!.FullName);
        Assert.AreEqual("+7 900 000 00 00", savedAdopter.Phone);
        Assert.AreEqual("maria@mail.ru", savedAdopter.Email);
    }

    // Интеграционный тест 3. Сохранение заявки со статусом «на рассмотрении» — для конкретного животного.
    [TestMethod]
    public void Submit_Saves_AdoptionRequest_WithStatusPending()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockAdoptions = new Mock<IAdoptionRepository>();

        AdoptionRequest? savedRequest = null;
        mockAdoptions.Setup(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 911 111 11 11"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 1)))
            .Callback<Adopter, AdoptionRequest>((_, r) => savedRequest = r);

        var page = CreatePageModel(AnimalRepoWith(animal), mockAdoptions.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Петров Иван",
            Phone = "+7 911 111 11 11",
            Email = ""
        };

        page.OnPost();

        Assert.IsNotNull(savedRequest);
        Assert.AreEqual(1, savedRequest!.AnimalId);
        Assert.AreEqual(0, savedRequest.Status);
    }
}