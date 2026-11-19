using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages.News;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.Mocks;

[TestClass]
public class NewsMockTests
{
    // Тест 1. Вызов загрузки списка
    [TestMethod]
    public void Index_OnGet_CallsGetAllOnce()
    {
        var mockRepo = new Mock<INewsRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<News>());

        var page = new IndexModel(mockRepo.Object);
        page.OnGet();

        mockRepo.Verify(r => r.GetAll(), Times.Once);
    }

    // Тест 2. Обработка ошибки БД
    [TestMethod]
    public void Index_OnGet_RepositoryThrows_SetsErrorMessage()
    {
        var mockRepo = new Mock<INewsRepository>();
        mockRepo.Setup(r => r.GetAll()).Throws(new Exception("БД упала"));

        var page = new IndexModel(mockRepo.Object);
        page.OnGet();

        Assert.IsNotNull(page.ViewModel.ErrorMessage);
        StringAssert.Contains(page.ViewModel.ErrorMessage, "БД упала");
    }

    // Тест 3. Пустая лента (проверка состояния модели)
    [TestMethod]
    public void Index_OnGet_EmptyList_ReturnsEmptyViewModel()
    {
        var mockRepo = new Mock<INewsRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<News>());

        var page = new IndexModel(mockRepo.Object);
        page.OnGet();

        Assert.AreEqual(0, page.ViewModel.News.Count);
        Assert.IsNull(page.ViewModel.ErrorMessage);
    }

    // Тест 4. Открытие конкретной новости
    [TestMethod]
    public void Details_OnGet_CallsGetByIdWithCorrectId()
    {
        var mockRepo = new Mock<INewsRepository>();
        mockRepo.Setup(r => r.GetById(5)).Returns(new News { Id = 5 });

        var mockAnimalRepo = new Mock<IAnimalRepository>();
        var page = new DetailsModel(mockRepo.Object, mockAnimalRepo.Object);
        page.OnGet(5);

        mockRepo.Verify(r => r.GetById(5), Times.Once);
    }

    // Тест 5. Новость не найдена
    [TestMethod]
    public void Details_OnGet_NotFound_WhenNewsIsNull()
    {
        var mockRepo = new Mock<INewsRepository>();
        mockRepo.Setup(r => r.GetById(99)).Returns((News?)null);

        var mockAnimalRepo = new Mock<IAnimalRepository>();
        var page = new DetailsModel(mockRepo.Object, mockAnimalRepo.Object);
        var result = page.OnGet(99);

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }

    // Тест 6. Загрузка связанного животного
    [TestMethod]
    public void Details_OnGet_LoadsRelatedAnimal_WhenAnimalIdExists()
    {
        var mockRepo = new Mock<INewsRepository>();
        mockRepo.Setup(r => r.GetById(1)).Returns(new News { Id = 1, AnimalId = 3 });

        var mockAnimalRepo = new Mock<IAnimalRepository>();
        mockAnimalRepo.Setup(r => r.GetAnimalById(3)).Returns(new Animal { Id = 3, Name = "Тимоша" });

        var page = new DetailsModel(mockRepo.Object, mockAnimalRepo.Object);
        page.OnGet(1);

        Assert.IsNotNull(page.ViewModel.RelatedAnimal);
        Assert.AreEqual("Тимоша", page.ViewModel.RelatedAnimal.Name);
        mockAnimalRepo.Verify(r => r.GetAnimalById(3), Times.Once);
    }
}