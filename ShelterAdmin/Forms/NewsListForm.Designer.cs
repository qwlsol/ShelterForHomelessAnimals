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
            dgvNews = new DataGridView();
            topPanel = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            errorPanel = new Panel();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNews).BeginInit();
            topPanel.SuspendLayout();
            errorPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dgvNews
            // 
            dgvNews.AllowUserToAddRows = false;
            dgvNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNews.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvNews.Dock = DockStyle.Fill;
            dgvNews.Location = new Point(0, 50);
            dgvNews.Name = "dgvNews";
            dgvNews.ReadOnly = true;
            dgvNews.Size = new Size(800, 400);
            dgvNews.TabIndex = 0;
            // 
            // topPanel
            // 
            topPanel.BackColor = SystemColors.ControlLight;
            topPanel.Controls.Add(btnAdd);
            topPanel.Controls.Add(btnEdit);
            topPanel.Controls.Add(btnDelete);
            topPanel.Controls.Add(btnRefresh);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(800, 50);
            topPanel.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Добавить";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(120, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Редактировать";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(230, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(340, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // errorPanel
            // 
            errorPanel.BackColor = Color.MistyRose;
            errorPanel.Controls.Add(lblError);
            errorPanel.Dock = DockStyle.Fill;
            errorPanel.Location = new Point(0, 50);
            errorPanel.Name = "errorPanel";
            errorPanel.Size = new Size(800, 400);
            errorPanel.TabIndex = 1;
            errorPanel.Visible = false;
            // 
            // lblError
            // 
            lblError.Dock = DockStyle.Fill;
            lblError.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(0, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(800, 400);
            lblError.TabIndex = 0;
            lblError.Text = "Ошибка";
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NewsListForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(dgvNews);
            Controls.Add(errorPanel);
            Controls.Add(topPanel);
            Name = "NewsListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление новостями";
            ((System.ComponentModel.ISupportInitialize)dgvNews).EndInit();
            topPanel.ResumeLayout(false);
            errorPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}