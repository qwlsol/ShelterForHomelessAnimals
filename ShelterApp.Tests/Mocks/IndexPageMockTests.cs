using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.Mocks;

// Mock-тесты страницы IndexModel с мок-репозиторием.
[TestClass]
public class IndexPageMockTests
{
    //проверка, что контроллер вызывает репозиторий ровно один раз
    [TestMethod]
    public void Index_OnGet_CallsRepository_ExactlyOnce()
    {
        var mockRepo = new Mock<IAnimalRepository>();
        mockRepo.Setup(r => r.GetFilteredAnimals(It.IsAny<AnimalFilterViewModel>()))
                .Returns(new List<Animal>());

        var logger = Mock.Of<ILogger<IndexModel>>();
        var page = new IndexModel(mockRepo.Object, logger);

        page.OnGet(null, null, null, null, null, null);

        mockRepo.Verify(r => r.GetFilteredAnimals(It.IsAny<AnimalFilterViewModel>()), Times.Once,
            "метод получения животных должен вызываться ровно один раз");
    }

    //если БД выдает ошибку, контроллер должен её перехватить и записать в ErrorMessage
    [TestMethod]
    public void Index_OnGet_RepositoryThrows_SetsErrorMessage()
    {
        var mockRepo = new Mock<IAnimalRepository>();
        mockRepo.Setup(r => r.GetFilteredAnimals(It.IsAny<AnimalFilterViewModel>()))
                .Throws(new InvalidOperationException("БД недоступна"));

        var logger = Mock.Of<ILogger<IndexModel>>();
        var page = new IndexModel(mockRepo.Object, logger);

        page.OnGet(null, null, null, null, null, null);

        Assert.IsNotNull(page.ErrorMessage, "сообщение об ошибке должно быть установлено");
        StringAssert.Contains(page.ErrorMessage, "БД недоступна");
    }
}