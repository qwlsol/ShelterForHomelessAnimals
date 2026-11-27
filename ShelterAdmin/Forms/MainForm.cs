using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Forms;
using ShelterAdmin.Services;
using ShelterAdmin.Utils;
using ShelterApp.Data;
using ShelterApp.Models;
using ShelterAdmin.Utils;
using ShelterApp.Data;

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

            lblStatus.Text = $"Âñåãî æèâîòíûõ â áàçå: {animals.Count}";
        }
        catch (Exception ex)
        {
            dgvAnimals.Visible = false;
            errorPanel.Visible = true;
            lblStatus.Text = "Ñòàòóñ: Íåò ïîäêëþ÷åíèÿ ê ÁÄ";
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
            MessageBox.Show("Âûáåðèòå æèâîòíîå èç òàáëèöû.", "Âíèìàíèå", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Âûáåðèòå æèâîòíîå èç òàáëèöû.", "Âíèìàíèå", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = MessageBox.Show($"Âû óâåðåíû, ÷òî õîòèòå óäàëèòü {selectedAnimal.Name}?",
                                     "Ïîäòâåðæäåíèå óäàëåíèÿ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            _animalService.DeleteAnimal(selectedAnimal.Id);
            LoadData();
        }
    private void btnNews_Click(object sender, EventArgs e)
    {
        DbContextOptionsBuilder<ShelterContext> optionsBuilder = new DbContextOptionsBuilder<ShelterContext>();
        //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shelter_db;Username=postgres;Password=123");
        optionsBuilder.UseNpgsql("Host=192.168.1.48;Port=5432;Database=shelter_db;Username=st56-7;Password=567");

        ShelterContext context = new ShelterContext(optionsBuilder.Options);
        NewsService newsService = new NewsService(context);

        NewsListForm newsForm = new NewsListForm(newsService);
        newsForm.ShowDialog();
    }
}