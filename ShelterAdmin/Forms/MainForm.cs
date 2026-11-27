using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Forms;
using ShelterAdmin.Services;
using ShelterAdmin.Utils;
using ShelterAdmin.ViewModels;
using ShelterApp.Data;
using ShelterApp.Models;

namespace ShelterAdmin;

public partial class MainForm : Form
{
    private readonly IAnimalService _animalService;
    private readonly INewsService _newsService;
    private readonly NewsListViewModel _newsViewModel = new();

    public MainForm()
    {
        InitializeComponent();

        var optionsBuilder = new DbContextOptionsBuilder<ShelterContext>();
        optionsBuilder.UseNpgsql("Host=192.168.1.48;Port=5432;Database=shelter_db;Username=st56-7;Password=567");
       //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shelter_db;Username=postgres;Password=123");
        var context = new ShelterContext(optionsBuilder.Options);

        _animalService = new AnimalService(context);
        _newsService = new NewsService(context);

        LoadAnimals();
        LoadNews();
    }


    private void LoadAnimals()
    {
        try
        {
            var animals = _animalService.GetAllAnimalsForAdmin();
            dgvAnimals.DataSource = animals;
            GridConfigurator.Setup(dgvAnimals);
            dgvAnimals.Visible = true;
            errorPanelAnimals.Visible = false;
            lblStatusAnimals.Text = $"Всего животных в базе: {animals.Count}";
            lblStatusAnimals.ForeColor = Color.PaleTurquoise;
        }
        catch (Exception ex)
        {
            dgvAnimals.Visible = false;
            errorPanelAnimals.Visible = true;
            lblErrorAnimals.Text = "Не удалось подключиться к базе данных.";
            lblStatusAnimals.Text = "Статус: Нет подключения к БД";
            lblStatusAnimals.ForeColor = Color.Red;
        }
    }

    private void btnAddAnimal_Click(object sender, EventArgs e)
    {
        using var form = new AnimalEditForm(_animalService);
        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadAnimals();
        }
    }

    private void btnEditAnimal_Click(object sender, EventArgs e)
    {
        if (dgvAnimals.CurrentRow?.DataBoundItem is not Animal selectedAnimal)
        {
            MessageBox.Show("Выберите животное из таблицы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        using var form = new AnimalEditForm(_animalService, selectedAnimal);
        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadAnimals();
        }
    }

    private void btnDeleteAnimal_Click(object sender, EventArgs e)
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
            LoadAnimals();
        }
    }



    private void LoadNews()
    {
        _newsViewModel.LoadNews(_newsService);
        if (_newsViewModel.ErrorMessage != null)
        {
            dgvNews.Visible = false;
            errorPanelNews.Visible = true;
            lblErrorNews.Text = _newsViewModel.ErrorMessage;
            lblStatusNews.Text = "Статус: Нет подключения к БД";
            lblStatusNews.ForeColor = Color.Red;
        }
        else
        {
            errorPanelNews.Visible = false;
            dgvNews.Visible = true;
            dgvNews.DataSource = _newsViewModel.NewsList;

            if (dgvNews.Columns["Id"] != null) dgvNews.Columns["Id"].Visible = false;
            if (dgvNews.Columns["DetailedContent"] != null) dgvNews.Columns["DetailedContent"].Visible = false;
            if (dgvNews.Columns["Content"] != null) dgvNews.Columns["Content"].Visible = false;
            if (dgvNews.Columns["Title"] != null) dgvNews.Columns["Title"].HeaderText = "Заголовок";
            if (dgvNews.Columns["ImagePath"] != null) dgvNews.Columns["ImagePath"].HeaderText = "Картинка";
            if (dgvNews.Columns["PublishedAt"] != null)
            {
                dgvNews.Columns["PublishedAt"].HeaderText = "Дата публикации";
                dgvNews.Columns["PublishedAt"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
            if (dgvNews.Columns["AnimalID"] != null) dgvNews.Columns["AnimalID"].HeaderText = "ID животного";

            lblStatusNews.Text = $"Всего новостей: {_newsViewModel.NewsList.Count}";
            lblStatusNews.ForeColor = Color.PaleTurquoise;
        }
    }

    private void btnRefreshNews_Click(object sender, EventArgs e) => LoadNews();

    private void btnAddNews_Click(object sender, EventArgs e)
    {
        var editForm = new NewsEditForm(_newsService, null);
        if (editForm.ShowDialog() == DialogResult.OK)
            LoadNews();
    }

    private void btnEditNews_Click(object sender, EventArgs e)
    {
        if (dgvNews.CurrentRow?.DataBoundItem is News selected)
        {
            var editForm = new NewsEditForm(_newsService, selected);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadNews();
        }
    }

    private void btnDeleteNews_Click(object sender, EventArgs e)
    {
        if (dgvNews.CurrentRow?.DataBoundItem is News selected)
        {
            _newsViewModel.SelectedNews = selected;
            _newsViewModel.DeleteSelectedNews(_newsService);
            if (_newsViewModel.ErrorMessage != null)
            {
                dgvNews.Visible = false;
                errorPanelNews.Visible = true;
                lblErrorNews.Text = _newsViewModel.ErrorMessage;
            }
            else
            {
                LoadNews();
            }
        }
    }

}