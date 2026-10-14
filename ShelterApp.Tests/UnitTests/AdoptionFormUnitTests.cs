using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterApp.Models;
using ShelterApp.ViewModels;

namespace ShelterApp.Tests.UnitTests;

[TestClass]
public class AdoptionFormUnitTests
{
    // Тест 1. Формирование модели заявки.
    [TestMethod]
    public void FormData_Converts_ToAdopterAndRequest()
    {
        var form = new AdoptionFormViewModel
        {
            AnimalId = 5,
            AnimalName = "Тимоша",
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00",
            Email = "maria@mail.ru"
        };

        var adopter = new Adopter
        {
            FullName = form.FullName,
            Phone = form.Phone,
            Email = form.Email
        };
        var request = new AdoptionRequest
        {
            AnimalId = form.AnimalId,
            AdopterId = 1
        };

        Assert.AreEqual("Иванова Мария", adopter.FullName);
        Assert.AreEqual("+7 900 000 00 00", adopter.Phone);
        Assert.AreEqual("maria@mail.ru", adopter.Email);
        Assert.AreEqual(5, request.AnimalId);
        Assert.AreEqual(1, request.AdopterId);
        Assert.AreEqual(0, request.Status);
    }

    // Тест 2. Проверка обязательных полей.
    [DataTestMethod]
    [DataRow("", "+7 900 000 00 00")]
    [DataRow("Иванова Мария", "")]
    [DataRow("", "")]
    public void EmptyRequiredFields_MakeModelInvalid(string fullName, string phone)
    {
        var form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = fullName,
            Phone = phone
        };

        var results = Validate(form);

        Assert.IsTrue(results.Count > 0, "модель должна быть недействительной");
    }

    // Тест 3. Проверка электронной почты.
    [DataTestMethod]
    [DataRow("abc", false)]
    [DataRow("abc@", false)]
    [DataRow("maria@mail.ru", true)]
    [DataRow(null, true)]
    public void EmailValidation_WorksAsExpected(string? email, bool expectedValid)
    {
        var form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = "Иванова Мария",
            Phone = "+7 900 000 00 00",
            Email = email
        };

        var results = Validate(form);
        var isValid = results.All(r => r.MemberNames.All(m => m != nameof(form.Email)));

        Assert.AreEqual(expectedValid, isValid);
    }

    private static List<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();
        var ctx = new ValidationContext(model);
        Validator.TryValidateObject(model, ctx, results, validateAllProperties: true);
        return results;
    }
}