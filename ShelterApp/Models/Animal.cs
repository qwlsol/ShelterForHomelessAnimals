using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterApp.Models;

[Table("animals")]
public class Animal
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("name")][Required, MaxLength(50)] public string Name { get; set; } = "";
    [Column("species")] public int Species { get; set; }
    [Column("breed")][MaxLength(100)] public string Breed { get; set; } = "метис";
    [Column("gender")] public int Gender { get; set; }
    [Column("age")] public int Age { get; set; }
    [Column("size")] public int Size { get; set; }
    [Column("description")] public string? Description { get; set; }
    [Column("health_info")] public string? HealthInfo { get; set; }
    [Column("status")] public int Status { get; set; }
    [Column("arrival_date")] public DateTime ArrivalDate { get; set; }

    public List<Photo> Photos { get; set; } = new();

    [NotMapped] public string SpeciesText => Species == 0 ? "Собака" : "Кошка";
    [NotMapped] public string GenderText => Gender == 0 ? "Мальчик" : "Девочка";
    [NotMapped] public string SizeText => Size switch { 0 => "Маленький", 1 => "Средний", _ => "Крупный" };
    [NotMapped] public string AgeText => Age < 12 ? $"{Age} мес." : $"{Age / 12} г. {Age % 12} мес.";
    [NotMapped] public string? MainPhoto => Photos.FirstOrDefault(p => p.IsMain)?.FilePath ?? Photos.FirstOrDefault()?.FilePath;
}

[Table("photos")]
public class Photo
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("animal_id")] public int AnimalId { get; set; }
    [Column("file_path")] public string FilePath { get; set; } = "";
    [Column("is_main")] public bool IsMain { get; set; }
    public Animal? Animal { get; set; }
}

[Table("adopters")]
public class Adopter
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("full_name")] public string FullName { get; set; } = "";
    [Column("phone")] public string Phone { get; set; } = "";
    [Column("email")] public string? Email { get; set; }
    [Column("comment")] public string? Comment { get; set; }
}

[Table("applications")]
public class Application
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("animal_id")] public int AnimalId { get; set; }
    [Column("adopter_id")] public int AdopterId { get; set; }
    [Column("application_date")] public DateTime ApplicationDate { get; set; }
    [Column("status")] public int Status { get; set; }
    [Column("admin_comment")] public string? AdminComment { get; set; }
}