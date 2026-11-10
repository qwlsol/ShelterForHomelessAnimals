namespace ShelterApp.ViewModels
{
    public class AnimalFilterViewModel
    {
        public int? Species { get; set; }
        public int? Gender { get; set; }
        public int? Size { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public string? SearchQuery { get; set; }
    }
}
