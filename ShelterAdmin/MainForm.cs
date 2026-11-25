using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Services;
using ShelterAdmin.Utils;
using ShelterApp.Data;
using ShelterAdmin.Utils;

namespace ShelterAdmin;

public partial class MainForm : Form
{
    private readonly AnimalService _animalService;

    public MainForm()
    {
        InitializeComponent();

        var optionsBuilder = new DbContextOptionsBuilder<ShelterContext>();

        //optionsBuilder.UseNpgsql("Host=192.168.1.48;Port=5432;Database=shelter_db;Username=st56-7;Password=567");
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shelter_db;Username=postgres;Password=123");

        var context = new ShelterContext(optionsBuilder.Options);
        _animalService = new AnimalService(context);

        LoadData();
    }

    private void LoadData()
    {
        try
        {
            var animals = _animalService.GetAllAnimalsForAdmin();
            dgvAnimals.DataSource = animals;
            GridConfigurator.Setup(dgvAnimals);


            lblStatus.Text = $"Всего животных в базе: {animals.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Ошибка загрузки данных";
        }
    }
}