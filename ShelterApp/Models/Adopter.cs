using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterApp.Models;

[Table("adopters")]
public class Adopter
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("full_name")][Required, MaxLength(150)] public string FullName { get; set; } = "";
    [Column("phone")][Required, MaxLength(20)] public string Phone { get; set; } = "";
    [Column("email")][MaxLength(100)] public string? Email { get; set; }
}