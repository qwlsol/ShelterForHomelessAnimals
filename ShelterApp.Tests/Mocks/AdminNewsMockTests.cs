using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Models;

namespace ShelterApp.Tests.Mocks;

[TestClass]
public class AdminNewsMockTests
{
    // Тест 1. Вызов сохранения (редактирование). Если Id > 0, метод Save вызывает Update ровно один раз.
    [TestMethod]
    public void Save_WhenIdGreaterThanZero_CallsUpdate()
    {
        var mockService = new Mock<INewsService>();
        var vm = new NewsEditViewModel { Id = 1, Title = "Обновленная" };

        vm.Save(mockService.Object);

        mockService.Verify(s => s.Update(It.Is<News>(n => n.Id == 1 && n.Title == "Обновленная")), Times.Once);
        mockService.Verify(s => s.Add(It.IsAny<News>()), Times.Never);
    }

    // Тест 2. Вызов удаления. Вызов DeleteSelectedNews вызывает Delete(id) с правильным ID.
    [TestMethod]
    public void DeleteSelectedNews_CallsDeleteWithCorrectId()
    {
        var mockService = new Mock<INewsService>();
        var vm = new NewsListViewModel { SelectedNews = new News { Id = 42 } };
        vm.NewsList.Add(vm.SelectedNews);

        vm.DeleteSelectedNews(mockService.Object);

        mockService.Verify(s => s.Delete(42), Times.Once);
    }

    // Тест 3. Обработка ошибки загрузки.
    [TestMethod]
    public void LoadNews_WhenServiceThrows_SetsErrorMessage()
    {
        var mockService = new Mock<INewsService>();
        mockService.Setup(s => s.GetAll()).Throws(new Exception("БД упала"));

        var vm = new NewsListViewModel();
        vm.LoadNews(mockService.Object);

        Assert.IsNotNull(vm.ErrorMessage);
        StringAssert.Contains(vm.ErrorMessage, "Не удалось загрузить новости");
    }
}