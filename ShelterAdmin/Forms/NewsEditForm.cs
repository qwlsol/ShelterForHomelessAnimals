using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Models;


namespace ShelterAdmin.Forms
{
    public partial class NewsEditForm : Form
    {
        private NewsService _newsService; 
        private NewsEditViewModel _viewModel;
        public NewsEditForm(NewsService newsService, News? existingNews)
        {
            InitializeComponent();
            _newsService = newsService;
            _viewModel = new NewsEditViewModel();

            if (existingNews != null)
            {
                _viewModel.Id = existingNews.Id;
                _viewModel.Title = existingNews.Title;
                _viewModel.Content = existingNews.Content;
                _viewModel.DetailedContent = existingNews.DetailedContent ?? "";
                _viewModel.ImagePath = existingNews.ImagePath;
                _viewModel.PublishedAt = existingNews.PublishedAt;
                _viewModel.AnimalId = existingNews.AnimalId;
            }

            txtTitle.DataBindings.Add("Text", _viewModel, nameof(_viewModel.Title));
            txtContent.DataBindings.Add("Text", _viewModel, nameof(_viewModel.Content));
            txtDetailed.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DetailedContent));
            txtImagePath.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ImagePath));
            dtpPublishedAt.DataBindings.Add("Value", _viewModel, nameof(_viewModel.PublishedAt));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_viewModel.Save(_newsService))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblError.Text = _viewModel.ErrorMessage;
                lblError.Visible = true;
            }
        }
    }
}
    

