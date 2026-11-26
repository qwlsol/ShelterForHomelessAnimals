using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShelterAdmin.Services;
using ShelterAdmin.ViewModels;
using ShelterApp.Models;

namespace ShelterAdmin.Forms
{
    public partial class AnimalEditForm : Form
    {
        private readonly IAnimalService _service;
        private readonly AnimalEditViewModel _viewModel;
        private readonly bool _isEditMode;

        public AnimalEditForm(IAnimalService service, Animal animal = null)
        {
            _service = service;
            _isEditMode = animal != null;

            InitializeComponent();
            if (_isEditMode)
            {
                this.Text = "Редактирование животного";
                lblCRUD.Text = "Редактирование животного";
                _viewModel = new AnimalEditViewModel
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Species = animal.Species,
                    Breed = animal.Breed,
                    Gender = animal.Gender,
                    Age = animal.Age < 1 ? 1 : animal.Age,
                    Size = animal.Size,
                    Status = animal.Status,
                    ArrivalDate = animal.ArrivalDate,
                    Description = animal.Description,
                    HealthInfo = animal.HealthInfo
                };
                FillForm();
            }
            else
            {
                this.Text = "Добавление животного";
                lblCRUD.Text = "Добавление животного";
                _viewModel = new AnimalEditViewModel
                {
                    ArrivalDate = DateTime.Now,
                    Status = 0
                };
                dtpArrivalDate.Value = DateTime.Now;
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void FillForm()
        {
            txtName.Text = _viewModel.Name;
            cmbSpecies.SelectedIndex = _viewModel.Species;
            txtBreed.Text = _viewModel.Breed;
            cmbGender.SelectedIndex = _viewModel.Gender;
            numAge.Value = _viewModel.Age;
            cmbSize.SelectedIndex = _viewModel.Size;
            cmbStatus.SelectedIndex = _viewModel.Status;
            dtpArrivalDate.Value = _viewModel.ArrivalDate;
            txtDescription.Text = _viewModel.Description;
            txtHealthInfo.Text = _viewModel.HealthInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Кличка обязательна!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numAge.Value <= 0)
            {
                MessageBox.Show("Возраст должен быть больше 0!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSpecies.SelectedIndex == -1 ||
                cmbGender.SelectedIndex == -1 ||
                cmbSize.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите значения во всех выпадающих списках (Вид, Пол, Размер, Статус)!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _viewModel.Name = txtName.Text;
            _viewModel.Species = cmbSpecies.SelectedIndex;
            _viewModel.Breed = txtBreed.Text;
            _viewModel.Gender = cmbGender.SelectedIndex;
            _viewModel.Age = (int)numAge.Value;
            _viewModel.Size = cmbSize.SelectedIndex;
            _viewModel.Status = cmbStatus.SelectedIndex;
            _viewModel.ArrivalDate = dtpArrivalDate.Value;
            _viewModel.Description = txtDescription.Text;
            _viewModel.HealthInfo = txtHealthInfo.Text;

            if (_isEditMode)
                _service.UpdateAnimal(_viewModel);
            else
                _service.AddAnimal(_viewModel);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}