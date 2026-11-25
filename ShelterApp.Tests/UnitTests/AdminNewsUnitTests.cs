using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Models;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class AdminNewsUnitTests
{
    // Тест 1. Загрузка списка. Вызов LoadNews заполняет NewsList данными из мока.
    [TestMethod]
    public void LoadNews_FillsNewsList_FromMock()
    {
        var mockService = new Mock<INewsService>(); // Теперь мокаем интерфейс
        var testNews = new List<News> { new News { Id = 1, Title = "Тест" } };
        mockService.Setup(s => s.GetAll()).Returns(testNews);

        var vm = new NewsListViewModel();
        vm.LoadNews(mockService.Object);

        Assert.AreEqual(1, vm.NewsList.Count);
        Assert.AreEqual("Тест", vm.NewsList[0].Title);
    }

    // Тест 2. Выбор новости. При установке SelectedNews данные корректно передаются.
    [TestMethod]
    public void SelectedNews_CanBeSet()
    {
        // Arrange
        var vm = new NewsListViewModel();
        var news = new News { Id = 5, Title = "Выбранная" };

        // Act
        vm.SelectedNews = news;

        // Assert
        Assert.IsNotNull(vm.SelectedNews);
        Assert.AreEqual(5, vm.SelectedNews.Id);
        Assert.AreEqual("Выбранная", vm.SelectedNews.Title);
    }

    // Тест 3. Сохранение новой новости. Метод Save при Id = 0 вызывает метод Add.
    [TestMethod]
    public void Save_WhenIdIsZero_CallsAdd()
    {
        var mockService = new Mock<INewsService>();
        var vm = new NewsEditViewModel { Id = 0, Title = "Новая" };

        vm.Save(mockService.Object);

        mockService.Verify(s => s.Add(It.Is<News>(n => n.Title == "Новая")), Times.Once);
        mockService.Verify(s => s.Update(It.IsAny<News>()), Times.Never);
    }
}