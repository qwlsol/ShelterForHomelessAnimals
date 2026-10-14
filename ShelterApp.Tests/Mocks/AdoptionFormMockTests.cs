using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages.Adoption;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;
using Xunit;

namespace ShelterApp.Tests.Mocks;

public class AdoptionFormMockTests
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

    // Mock-тест 1 вызов сохранения ровно один раз
    [Fact]
    public void OnPost_ValidModel_CallsRepository_Once()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockRepo = new Mock<IAdoptionRepository>();

        var page = CreatePageModel(AnimalRepoWith(animal), mockRepo.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00",
            Email = "maria@mail.ru"
        };

        page.OnPost();

        mockRepo.Verify(r => r.AddAdoptionRequest(It.IsAny<Adopter>(), It.IsAny<AdoptionRequest>()),
            Times.Once);
    }

    // Mock-тест 2 неверная модель сохранение не вызывается
    [Fact]
    public void OnPost_InvalidModel_DoesNotCallRepository()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockRepo = new Mock<IAdoptionRepository>();

        var page = CreatePageModel(AnimalRepoWith(animal), mockRepo.Object);
        page.ModelState.AddModelError("Form.FullName", "Required");
        page.Form = new AdoptionFormViewModel { AnimalId = 1 };

        page.OnPost();

        mockRepo.Verify(r => r.AddAdoptionRequest(It.IsAny<Adopter>(), It.IsAny<AdoptionRequest>()),
            Times.Never);
        page.SuccessMessage.Should().BeNull();
    }

    // Mock-тест 3 успешное сохранение сообщение об успехе
    [Fact]
    public void OnPost_ValidModel_ShowsSuccessMessage()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockRepo = new Mock<IAdoptionRepository>();

        var page = CreatePageModel(AnimalRepoWith(animal), mockRepo.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00"
        };

        page.OnPost();

        page.SuccessMessage.Should().Be("Ваша заявка отправлена. Сотрудник приюта свяжется с вами.");
    }

    // Mock-тест 4 передача данных в хранилище
    [Fact]
    public void OnPost_PassesCorrectData_ToRepository()
    {
        var animal = new Animal { Id = 7, Name = "Барсик", Photos = new List<Photo>() };
        var mockRepo = new Mock<IAdoptionRepository>();

        Adopter? savedAdopter = null;
        AdoptionRequest? savedRequest = null;
        mockRepo.Setup(r => r.AddAdoptionRequest(It.IsAny<Adopter>(), It.IsAny<AdoptionRequest>()))
                .Callback<Adopter, AdoptionRequest>((a, r) => { savedAdopter = a; savedRequest = r; });

        var page = CreatePageModel(AnimalRepoWith(animal), mockRepo.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 7,
            FullName = "Петров Иван",
            Phone = "+7 911 111 11 11",
            Email = "ivan@mail.ru"
        };

        page.OnPost();

        savedAdopter.Should().NotBeNull();
        savedAdopter!.FullName.Should().Be("Петров Иван");
        savedAdopter.Phone.Should().Be("+7 911 111 11 11");
        savedAdopter.Email.Should().Be("ivan@mail.ru");

        savedRequest.Should().NotBeNull();
        savedRequest!.AnimalId.Should().Be(7);
    }
}