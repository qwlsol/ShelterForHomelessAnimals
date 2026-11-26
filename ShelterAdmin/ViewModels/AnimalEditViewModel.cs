namespace ShelterAdmin.ViewModels;

public class AnimalEditViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Species { get; set; }
    public string Breed { get; set; } = "";
    public int Gender { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
    public int Status { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string? Description { get; set; }
    public string? HealthInfo { get; set; }
}