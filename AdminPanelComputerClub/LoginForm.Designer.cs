namespace AdminPanelComputerClub
{
    public partial class LoginForm : Form
    {
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;

        private void InitializeComponent()
        {
            this.txtLogin = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblStatus = new Label();
            this.lblTitle = new Label();
            this.lblLogin = new Label();
            this.lblPassword = new Label();

            // Form
            this.Text = "Авторизация - GameClub";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new Size(350, 300);

            // Title
            this.lblTitle.Text = "GameClub";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkBlue;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(250, 40);

            // Login label
            this.lblLogin.Text = "Логин:";
            this.lblLogin.Location = new Point(50, 80);
            this.lblLogin.Size = new Size(80, 25);

            // Login textbox
            this.txtLogin.Location = new Point(130, 80);
            this.txtLogin.Size = new Size(180, 25);

            // Password label
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Location = new Point(50, 115);
            this.lblPassword.Size = new Size(80, 25);

            // Password textbox
            this.txtPassword.Location = new Point(130, 115);
            this.txtPassword.Size = new Size(180, 25);
            this.txtPassword.PasswordChar = '*';

            // Login button
            this.btnLogin.Text = "Войти";
            this.btnLogin.BackColor = Color.DarkGreen;
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Location = new Point(130, 160);
            this.btnLogin.Size = new Size(100, 35);

            // Status label
            this.lblStatus.Text = "Введите логин и пароль";
            this.lblStatus.Location = new Point(50, 210);
            this.lblStatus.Size = new Size(250, 40);
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            this.lblStatus.BackColor = Color.LightGray;

            // Add controls
            this.Controls.AddRange(new Control[] {
            lblTitle, lblLogin, txtLogin, lblPassword, txtPassword, btnLogin, lblStatus
        });
        }
    }
}
