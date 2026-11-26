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
            headerPanel = new Panel();
            label1 = new Label();
            dgvAnimals = new DataGridView();
            errorPanel = new Panel();
            lblError = new Label();
            toolPanel = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            StatusPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            errorPanel.SuspendLayout();
            toolPanel.SuspendLayout();
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
            dgvAnimals.Location = new Point(0, 124);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.ReadOnly = true;
            dgvAnimals.RowTemplate.Height = 30;
            dgvAnimals.Size = new Size(800, 296);
            dgvAnimals.TabIndex = 2;
            // 
            // errorPanel
            // 
            errorPanel.BackColor = Color.MistyRose;
            errorPanel.Controls.Add(lblError);
            errorPanel.Dock = DockStyle.Fill;
            errorPanel.Location = new Point(0, 124);
            errorPanel.Name = "errorPanel";
            errorPanel.Size = new Size(800, 296);
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
            // toolPanel
            // 
            toolPanel.BackColor = SystemColors.GradientActiveCaption;
            toolPanel.Controls.Add(btnDelete);
            toolPanel.Controls.Add(btnEdit);
            toolPanel.Controls.Add(btnAdd);
            toolPanel.Dock = DockStyle.Top;
            toolPanel.Location = new Point(0, 60);
            toolPanel.Name = "toolPanel";
            toolPanel.Size = new Size(800, 64);
            toolPanel.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Font = new Font("Segoe UI", 12F);
            btnDelete.Location = new Point(654, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 33);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(514, 15);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(134, 33);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(374, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 33);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(errorPanel);
            Controls.Add(dgvAnimals);
            Controls.Add(toolPanel);
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
            toolPanel.ResumeLayout(false);
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
        private Panel toolPanel;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
    }
}
