using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.Mocks;

// Mock-тесты страницы IndexModel с мок-репозиторием.
[TestClass]
public class IndexPageMockTests
{
    private static IndexModel CreatePageModel(IAnimalRepository repo)
    {
        var logger = Mock.Of<ILogger<IndexModel>>();
        var page = new IndexModel(repo, logger);

        // Имитируем HttpContext для Razor Pages
        page.PageContext = new PageContext
        {
            HttpContext = new DefaultHttpContext()
        };
        return page;
    }

    // Mock-тест 1. При загрузке главной страницы метод получения животных вызывается один раз.
    [TestMethod]
    public void Index_OnGet_CallsRepository_ExactlyOnce()
    {
        var mockRepo = new Mock<IAnimalRepository>();
        mockRepo.Setup(r => r.GetAvailableAnimals())
                .Returns(new List<Animal>());

        var page = CreatePageModel(mockRepo.Object);

        page.OnGet();

        mockRepo.Verify(r => r.GetAvailableAnimals(), Times.Once,
            "метод получения животных должен вызываться ровно один раз");
    }

    // Mock-тест 2. Если получение животных завершается ошибкой, страница отображает сообщение об ошибке.
    [TestMethod]
    public void Index_OnGet_RepositoryThrows_SetsErrorMessage()
    {
        var mockRepo = new Mock<IAnimalRepository>();
        mockRepo.Setup(r => r.GetAvailableAnimals())
                .Throws(new InvalidOperationException("БД недоступна"));

        var logger = Mock.Of<ILogger<IndexModel>>();
        var page = new IndexModel(mockRepo.Object, logger);

        page.OnGet();

        Assert.IsNotNull(page.ErrorMessage, "сообщение об ошибке должно быть установлено");
        StringAssert.Contains(page.ErrorMessage, "БД недоступна");
        Assert.AreEqual(0, page.ViewModel.Animals.Count, "при ошибке список животных должен быть пустым");
    }
}