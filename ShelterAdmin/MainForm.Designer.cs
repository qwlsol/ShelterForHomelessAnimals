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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            StatusPanel = new Panel();
            lblStatus = new Label();
            headerPanel = new Panel();
            label1 = new Label();
            dgvAnimals = new DataGridView();
            StatusPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            SuspendLayout();
            // 
            // StatusPanel
            // 
            StatusPanel.BackColor = Color.SteelBlue;
            StatusPanel.BorderStyle = BorderStyle.FixedSingle;
            StatusPanel.Controls.Add(lblStatus);
            StatusPanel.Dock = DockStyle.Bottom;
            StatusPanel.Location = new Point(0, 420);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Size = new Size(800, 30);
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
            lblStatus.Size = new Size(203, 28);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Всего животных в базе: 0";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
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
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dgvAnimals.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimals.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvAnimals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Navy;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvAnimals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvAnimals.DefaultCellStyle = dataGridViewCellStyle6;
            dgvAnimals.Dock = DockStyle.Fill;
            dgvAnimals.GridColor = Color.Gainsboro;
            dgvAnimals.Location = new Point(0, 60);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.RowTemplate.Height = 30;
            dgvAnimals.Size = new Size(800, 360);
            dgvAnimals.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvAnimals);
            Controls.Add(headerPanel);
            Controls.Add(StatusPanel);
            Name = "MainForm";
            Text = "Админ-панель приюта \"Шанс на жизнь\"";
            WindowState = FormWindowState.Maximized;
            StatusPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel StatusPanel;
        private Label lblStatus;
        private Panel headerPanel;
        private DataGridView dgvAnimals;
        private Label label1;
    }
}
