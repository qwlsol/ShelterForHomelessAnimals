using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterApp.Models;

[Table("adoption_request")]
public class AdoptionRequest
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("animal_id")] public int AnimalId { get; set; }
    [Column("adopter_id")] public int AdopterId { get; set; }
    [Column("application_date")] public DateTime ApplicationDate { get; set; }
    [Column("status")] public int Status { get; set; } = 0; // «на рассмотрении»
    [Column("admin_comment")] public string? AdminComment { get; set; }
}