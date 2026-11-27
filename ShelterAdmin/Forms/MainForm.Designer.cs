namespace ShelterAdmin
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            label1 = new Label();
            tabControl = new TabControl();
            tabAnimals = new TabPage();
            errorPanelAnimals = new Panel();
            lblErrorAnimals = new Label();
            StatusPanelAnimals = new Panel();
            lblStatusAnimals = new Label();
            dgvAnimals = new DataGridView();
            toolPanelAnimals = new Panel();
            btnDeleteAnimal = new Button();
            btnEditAnimal = new Button();
            btnAddAnimal = new Button();
            tabNews = new TabPage();
            errorPanelNews = new Panel();
            lblErrorNews = new Label();
            StatusPanelNews = new Panel();
            lblStatusNews = new Label();
            dgvNews = new DataGridView();
            toolPanelNews = new Panel();
            btnRefreshNews = new Button();
            btnDeleteNews = new Button();
            btnEditNews = new Button();
            btnAddNews = new Button();
            headerPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabAnimals.SuspendLayout();
            errorPanelAnimals.SuspendLayout();
            StatusPanelAnimals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            toolPanelAnimals.SuspendLayout();
            tabNews.SuspendLayout();
            errorPanelNews.SuspendLayout();
            StatusPanelNews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNews).BeginInit();
            toolPanelNews.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.SteelBlue;
            headerPanel.Controls.Add(label1);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1000, 60);
            headerPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1000, 60);
            label1.TabIndex = 0;
            label1.Text = "Админ-панель приюта «Шанс на жизнь»";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabAnimals);
            tabControl.Controls.Add(tabNews);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 60);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1000, 540);
            tabControl.TabIndex = 2;
            // 
            // tabAnimals
            // 
            tabAnimals.Controls.Add(errorPanelAnimals);
            tabAnimals.Controls.Add(StatusPanelAnimals);
            tabAnimals.Controls.Add(dgvAnimals);
            tabAnimals.Controls.Add(toolPanelAnimals);
            tabAnimals.Location = new Point(4, 24);
            tabAnimals.Name = "tabAnimals";
            tabAnimals.Padding = new Padding(3);
            tabAnimals.Size = new Size(992, 512);
            tabAnimals.TabIndex = 0;
            tabAnimals.Text = "Животные";
            tabAnimals.UseVisualStyleBackColor = true;
            // 
            // errorPanelAnimals
            // 
            errorPanelAnimals.BackColor = Color.MistyRose;
            errorPanelAnimals.Controls.Add(lblErrorAnimals);
            errorPanelAnimals.Dock = DockStyle.Fill;
            errorPanelAnimals.Location = new Point(3, 67);
            errorPanelAnimals.Name = "errorPanelAnimals";
            errorPanelAnimals.Size = new Size(986, 398);
            errorPanelAnimals.TabIndex = 3;
            errorPanelAnimals.Visible = false;
            // 
            // lblErrorAnimals
            // 
            lblErrorAnimals.AutoSize = true;
            lblErrorAnimals.Dock = DockStyle.Fill;
            lblErrorAnimals.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblErrorAnimals.ForeColor = Color.Firebrick;
            lblErrorAnimals.Location = new Point(0, 0);
            lblErrorAnimals.Name = "lblErrorAnimals";
            lblErrorAnimals.Size = new Size(487, 32);
            lblErrorAnimals.TabIndex = 0;
            lblErrorAnimals.Text = "Не удалось подключиться к базе данных.";
            lblErrorAnimals.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatusPanelAnimals
            // 
            StatusPanelAnimals.BackColor = Color.SteelBlue;
            StatusPanelAnimals.BorderStyle = BorderStyle.FixedSingle;
            StatusPanelAnimals.Controls.Add(lblStatusAnimals);
            StatusPanelAnimals.Dock = DockStyle.Bottom;
            StatusPanelAnimals.Location = new Point(3, 465);
            StatusPanelAnimals.Name = "StatusPanelAnimals";
            StatusPanelAnimals.Size = new Size(986, 44);
            StatusPanelAnimals.TabIndex = 0;
            // 
            // lblStatusAnimals
            // 
            lblStatusAnimals.Dock = DockStyle.Left;
            lblStatusAnimals.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStatusAnimals.ForeColor = Color.PaleTurquoise;
            lblStatusAnimals.Location = new Point(0, 0);
            lblStatusAnimals.Name = "lblStatusAnimals";
            lblStatusAnimals.Padding = new Padding(10, 0, 0, 0);
            lblStatusAnimals.Size = new Size(300, 42);
            lblStatusAnimals.TabIndex = 0;
            lblStatusAnimals.Text = "Всего животных в базе: 0";
            lblStatusAnimals.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvAnimals
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dgvAnimals.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimals.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvAnimals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Navy;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAnimals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAnimals.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAnimals.Dock = DockStyle.Fill;
            dgvAnimals.GridColor = Color.Gainsboro;
            dgvAnimals.Location = new Point(3, 67);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.ReadOnly = true;
            dgvAnimals.RowTemplate.Height = 30;
            dgvAnimals.Size = new Size(986, 442);
            dgvAnimals.TabIndex = 2;
            // 
            // toolPanelAnimals
            // 
            toolPanelAnimals.BackColor = SystemColors.GradientActiveCaption;
            toolPanelAnimals.Controls.Add(btnDeleteAnimal);
            toolPanelAnimals.Controls.Add(btnEditAnimal);
            toolPanelAnimals.Controls.Add(btnAddAnimal);
            toolPanelAnimals.Dock = DockStyle.Top;
            toolPanelAnimals.Location = new Point(3, 3);
            toolPanelAnimals.Name = "toolPanelAnimals";
            toolPanelAnimals.Size = new Size(986, 64);
            toolPanelAnimals.TabIndex = 4;
            // 
            // btnDeleteAnimal
            // 
            btnDeleteAnimal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteAnimal.Font = new Font("Segoe UI", 12F);
            btnDeleteAnimal.Location = new Point(840, 15);
            btnDeleteAnimal.Name = "btnDeleteAnimal";
            btnDeleteAnimal.Size = new Size(134, 33);
            btnDeleteAnimal.TabIndex = 2;
            btnDeleteAnimal.Text = "Удалить";
            btnDeleteAnimal.UseVisualStyleBackColor = true;
            btnDeleteAnimal.Click += btnDeleteAnimal_Click;
            // 
            // btnEditAnimal
            // 
            btnEditAnimal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditAnimal.Font = new Font("Segoe UI", 12F);
            btnEditAnimal.Location = new Point(700, 15);
            btnEditAnimal.Name = "btnEditAnimal";
            btnEditAnimal.Size = new Size(134, 33);
            btnEditAnimal.TabIndex = 1;
            btnEditAnimal.Text = "Редактировать";
            btnEditAnimal.UseVisualStyleBackColor = true;
            btnEditAnimal.Click += btnEditAnimal_Click;
            // 
            // btnAddAnimal
            // 
            btnAddAnimal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddAnimal.Font = new Font("Segoe UI", 12F);
            btnAddAnimal.Location = new Point(560, 15);
            btnAddAnimal.Name = "btnAddAnimal";
            btnAddAnimal.Size = new Size(134, 33);
            btnAddAnimal.TabIndex = 0;
            btnAddAnimal.Text = "Добавить";
            btnAddAnimal.UseVisualStyleBackColor = true;
            btnAddAnimal.Click += btnAddAnimal_Click;
            // 
            // tabNews
            // 
            tabNews.Controls.Add(errorPanelNews);
            tabNews.Controls.Add(StatusPanelNews);
            tabNews.Controls.Add(dgvNews);
            tabNews.Controls.Add(toolPanelNews);
            tabNews.Location = new Point(4, 24);
            tabNews.Name = "tabNews";
            tabNews.Padding = new Padding(3);
            tabNews.Size = new Size(992, 512);
            tabNews.TabIndex = 1;
            tabNews.Text = "Новости";
            tabNews.UseVisualStyleBackColor = true;
            // 
            // errorPanelNews
            // 
            errorPanelNews.BackColor = Color.MistyRose;
            errorPanelNews.Controls.Add(lblErrorNews);
            errorPanelNews.Dock = DockStyle.Fill;
            errorPanelNews.Location = new Point(3, 67);
            errorPanelNews.Name = "errorPanelNews";
            errorPanelNews.Size = new Size(986, 398);
            errorPanelNews.TabIndex = 3;
            errorPanelNews.Visible = false;
            // 
            // lblErrorNews
            // 
            lblErrorNews.AutoSize = true;
            lblErrorNews.Dock = DockStyle.Fill;
            lblErrorNews.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblErrorNews.ForeColor = Color.Firebrick;
            lblErrorNews.Location = new Point(0, 0);
            lblErrorNews.Name = "lblErrorNews";
            lblErrorNews.Size = new Size(358, 32);
            lblErrorNews.TabIndex = 0;
            lblErrorNews.Text = "Не удалось загрузить новости.";
            lblErrorNews.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatusPanelNews
            // 
            StatusPanelNews.BackColor = Color.SteelBlue;
            StatusPanelNews.BorderStyle = BorderStyle.FixedSingle;
            StatusPanelNews.Controls.Add(lblStatusNews);
            StatusPanelNews.Dock = DockStyle.Bottom;
            StatusPanelNews.Location = new Point(3, 465);
            StatusPanelNews.Name = "StatusPanelNews";
            StatusPanelNews.Size = new Size(986, 44);
            StatusPanelNews.TabIndex = 0;
            // 
            // lblStatusNews
            // 
            lblStatusNews.Dock = DockStyle.Left;
            lblStatusNews.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStatusNews.ForeColor = Color.PaleTurquoise;
            lblStatusNews.Location = new Point(0, 0);
            lblStatusNews.Name = "lblStatusNews";
            lblStatusNews.Padding = new Padding(10, 0, 0, 0);
            lblStatusNews.Size = new Size(300, 42);
            lblStatusNews.TabIndex = 0;
            lblStatusNews.Text = "Всего новостей: 0";
            lblStatusNews.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvNews
            // 
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dgvNews.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNews.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvNews.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Navy;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvNews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvNews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvNews.DefaultCellStyle = dataGridViewCellStyle6;
            dgvNews.Dock = DockStyle.Fill;
            dgvNews.GridColor = Color.Gainsboro;
            dgvNews.Location = new Point(3, 67);
            dgvNews.Name = "dgvNews";
            dgvNews.ReadOnly = true;
            dgvNews.RowTemplate.Height = 30;
            dgvNews.Size = new Size(986, 442);
            dgvNews.TabIndex = 2;
            // 
            // toolPanelNews
            // 
            toolPanelNews.BackColor = SystemColors.GradientActiveCaption;
            toolPanelNews.Controls.Add(btnRefreshNews);
            toolPanelNews.Controls.Add(btnDeleteNews);
            toolPanelNews.Controls.Add(btnEditNews);
            toolPanelNews.Controls.Add(btnAddNews);
            toolPanelNews.Dock = DockStyle.Top;
            toolPanelNews.Location = new Point(3, 3);
            toolPanelNews.Name = "toolPanelNews";
            toolPanelNews.Size = new Size(986, 64);
            toolPanelNews.TabIndex = 4;
            // 
            // btnRefreshNews
            // 
            btnRefreshNews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshNews.Font = new Font("Segoe UI", 12F);
            btnRefreshNews.Location = new Point(840, 15);
            btnRefreshNews.Name = "btnRefreshNews";
            btnRefreshNews.Size = new Size(134, 33);
            btnRefreshNews.TabIndex = 3;
            btnRefreshNews.Text = "Обновить";
            btnRefreshNews.UseVisualStyleBackColor = true;
            btnRefreshNews.Click += btnRefreshNews_Click;
            // 
            // btnDeleteNews
            // 
            btnDeleteNews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteNews.Font = new Font("Segoe UI", 12F);
            btnDeleteNews.Location = new Point(700, 15);
            btnDeleteNews.Name = "btnDeleteNews";
            btnDeleteNews.Size = new Size(134, 33);
            btnDeleteNews.TabIndex = 2;
            btnDeleteNews.Text = "Удалить";
            btnDeleteNews.UseVisualStyleBackColor = true;
            btnDeleteNews.Click += btnDeleteNews_Click;
            // 
            // btnEditNews
            // 
            btnEditNews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditNews.Font = new Font("Segoe UI", 12F);
            btnEditNews.Location = new Point(560, 15);
            btnEditNews.Name = "btnEditNews";
            btnEditNews.Size = new Size(134, 33);
            btnEditNews.TabIndex = 1;
            btnEditNews.Text = "Редактировать";
            btnEditNews.UseVisualStyleBackColor = true;
            btnEditNews.Click += btnEditNews_Click;
            // 
            // btnAddNews
            // 
            btnAddNews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNews.Font = new Font("Segoe UI", 12F);
            btnAddNews.Location = new Point(420, 15);
            btnAddNews.Name = "btnAddNews";
            btnAddNews.Size = new Size(134, 33);
            btnAddNews.TabIndex = 0;
            btnAddNews.Text = "Добавить";
            btnAddNews.UseVisualStyleBackColor = true;
            btnAddNews.Click += btnAddNews_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(tabControl);
            Controls.Add(headerPanel);
            Name = "MainForm";
            Text = "Админ-панель приюта \"Шанс на жизнь\"";
            WindowState = FormWindowState.Maximized;
            headerPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabAnimals.ResumeLayout(false);
            errorPanelAnimals.ResumeLayout(false);
            errorPanelAnimals.PerformLayout();
            StatusPanelAnimals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            toolPanelAnimals.ResumeLayout(false);
            tabNews.ResumeLayout(false);
            errorPanelNews.ResumeLayout(false);
            errorPanelNews.PerformLayout();
            StatusPanelNews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNews).EndInit();
            toolPanelNews.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Label label1;
        private TabControl tabControl;
        private TabPage tabAnimals;
        private TabPage tabNews;

        // Элементы вкладки "Животные"
        private DataGridView dgvAnimals;
        private Panel errorPanelAnimals;
        private Label lblErrorAnimals;
        private Panel toolPanelAnimals;
        private Button btnDeleteAnimal;
        private Button btnEditAnimal;
        private Button btnAddAnimal;
        private Panel StatusPanelAnimals;
        private Label lblStatusAnimals;

        // Элементы вкладки "Новости"
        private DataGridView dgvNews;
        private Panel errorPanelNews;
        private Label lblErrorNews;
        private Panel toolPanelNews;
        private Button btnDeleteNews;
        private Button btnEditNews;
        private Button btnAddNews;
        private Button btnRefreshNews;
        private Panel StatusPanelNews;
        private Label lblStatusNews;
    }
}