using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShelterApp.Models;
using ShelterApp.Pages;
using ShelterApp.Repositories;
using ShelterApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace ShelterApp.Tests.Mocks;

[TestClass]
public class IndexFilterModelTests
{
    //IndexModel передает фильтр в репозиторий
    [TestMethod]
    public void OnGet_PassesCorrectFilterToRepository()
    {
        var repoMock = new Mock<IAnimalRepository>();
        var loggerMock = new Mock<ILogger<IndexModel>>();

        repoMock.Setup(r => r.GetFilteredAnimals(It.IsAny<AnimalFilterViewModel>()))
                .Returns(new List<Animal>());

        var model = new IndexModel(repoMock.Object, loggerMock.Object);

        model.OnGet(species: 1, gender: 1, size: 0, ageFrom: 12, ageTo: 24, search: "Мур");

        repoMock.Verify(r => r.GetFilteredAnimals(It.Is<AnimalFilterViewModel>(
            f => f.Species == 1 &&
                 f.Gender == 1 &&
                 f.Size == 0 &&
                 f.AgeFrom == 12 &&
                 f.AgeTo == 24 &&
                 f.SearchQuery == "Мур"
        )), Times.Once);
    }

    //пустой результат не ошибка
    [TestMethod]
    public void OnGet_WithEmptyResult_ReturnsPageWithEmptyAnimalsList()
    {
        var repoMock = new Mock<IAnimalRepository>();
        var loggerMock = new Mock<ILogger<IndexModel>>();

        repoMock.Setup(r => r.GetFilteredAnimals(It.IsAny<AnimalFilterViewModel>()))
                .Returns(new List<Animal>());

        var model = new IndexModel(repoMock.Object, loggerMock.Object);

        model.OnGet(species: null, gender: null, size: null, ageFrom: null, ageTo: null, search: "Ничего");

        Assert.IsNotNull(model.ViewModel);
        Assert.AreEqual(0, model.ViewModel.Animals.Count);
        Assert.IsNull(model.ErrorMessage);
    }
}