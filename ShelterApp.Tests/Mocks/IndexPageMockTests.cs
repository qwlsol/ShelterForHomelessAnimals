using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages;
using ShelterApp.Repositories;
using Xunit;

namespace ShelterApp.Tests.Mocks;

// Mock-тесты страницы IndexModel с мок-репозиторием.
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

    [Fact]
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
    [Fact]
    public void Index_OnGet_RepositoryThrows_SetsErrorMessage()
    {
        var mockRepo = new Mock<IAnimalRepository>();
        mockRepo.Setup(r => r.GetAvailableAnimals())
                .Throws(new InvalidOperationException("БД недоступна"));

        var logger = Mock.Of<ILogger<IndexModel>>();
        var page = new IndexModel(mockRepo.Object, logger);

        page.OnGet();

        page.ErrorMessage.Should().NotBeNull("сообщение об ошибке должно быть установлено");
        page.ErrorMessage.Should().Contain("БД недоступна");
        page.ViewModel.Animals.Should().BeEmpty("при ошибке список животных должен быть пустым");
    }

}