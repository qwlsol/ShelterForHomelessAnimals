using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages.Adoption;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.Mocks;

[TestClass]
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

    // Mock-тест 1. Вызов сохранения с конкретными данными.
    [TestMethod]
    public void OnPost_ValidModel_CallsRepository_WithExpectedData()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockAdoptions = new Mock<IAdoptionRepository>();

        // Настраиваем мок на конкретные значения:
        // Phone = "+7 900 000 00 00", AnimalId = 1.
        mockAdoptions.Setup(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 900 000 00 00"
                             && a.FullName == "Иванова Мария"
                             && a.Email == "maria@mail.ru"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 1)));

        var page = CreatePageModel(AnimalRepoWith(animal), mockAdoptions.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00",
            Email = "maria@mail.ru"
        };

        page.OnPost();

        // Проверяем, что метод был вызван именно с этими данными
        mockAdoptions.Verify(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 900 000 00 00"
                             && a.FullName == "Иванова Мария"
                             && a.Email == "maria@mail.ru"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 1)),
            Times.Once);
    }

    // Mock-тест 2. Неверная модель — сохранение не вызывается.
    [TestMethod]
    public void OnPost_InvalidModel_DoesNotCallRepository()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockAdoptions = new Mock<IAdoptionRepository>();

        var page = CreatePageModel(AnimalRepoWith(animal), mockAdoptions.Object);
        page.ModelState.AddModelError("Form.FullName", "Required");
        page.Form = new AdoptionFormViewModel { AnimalId = 1 };

        page.OnPost();

        // Проверяем, что для конкретного телефона вызова не было
        mockAdoptions.Verify(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 900 000 00 00"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 1)),
            Times.Never);
        Assert.IsNull(page.SuccessMessage);
    }

    // Mock-тест 3. Успешное сохранение — сообщение об успехе.
    [TestMethod]
    public void OnPost_ValidModel_ShowsSuccessMessage()
    {
        var animal = new Animal { Id = 1, Name = "Тимоша", Photos = new List<Photo>() };
        var mockAdoptions = new Mock<IAdoptionRepository>();

        mockAdoptions.Setup(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 900 000 00 00"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 1)));

        var page = CreatePageModel(AnimalRepoWith(animal), mockAdoptions.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00"
        };

        page.OnPost();

        Assert.AreEqual("Ваша заявка отправлена. Сотрудник приюта свяжется с вами.", page.SuccessMessage);
    }

    // Mock-тест 4. Передача данных в хранилище — проверяем конкретные поля.
    [TestMethod]
    public void OnPost_PassesCorrectData_ToRepository()
    {
        var animal = new Animal { Id = 7, Name = "Барсик", Photos = new List<Photo>() };
        var mockAdoptions = new Mock<IAdoptionRepository>();

        Adopter? savedAdopter = null;
        AdoptionRequest? savedRequest = null;

        mockAdoptions.Setup(r => r.AddAdoptionRequest(
            It.Is<Adopter>(a => a.Phone == "+7 911 111 11 11"),
            It.Is<AdoptionRequest>(r => r.AnimalId == 7)))
            .Callback<Adopter, AdoptionRequest>((a, r) =>
            {
                savedAdopter = a;
                savedRequest = r;
            });

        var page = CreatePageModel(AnimalRepoWith(animal), mockAdoptions.Object);
        page.Form = new AdoptionFormViewModel
        {
            AnimalId = 7,
            FullName = "Петров Иван",
            Phone = "+7 911 111 11 11",
            Email = "ivan@mail.ru"
        };

        page.OnPost();

        Assert.IsNotNull(savedAdopter);
        Assert.AreEqual("Петров Иван", savedAdopter!.FullName);
        Assert.AreEqual("+7 911 111 11 11", savedAdopter.Phone);
        Assert.AreEqual("ivan@mail.ru", savedAdopter.Email);

        Assert.IsNotNull(savedRequest);
        Assert.AreEqual(7, savedRequest!.AnimalId);
    }
}