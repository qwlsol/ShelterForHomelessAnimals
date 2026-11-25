using Microsoft.EntityFrameworkCore;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Data;


namespace ShelterAdmin.Forms
{
    public partial class NewsListForm : Form
    {
        private readonly NewsService _newsService;
        private readonly NewsListViewModel _viewModel = new();
        public NewsListForm(NewsService newsService)
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

                // Скрываем лишние колонки, если нужно
                if (dgvNews.Columns["Id"] != null) dgvNews.Columns["Id"].Visible = false;
                if (dgvNews.Columns["DetailedContent"] != null) dgvNews.Columns["DetailedContent"].Visible = false;
                if (dgvNews.Columns["Content"] != null) dgvNews.Columns["Content"].Visible = false;
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

        
    }
}