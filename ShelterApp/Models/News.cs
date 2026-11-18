using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShelterApp.Models;

[Table("news")]
public class News
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("title")][Required, MaxLength(150)] public string Title { get; set; } = "";
    [Column("content")][Required] public string Content { get; set; } = "";
    [Column("image_path")] public string? ImagePath { get; set; }
    [Column("published_at")] public DateTime PublishedAt { get; set; }
    [Column("animal_id")] public int? AnimalId { get; set; }
}