namespace ShelterAdmin.Forms
{
    partial class NewsListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvNews;
        private Panel topPanel;
        private Button btnAdd, btnEdit, btnDelete, btnRefresh;
        private Panel errorPanel;
        private Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvNews = new DataGridView();
            this.topPanel = new Panel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.errorPanel = new Panel();
            this.lblError = new Label();

            // Настройка таблицы
            this.dgvNews.Dock = DockStyle.Fill;
            this.dgvNews.ReadOnly = true;
            this.dgvNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNews.BackgroundColor = SystemColors.GradientInactiveCaption;
            this.dgvNews.AllowUserToAddRows = false;

            // Настройка верхней панели с кнопками
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Height = 50;
            this.topPanel.BackColor = SystemColors.ControlLight;

            // Настройка кнопок
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new Point(10, 10);
            this.btnAdd.Size = new Size(100, 30);
            //this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Location = new Point(120, 10);
            this.btnEdit.Size = new Size(100, 30);
            //this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new Point(230, 10);
            this.btnDelete.Size = new Size(100, 30);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Location = new Point(340, 10);
            this.btnRefresh.Size = new Size(100, 30);
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Добавляем кнопки на панель
            this.topPanel.Controls.Add(this.btnAdd);
            this.topPanel.Controls.Add(this.btnEdit);
            this.topPanel.Controls.Add(this.btnDelete);
            this.topPanel.Controls.Add(this.btnRefresh);

            // Настройка панели ошибки
            this.errorPanel.Dock = DockStyle.Fill;
            this.errorPanel.BackColor = Color.MistyRose;
            this.errorPanel.Visible = false;

            this.lblError.Dock = DockStyle.Fill;
            this.lblError.Text = "Ошибка";
            this.lblError.ForeColor = Color.Firebrick;
            this.lblError.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblError.TextAlign = ContentAlignment.MiddleCenter;

            this.errorPanel.Controls.Add(this.lblError);

            // Настройка самой формы
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dgvNews);
            this.Controls.Add(this.errorPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "NewsListForm";
            this.Text = "Управление новостями";
            this.StartPosition = FormStartPosition.CenterParent;
        }

        #endregion
    }
}