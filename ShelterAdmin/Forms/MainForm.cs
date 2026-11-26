using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Forms;
using ShelterAdmin.Services;
using ShelterAdmin.Utils;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterAdmin;

public partial class MainForm : Form
{
    private readonly IAnimalService _animalService;

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

            dgvAnimals.Visible = true;
            errorPanel.Visible = false;

            lblStatus.Text = $"Всего животных в базе: {animals.Count}";
        }
        catch (Exception ex)
        {
            dgvAnimals.Visible = false;
            errorPanel.Visible = true;
            lblStatus.Text = "Статус: Нет подключения к БД";
            lblStatus.ForeColor = Color.Red;
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using var form = new AnimalEditForm(_animalService);
        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvAnimals.CurrentRow?.DataBoundItem is not Animal selectedAnimal)
        {
            MessageBox.Show("Выберите животное из таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var form = new AnimalEditForm(_animalService, selectedAnimal);
        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvAnimals.CurrentRow?.DataBoundItem is not Animal selectedAnimal)
        {
            MessageBox.Show("Выберите животное из таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show($"Вы уверены, что хотите удалить {selectedAnimal.Name}?",
                                     "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            _animalService.DeleteAnimal(selectedAnimal.Id);
            LoadData();
        }
    }
}