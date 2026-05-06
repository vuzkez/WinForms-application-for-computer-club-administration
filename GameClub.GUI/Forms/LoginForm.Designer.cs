using GameClub.Library;

namespace GameClub.GUI
{
    public partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblStatus;
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;

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

        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblStatus = new Label();
            lblTitle = new Label();
            lblLogin = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.White;
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Segoe UI", 10F);
            txtLogin.ForeColor = Color.FromArgb(30, 30, 30);
            txtLogin.Location = new Point(113, 69);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(180, 25);
            txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.FromArgb(30, 30, 30);
            txtPassword.Location = new Point(113, 104);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 25);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(43, 87, 154);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(113, 149);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(245, 245, 245);
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(180, 50, 50);
            lblStatus.Location = new Point(72, 196);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(180, 28);
            lblStatus.TabIndex = 6;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(43, 87, 154);
            lblTitle.Location = new Point(33, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CYBERX";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Segoe UI", 10F);
            lblLogin.ForeColor = Color.FromArgb(80, 80, 80);
            lblLogin.Location = new Point(33, 69);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(80, 25);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(80, 80, 80);
            lblPassword.Location = new Point(33, 104);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 25);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Пароль:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(328, 233);
            Controls.Add(lblTitle);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация - CyberX";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}