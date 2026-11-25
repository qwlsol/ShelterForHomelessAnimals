namespace ShelterAdmin.Forms
{
    partial class NewsEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTitle;
        private TextBox txtContent;
        private TextBox txtDetailed;
        private TextBox txtImagePath;
        private DateTimePicker dtpPublishedAt;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;
        private Label lblTitle, lblContent, lblDetailed, lblImage, lblDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtContent = new TextBox();
            txtDetailed = new TextBox();
            txtImagePath = new TextBox();
            dtpPublishedAt = new DateTimePicker();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            lblContent = new Label();
            lblDetailed = new Label();
            lblImage = new Label();
            lblDate = new Label();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(20, 40);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(400, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(20, 100);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(400, 60);
            txtContent.TabIndex = 3;
            // 
            // txtDetailed
            // 
            txtDetailed.Location = new Point(20, 200);
            txtDetailed.Multiline = true;
            txtDetailed.Name = "txtDetailed";
            txtDetailed.ScrollBars = ScrollBars.Vertical;
            txtDetailed.Size = new Size(400, 120);
            txtDetailed.TabIndex = 5;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(20, 360);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(400, 23);
            txtImagePath.TabIndex = 7;
            // 
            // dtpPublishedAt
            // 
            dtpPublishedAt.Format = DateTimePickerFormat.Short;
            dtpPublishedAt.Location = new Point(20, 420);
            dtpPublishedAt.Name = "dtpPublishedAt";
            dtpPublishedAt.Size = new Size(200, 23);
            dtpPublishedAt.TabIndex = 9;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(20, 460);
            lblError.Name = "lblError";
            lblError.Size = new Size(53, 15);
            lblError.TabIndex = 10;
            lblError.Text = "Ошибка";
            lblError.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(240, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 11;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(350, 450);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Заголовок:";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(20, 80);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(170, 15);
            lblContent.TabIndex = 2;
            lblContent.Text = "Краткий текст (для карточки):";
            // 
            // lblDetailed
            // 
            lblDetailed.AutoSize = true;
            lblDetailed.Location = new Point(20, 180);
            lblDetailed.Name = "lblDetailed";
            lblDetailed.Size = new Size(194, 15);
            lblDetailed.TabIndex = 4;
            lblDetailed.Text = "Подробный текст (для страницы):";
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(20, 340);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(282, 15);
            lblImage.TabIndex = 6;
            lblImage.Text = "Путь к картинке (например, /images/timosha.jpg):";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(20, 400);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(105, 15);
            lblDate.TabIndex = 8;
            lblDate.Text = "Дата публикации:";
            // 
            // NewsEditForm
            // 
            ClientSize = new Size(460, 510);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblContent);
            Controls.Add(txtContent);
            Controls.Add(lblDetailed);
            Controls.Add(txtDetailed);
            Controls.Add(lblImage);
            Controls.Add(txtImagePath);
            Controls.Add(lblDate);
            Controls.Add(dtpPublishedAt);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewsEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование новости";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}