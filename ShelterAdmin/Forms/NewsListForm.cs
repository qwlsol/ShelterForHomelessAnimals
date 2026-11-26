using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Data;


namespace ShelterAdmin.Forms
{
    public partial class NewsListForm : Form
    {
        private readonly INewsService _newsService;
        private readonly NewsListViewModel _viewModel = new();
        public NewsListForm(INewsService newsService)
        {
            InitializeComponent();
            _newsService = newsService;

            LoadData();
        }
        private void LoadData()
        {
            _viewModel.LoadNews(_newsService);

            if (_viewModel.ErrorMessage != null)
            {
                dgvNews.Visible = false;
                errorPanel.Visible = true;
                lblError.Text = _viewModel.ErrorMessage;
            }
            else
            {
                errorPanel.Visible = false;
                dgvNews.Visible = true;
                dgvNews.DataSource = _viewModel.NewsList;

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
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNews.CurrentRow?.DataBoundItem is ShelterApp.Models.News selected)
            {
                _viewModel.SelectedNews = selected;
                _viewModel.DeleteSelectedNews(_newsService);

                if (_viewModel.ErrorMessage != null)
                {
                    dgvNews.Visible = false;
                    errorPanel.Visible = true;
                    lblError.Text = _viewModel.ErrorMessage;
                }
                else
                {
                    LoadData();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new NewsEditForm(_newsService, null);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNews.CurrentRow?.DataBoundItem is ShelterApp.Models.News selected)
            {
                var editForm = new NewsEditForm(_newsService, selected);
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }

        }
    }
}