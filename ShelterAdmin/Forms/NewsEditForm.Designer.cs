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
            this.txtTitle = new TextBox();
            this.txtContent = new TextBox();
            this.txtDetailed = new TextBox();
            this.txtImagePath = new TextBox();
            this.dtpPublishedAt = new DateTimePicker();
            this.lblError = new Label();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblTitle = new Label();
            this.lblContent = new Label();
            this.lblDetailed = new Label();
            this.lblImage = new Label();
            this.lblDate = new Label();

            // Заголовок
            this.lblTitle.Text = "Заголовок:";
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.AutoSize = true;
            this.txtTitle.Location = new Point(20, 40);
            this.txtTitle.Size = new Size(400, 23);

            // Краткий текст
            this.lblContent.Text = "Краткий текст (для карточки):";
            this.lblContent.Location = new Point(20, 80);
            this.lblContent.AutoSize = true;
            this.txtContent.Location = new Point(20, 100);
            this.txtContent.Size = new Size(400, 60);
            this.txtContent.Multiline = true;

            // Подробный текст
            this.lblDetailed.Text = "Подробный текст (для страницы):";
            this.lblDetailed.Location = new Point(20, 180);
            this.lblDetailed.AutoSize = true;
            this.txtDetailed.Location = new Point(20, 200);
            this.txtDetailed.Size = new Size(400, 120);
            this.txtDetailed.Multiline = true;
            this.txtDetailed.ScrollBars = ScrollBars.Vertical;

            // Картинка
            this.lblImage.Text = "Путь к картинке (например, /images/timosha.jpg):";
            this.lblImage.Location = new Point(20, 340);
            this.lblImage.AutoSize = true;
            this.txtImagePath.Location = new Point(20, 360);
            this.txtImagePath.Size = new Size(400, 23);

            // Дата
            this.lblDate.Text = "Дата публикации:";
            this.lblDate.Location = new Point(20, 400);
            this.lblDate.AutoSize = true;
            this.dtpPublishedAt.Location = new Point(20, 420);
            this.dtpPublishedAt.Size = new Size(200, 23);
            this.dtpPublishedAt.Format = DateTimePickerFormat.Short;

            // Ошибка
            this.lblError.Text = "Ошибка";
            this.lblError.Location = new Point(20, 460);
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = Color.Firebrick;
            this.lblError.Visible = false;

            // Кнопки
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new Point(240, 450);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.BackColor = Color.SteelBlue;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new Point(350, 450);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Настройка формы
            this.ClientSize = new Size(460, 510);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblDetailed);
            this.Controls.Add(this.txtDetailed);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpPublishedAt);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "NewsEditForm";
            this.Text = "Редактирование новости";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}