namespace ShelterAdmin.Forms
{
    partial class AnimalEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtBreed = new TextBox();
            txtDescription = new TextBox();
            txtHealthInfo = new TextBox();
            cmbSpecies = new ComboBox();
            cmbGender = new ComboBox();
            cmbSize = new ComboBox();
            cmbStatus = new ComboBox();
            numAge = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            dtpArrivalDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            lblCRUD = new Label();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F);
            txtName.Location = new Point(234, 80);
            txtName.Name = "txtName";
            txtName.Size = new Size(232, 29);
            txtName.TabIndex = 0;
            // 
            // txtBreed
            // 
            txtBreed.Font = new Font("Segoe UI", 12F);
            txtBreed.Location = new Point(234, 118);
            txtBreed.Name = "txtBreed";
            txtBreed.Size = new Size(232, 29);
            txtBreed.TabIndex = 1;
            txtBreed.Text = "метис";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 12F);
            txtDescription.Location = new Point(234, 156);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(232, 69);
            txtDescription.TabIndex = 2;
            // 
            // txtHealthInfo
            // 
            txtHealthInfo.Font = new Font("Segoe UI", 12F);
            txtHealthInfo.Location = new Point(234, 231);
            txtHealthInfo.Multiline = true;
            txtHealthInfo.Name = "txtHealthInfo";
            txtHealthInfo.Size = new Size(232, 69);
            txtHealthInfo.TabIndex = 3;
            // 
            // cmbSpecies
            // 
            cmbSpecies.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecies.Font = new Font("Segoe UI", 12F);
            cmbSpecies.FormattingEnabled = true;
            cmbSpecies.Items.AddRange(new object[] { "Собака", "Кошка" });
            cmbSpecies.Location = new Point(234, 312);
            cmbSpecies.Name = "cmbSpecies";
            cmbSpecies.Size = new Size(232, 29);
            cmbSpecies.TabIndex = 4;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 12F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Мальчик", "Девочка" });
            cmbGender.Location = new Point(234, 356);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(232, 29);
            cmbGender.TabIndex = 5;
            // 
            // cmbSize
            // 
            cmbSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSize.Font = new Font("Segoe UI", 12F);
            cmbSize.FormattingEnabled = true;
            cmbSize.Items.AddRange(new object[] { "Маленький", "Средний", "Крупный" });
            cmbSize.Location = new Point(234, 401);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(232, 29);
            cmbSize.TabIndex = 6;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 12F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Ищет дом", "На передержке", "Пристроен" });
            cmbStatus.Location = new Point(234, 446);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(232, 29);
            cmbStatus.TabIndex = 7;
            // 
            // numAge
            // 
            numAge.Font = new Font("Segoe UI", 12F);
            numAge.Location = new Point(234, 495);
            numAge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(232, 29);
            numAge.TabIndex = 8;
            numAge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(51, 607);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(259, 48);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.SteelBlue;
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(316, 607);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 48);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // dtpArrivalDate
            // 
            dtpArrivalDate.Font = new Font("Segoe UI", 12F);
            dtpArrivalDate.Location = new Point(234, 545);
            dtpArrivalDate.Name = "dtpArrivalDate";
            dtpArrivalDate.Size = new Size(232, 29);
            dtpArrivalDate.TabIndex = 11;
            dtpArrivalDate.Value = new DateTime(2026, 11, 26, 11, 12, 45, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(51, 83);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 12;
            label1.Text = "Кличка:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(51, 121);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 13;
            label2.Text = "Порода:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(51, 159);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 14;
            label3.Text = "Описание:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(51, 234);
            label4.Name = "label4";
            label4.Size = new Size(82, 21);
            label4.TabIndex = 15;
            label4.Text = "Здоровье:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(51, 315);
            label5.Name = "label5";
            label5.Size = new Size(40, 21);
            label5.TabIndex = 16;
            label5.Text = "Вид:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(50, 359);
            label6.Name = "label6";
            label6.Size = new Size(41, 21);
            label6.TabIndex = 17;
            label6.Text = "Пол:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(50, 404);
            label7.Name = "label7";
            label7.Size = new Size(65, 21);
            label7.TabIndex = 18;
            label7.Text = "Размер:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(51, 449);
            label8.Name = "label8";
            label8.Size = new Size(60, 21);
            label8.TabIndex = 19;
            label8.Text = "Статус:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(51, 497);
            label9.Name = "label9";
            label9.Size = new Size(138, 21);
            label9.TabIndex = 20;
            label9.Text = "Возраст (месяцы):";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(51, 551);
            label10.Name = "label10";
            label10.Size = new Size(142, 21);
            label10.TabIndex = 21;
            label10.Text = "Дата поступления:";
            // 
            // lblCRUD
            // 
            lblCRUD.BackColor = Color.SteelBlue;
            lblCRUD.Dock = DockStyle.Top;
            lblCRUD.Font = new Font("Segoe UI", 18F);
            lblCRUD.ForeColor = SystemColors.Control;
            lblCRUD.Location = new Point(0, 0);
            lblCRUD.Name = "lblCRUD";
            lblCRUD.Size = new Size(518, 56);
            lblCRUD.TabIndex = 22;
            lblCRUD.Text = "Анкета";
            lblCRUD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AnimalEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(518, 679);
            Controls.Add(lblCRUD);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpArrivalDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numAge);
            Controls.Add(cmbStatus);
            Controls.Add(cmbSize);
            Controls.Add(cmbGender);
            Controls.Add(cmbSpecies);
            Controls.Add(txtHealthInfo);
            Controls.Add(txtDescription);
            Controls.Add(txtBreed);
            Controls.Add(txtName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AnimalEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Анкета животного";
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtBreed;
        private TextBox txtDescription;
        private TextBox txtHealthInfo;
        private ComboBox cmbSpecies;
        private ComboBox cmbGender;
        private ComboBox cmbSize;
        private ComboBox cmbStatus;
        private NumericUpDown numAge;
        private Button btnSave;
        private Button btnCancel;
        private DateTimePicker dtpArrivalDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label lblCRUD;
    }
}