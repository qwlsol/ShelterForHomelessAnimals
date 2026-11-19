using Microsoft.EntityFrameworkCore;
using ShelterApp.Data;

namespace ShelterAdmin;

public partial class MainForm : Form
{
    private readonly ShelterContext _context;

    public MainForm()
    {
        InitializeComponent();

        var optionsBuilder = new DbContextOptionsBuilder<ShelterContext>();

        //optionsBuilder.UseNpgsql("Host=192.168.1.48;Port=5432;Database=shelter_db;Username=st56-7;Password=567");
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shelter_db;Username=postgres;Password=123");

        _context = new ShelterContext(optionsBuilder.Options);

        LoadData();
    }

    private void LoadData()
    {
        try
        {
            var animals = _context.Animals
                .OrderByDescending(a => a.ArrivalDate)
                .ToList();

            dgvAnimals.DataSource = animals;

            ConfigureColumns();
            lblStatus.Text = $"Всего животных в базе: {animals.Count}";
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Не удалось подключиться к базе данных.\n\nДетали: {ex.Message}",
                "Ошибка подключения",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            lblStatus.Text = "Ошибка загрузки данных";
        }
    }

    private void ConfigureColumns()
    {
        string[] hiddenColumns = {
            "Id", "Description", "HealthInfo", "Photos",
            "Species", "Gender", "Size", "Status",
            "MainPhoto", "StatusBadgeClass", "Age"
        };

        foreach (var colName in hiddenColumns)
        {
            if (dgvAnimals.Columns[colName] != null)
            {
                dgvAnimals.Columns[colName].Visible = false;
            }
        }

        if (dgvAnimals.Columns["Name"] != null) dgvAnimals.Columns["Name"].HeaderText = "Кличка";
        if (dgvAnimals.Columns["SpeciesText"] != null) dgvAnimals.Columns["SpeciesText"].HeaderText = "Вид";
        if (dgvAnimals.Columns["Breed"] != null) dgvAnimals.Columns["Breed"].HeaderText = "Порода";
        if (dgvAnimals.Columns["GenderText"] != null) dgvAnimals.Columns["GenderText"].HeaderText = "Пол";
        if (dgvAnimals.Columns["AgeText"] != null) dgvAnimals.Columns["AgeText"].HeaderText = "Возраст";
        if (dgvAnimals.Columns["SizeText"] != null) dgvAnimals.Columns["SizeText"].HeaderText = "Размер";
        if (dgvAnimals.Columns["StatusText"] != null) dgvAnimals.Columns["StatusText"].HeaderText = "Статус";
        if (dgvAnimals.Columns["ArrivalDate"] != null)
        {
            dgvAnimals.Columns["ArrivalDate"].HeaderText = "Дата поступления";
            dgvAnimals.Columns["ArrivalDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }
    }
}