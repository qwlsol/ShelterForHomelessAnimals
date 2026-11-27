namespace ShelterAdmin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            StatusPanel = new Panel();
            lblStatus = new Label();
            btnNews = new Button();
            headerPanel = new Panel();
            label1 = new Label();
            dgvAnimals = new DataGridView();
            errorPanel = new Panel();
            lblError = new Label();
            StatusPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            errorPanel.SuspendLayout();
            SuspendLayout();
            // 
            // StatusPanel
            // 
            StatusPanel.BackColor = Color.SteelBlue;
            StatusPanel.BorderStyle = BorderStyle.FixedSingle;
            StatusPanel.Controls.Add(lblStatus);
            StatusPanel.Controls.Add(btnNews);
            StatusPanel.Dock = DockStyle.Bottom;
            StatusPanel.Location = new Point(0, 406);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Size = new Size(800, 44);
            StatusPanel.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Left;
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStatus.ForeColor = Color.PaleTurquoise;
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(10, 0, 0, 0);
            lblStatus.Size = new Size(203, 42);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Всего животных в базе: 0";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNews
            // 
            btnNews.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNews.BackColor = Color.SteelBlue;
            btnNews.ForeColor = SystemColors.ButtonFace;
            btnNews.Location = new Point(629, 5);
            btnNews.Name = "btnNews";
            btnNews.Size = new Size(158, 31);
            btnNews.TabIndex = 1;
            btnNews.Text = "Управление новостями";
            btnNews.UseVisualStyleBackColor = false;
            btnNews.Click += btnNews_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.SteelBlue;
            headerPanel.Controls.Add(label1);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(800, 60);
            headerPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 60);
            label1.TabIndex = 0;
            label1.Text = "База животных приюта «Шанс на жизнь»";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            dgvAnimals.Location = new Point(0, 60);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.ReadOnly = true;
            dgvAnimals.RowTemplate.Height = 30;
            dgvAnimals.Size = new Size(800, 346);
            dgvAnimals.TabIndex = 2;
            // 
            // errorPanel
            // 
            errorPanel.BackColor = Color.MistyRose;
            errorPanel.Controls.Add(lblError);
            errorPanel.Dock = DockStyle.Fill;
            errorPanel.Location = new Point(0, 60);
            errorPanel.Name = "errorPanel";
            errorPanel.Size = new Size(800, 346);
            errorPanel.TabIndex = 3;
            errorPanel.Visible = false;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Dock = DockStyle.Fill;
            lblError.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(0, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(487, 32);
            lblError.TabIndex = 0;
            lblError.Text = "Не удалось подключиться к базе данных.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(errorPanel);
            Controls.Add(dgvAnimals);
            Controls.Add(headerPanel);
            Controls.Add(StatusPanel);
            Name = "MainForm";
            Text = "Админ-панель приюта \"Шанс на жизнь\"";
            WindowState = FormWindowState.Maximized;
            StatusPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            errorPanel.ResumeLayout(false);
            errorPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel StatusPanel;
        private Label lblStatus;
        private Panel headerPanel;
        private DataGridView dgvAnimals;
        private Label label1;
        private Panel errorPanel;
        private Label lblError;
        private Button btnNews;
    }
}
