using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages.Animals;
using ShelterApp.Repositories;

namespace ShelterApp.Tests.Mocks;

[TestClass]
public class DetailsPageModelTests
{
    // Тест 6. Вызов метода репозитория с правильными параметрами
    [TestMethod]
    public void OnGet_CallsGetSimilarAnimalsWithCorrectParams()
    {
        var repoMock = new Mock<IAnimalRepository>();
        repoMock.Setup(r => r.GetAnimalById(1))
                .Returns(new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0 });
        repoMock.Setup(r => r.GetSimilarAnimals(1, 6))
                .Returns(new List<Animal>());

        var model = new DetailsModel(repoMock.Object);

        model.OnGet(1);

        repoMock.Verify(r => r.GetSimilarAnimals(1, 6), Times.Once);
    }

    // Тест 7. Передача данных в ViewModel
    [TestMethod]
    public void OnGet_FillsSimilarViewModelCorrectly()
    {
        var similarAnimals = new List<Animal>
        {
            new Animal { Id = 2, Name = "Мурка", Species = 1, Status = 0 }
        };
        var repoMock = new Mock<IAnimalRepository>();
        repoMock.Setup(r => r.GetAnimalById(1))
                .Returns(new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0 });
        repoMock.Setup(r => r.GetSimilarAnimals(1, 6))
                .Returns(similarAnimals);

        var model = new DetailsModel(repoMock.Object);

        model.OnGet(1);

        Assert.AreEqual(1, model.SimilarViewModel.CurrentAnimalId);
        Assert.AreEqual(1, model.SimilarViewModel.SimilarAnimals.Count);
        Assert.AreEqual(2, model.SimilarViewModel.SimilarAnimals[0].Id);
    }

    // Тест 8. Пустой результат
    [TestMethod]
    public void OnGet_WithEmptySimilarList_ReturnsPageWithoutErrors()
    {
        var repoMock = new Mock<IAnimalRepository>();
        repoMock.Setup(r => r.GetAnimalById(1))
                .Returns(new Animal { Id = 1, Name = "Барсик", Species = 1, Status = 0 });
        repoMock.Setup(r => r.GetSimilarAnimals(1, 6))
                .Returns(new List<Animal>());

        var model = new DetailsModel(repoMock.Object);

        var result = model.OnGet(1);

        Assert.IsInstanceOfType(result, typeof(PageResult));
        Assert.AreEqual(0, model.SimilarViewModel.SimilarAnimals.Count);
    }
}