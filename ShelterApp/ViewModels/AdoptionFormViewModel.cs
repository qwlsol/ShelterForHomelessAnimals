using System.ComponentModel.DataAnnotations;

namespace ShelterApp.ViewModels;

public class AdoptionFormViewModel
{
    public int AnimalId { get; set; }
    public string AnimalName { get; set; } = "";
    public string? AnimalPhotoPath { get; set; }

    [Required(ErrorMessage = "Укажите ФИО")]
    [MaxLength(150)]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Укажите телефон")]
    [MaxLength(20)]
    public string Phone { get; set; } = "";

    [EmailAddress(ErrorMessage = "Некорректный email")]
    [MaxLength(100)]
    public string? Email { get; set; }
}