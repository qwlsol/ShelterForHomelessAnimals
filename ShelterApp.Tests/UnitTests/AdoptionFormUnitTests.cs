using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using ShelterApp.Models;
using ShelterApp.ViewModels;
using Xunit;

namespace ShelterApp.Tests.UnitTests;

public class AdoptionFormUnitTests
{
    // Тест 1 формирование модели заявки
    [Fact]
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
        var request = new AdoptionRequest { AnimalId = form.AnimalId };

        adopter.FullName.Should().Be("Иванова Мария");
        adopter.Phone.Should().Be("+7 900 000 00 00");
        adopter.Email.Should().Be("maria@mail.ru");
        request.AnimalId.Should().Be(5);
        request.Status.Should().Be(0); // на рассмотрении
    }

    // Тест 2 проверка обязательных полей
    [Theory]
    [InlineData("", "+7 900 000 00 00")]      // пустое ФИО
    [InlineData("Иванова Мария", "")]         // пустой телефон
    [InlineData("", "")]                      // оба пустые
    public void EmptyRequiredFields_MakeModelInvalid(string fullName, string phone)
    {
        var form = new AdoptionFormViewModel
        {
            AnimalId = 1,
            FullName = fullName,
            Phone = phone
        };

        var results = Validate(form);

        results.Should().Contain(r => r.MemberNames.Contains(nameof(form.FullName)) || r.MemberNames.Contains(nameof(form.Phone)));
    }

    // Тест 3 проверка электронной почты
    [Theory]
    [InlineData("abc", false)]                 // некорректный email
    [InlineData("abc@", false)]                // некорректный email
    [InlineData("maria@mail.ru", true)]        // корректный email
    [InlineData(null, true)]                   // отсутствует — допустимо
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

        isValid.Should().Be(expectedValid);
    }

    private static List<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();
        var ctx = new ValidationContext(model);
        Validator.TryValidateObject(model, ctx, results, validateAllProperties: true);
        return results;
    }
}