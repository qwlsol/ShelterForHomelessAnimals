using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Forms;
using ShelterAdmin.Services;
using ShelterAdmin.Utils;
using ShelterAdmin.Utils;
using ShelterApp.Data;

namespace ShelterAdmin;

public partial class MainForm : Form
{
    private readonly AnimalService _animalService;

    public MainForm()
    {
        InitializeComponent();

        var optionsBuilder = new DbContextOptionsBuilder<ShelterContext>();

        optionsBuilder.UseNpgsql("Host=192.168.1.48;Port=5432;Database=shelter_db;Username=st56-7;Password=567");
        //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shelter_db;Username=postgres;Password=123");

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