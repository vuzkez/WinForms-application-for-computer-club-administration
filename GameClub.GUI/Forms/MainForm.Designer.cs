namespace GameClub.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // Основные контейнеры
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlEntrance;
        private Panel pnlGeneralZone;
        private Panel pnlVipZone1;
        private Panel pnlVipZone2;
        private Panel pnlBar;
        private Panel pnlBottom;
        private Panel pnlVipEntrance;

        // Кнопки управления
        private Button btnFindFreeSeat;
        private Button btnRefresh;
        private Button btnRevenue;
        private Button btnAdminPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        // Кнопки мест General (25 шт)
        private Button btnGen1, btnGen2, btnGen3, btnGen4, btnGen5;
        private Button btnGen6, btnGen7, btnGen8, btnGen9, btnGen10;
        private Button btnGen11, btnGen12, btnGen13, btnGen14, btnGen15;
        private Button btnGen16, btnGen17, btnGen18, btnGen19, btnGen20;
        private Button btnGen21, btnGen22, btnGen23, btnGen24, btnGen25;

        // Кнопки мест VIP (10 шт)
        private Button btnVip1, btnVip2, btnVip3, btnVip4, btnVip5;
        private Button btnVip6, btnVip7, btnVip8, btnVip9, btnVip10;

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
            pnlLeft = new Panel();
            pnlGeneralZone = new Panel();
            lblGeneralTitle = new Label();
            pnlEntrance = new Panel();
            lblEntranceTitle = new Label();
            pnlBar = new Panel();
            lblBar = new Label();
            lblRegistration = new Label();
            btnGen1 = new Button();
            btnGen2 = new Button();
            btnGen3 = new Button();
            btnGen4 = new Button();
            btnGen5 = new Button();
            btnGen6 = new Button();
            btnGen7 = new Button();
            btnGen8 = new Button();
            btnGen9 = new Button();
            btnGen10 = new Button();
            btnGen11 = new Button();
            btnGen12 = new Button();
            btnGen13 = new Button();
            btnGen14 = new Button();
            btnGen15 = new Button();
            btnGen16 = new Button();
            btnGen17 = new Button();
            btnGen18 = new Button();
            btnGen19 = new Button();
            btnGen20 = new Button();
            btnGen21 = new Button();
            btnGen22 = new Button();
            btnGen23 = new Button();
            btnGen24 = new Button();
            btnGen25 = new Button();
            pnlRight = new Panel();
            pnlVipZone1 = new Panel();
            lblVip1 = new Label();
            btnVip1 = new Button();
            btnVip2 = new Button();
            btnVip3 = new Button();
            btnVip4 = new Button();
            btnVip5 = new Button();
            pnlVipEntrance = new Panel();
            lblVipDoor = new Label();
            pnlVipZone2 = new Panel();
            lblVip2 = new Label();
            btnVip6 = new Button();
            btnVip7 = new Button();
            btnVip8 = new Button();
            btnVip9 = new Button();
            btnVip10 = new Button();
            pnlBottom = new Panel();
            btnAddHours = new Button();
            btnCloseSession = new Button();
            btnInfoUser = new Button();
            btnFindFreeSeat = new Button();
            btnRefresh = new Button();
            btnRevenue = new Button();
            btnAdminPanel = new Button();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            btnManageOperators = new Button();
            pnlLeft.SuspendLayout();
            pnlGeneralZone.SuspendLayout();
            pnlEntrance.SuspendLayout();
            pnlBar.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlVipZone1.SuspendLayout();
            pnlVipEntrance.SuspendLayout();
            pnlVipZone2.SuspendLayout();
            pnlBottom.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLeft.BackColor = Color.FromArgb(26, 26, 34);
            pnlLeft.Controls.Add(pnlGeneralZone);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(891, 640);
            pnlLeft.TabIndex = 0;
            // 
            // pnlGeneralZone
            // 
            pnlGeneralZone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGeneralZone.AutoScroll = true;
            pnlGeneralZone.BackColor = Color.FromArgb(32, 32, 42);
            pnlGeneralZone.Controls.Add(lblGeneralTitle);
            pnlGeneralZone.Controls.Add(pnlEntrance);
            pnlGeneralZone.Controls.Add(pnlBar);
            pnlGeneralZone.Controls.Add(lblRegistration);
            pnlGeneralZone.Controls.Add(btnGen1);
            pnlGeneralZone.Controls.Add(btnGen2);
            pnlGeneralZone.Controls.Add(btnGen3);
            pnlGeneralZone.Controls.Add(btnGen4);
            pnlGeneralZone.Controls.Add(btnGen5);
            pnlGeneralZone.Controls.Add(btnGen6);
            pnlGeneralZone.Controls.Add(btnGen7);
            pnlGeneralZone.Controls.Add(btnGen8);
            pnlGeneralZone.Controls.Add(btnGen9);
            pnlGeneralZone.Controls.Add(btnGen10);
            pnlGeneralZone.Controls.Add(btnGen11);
            pnlGeneralZone.Controls.Add(btnGen12);
            pnlGeneralZone.Controls.Add(btnGen13);
            pnlGeneralZone.Controls.Add(btnGen14);
            pnlGeneralZone.Controls.Add(btnGen15);
            pnlGeneralZone.Controls.Add(btnGen16);
            pnlGeneralZone.Controls.Add(btnGen17);
            pnlGeneralZone.Controls.Add(btnGen18);
            pnlGeneralZone.Controls.Add(btnGen19);
            pnlGeneralZone.Controls.Add(btnGen20);
            pnlGeneralZone.Controls.Add(btnGen21);
            pnlGeneralZone.Controls.Add(btnGen22);
            pnlGeneralZone.Controls.Add(btnGen23);
            pnlGeneralZone.Controls.Add(btnGen24);
            pnlGeneralZone.Controls.Add(btnGen25);
            pnlGeneralZone.Location = new Point(0, -1);
            pnlGeneralZone.Name = "pnlGeneralZone";
            pnlGeneralZone.Size = new Size(881, 641);
            pnlGeneralZone.TabIndex = 3;
            // 
            // lblGeneralTitle
            // 
            lblGeneralTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblGeneralTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGeneralTitle.ForeColor = Color.FromArgb(0, 190, 180);
            lblGeneralTitle.Location = new Point(726, 606);
            lblGeneralTitle.Name = "lblGeneralTitle";
            lblGeneralTitle.Size = new Size(152, 32);
            lblGeneralTitle.TabIndex = 0;
            lblGeneralTitle.Text = "GENERAL ZONE";
            // 
            // pnlEntrance
            // 
            pnlEntrance.Anchor = AnchorStyles.Left;
            pnlEntrance.BackColor = Color.FromArgb(36, 48, 36);
            pnlEntrance.Controls.Add(lblEntranceTitle);
            pnlEntrance.Location = new Point(10, 281);
            pnlEntrance.Name = "pnlEntrance";
            pnlEntrance.Size = new Size(56, 110);
            pnlEntrance.TabIndex = 2;
            // 
            // lblEntranceTitle
            // 
            lblEntranceTitle.Anchor = AnchorStyles.Left;
            lblEntranceTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEntranceTitle.ForeColor = Color.FromArgb(100, 220, 120);
            lblEntranceTitle.Location = new Point(0, 0);
            lblEntranceTitle.Name = "lblEntranceTitle";
            lblEntranceTitle.Size = new Size(56, 111);
            lblEntranceTitle.TabIndex = 0;
            lblEntranceTitle.Text = "ВХОД ";
            lblEntranceTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBar
            // 
            pnlBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlBar.BackColor = Color.FromArgb(48, 34, 20);
            pnlBar.Controls.Add(lblBar);
            pnlBar.Location = new Point(199, 578);
            pnlBar.Name = "pnlBar";
            pnlBar.Size = new Size(355, 54);
            pnlBar.TabIndex = 4;
            // 
            // lblBar
            // 
            lblBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblBar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBar.ForeColor = Color.FromArgb(255, 200, 60);
            lblBar.Location = new Point(0, 0);
            lblBar.Name = "lblBar";
            lblBar.Size = new Size(355, 54);
            lblBar.TabIndex = 0;
            lblBar.Text = "БАР/Напитки/Еда";
            lblBar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegistration
            // 
            lblRegistration.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRegistration.BackColor = Color.FromArgb(30, 55, 30);
            lblRegistration.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegistration.ForeColor = Color.FromArgb(100, 220, 100);
            lblRegistration.Location = new Point(10, 578);
            lblRegistration.Name = "lblRegistration";
            lblRegistration.Size = new Size(193, 54);
            lblRegistration.TabIndex = 1;
            lblRegistration.Text = "СТОЙКА РЕГИСТРАЦИИ";
            lblRegistration.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGen1
            // 
            btnGen1.BackColor = Color.FromArgb(50, 50, 65);
            btnGen1.FlatStyle = FlatStyle.Flat;
            btnGen1.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen1.FlatAppearance.BorderSize = 1;
            btnGen1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen1.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen1.Location = new Point(12, 16);
            btnGen1.Name = "btnGen1";
            btnGen1.Size = new Size(75, 68);
            btnGen1.TabIndex = 5;
            btnGen1.Text = "ПК #1";
            btnGen1.Click += SeatButton_Click;
            // 
            // btnGen2
            // 
            btnGen2.BackColor = Color.FromArgb(50, 50, 65);
            btnGen2.FlatStyle = FlatStyle.Flat;
            btnGen2.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen2.FlatAppearance.BorderSize = 1;
            btnGen2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen2.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen2.Location = new Point(93, 16);
            btnGen2.Name = "btnGen2";
            btnGen2.Size = new Size(75, 68);
            btnGen2.TabIndex = 6;
            btnGen2.Text = "ПК #2";
            btnGen2.Click += SeatButton_Click;
            // 
            // btnGen3
            // 
            btnGen3.BackColor = Color.FromArgb(50, 50, 65);
            btnGen3.FlatStyle = FlatStyle.Flat;
            btnGen3.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen3.FlatAppearance.BorderSize = 1;
            btnGen3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen3.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen3.Location = new Point(174, 16);
            btnGen3.Name = "btnGen3";
            btnGen3.Size = new Size(75, 68);
            btnGen3.TabIndex = 7;
            btnGen3.Text = "ПК #3";
            btnGen3.Click += SeatButton_Click;
            // 
            // btnGen4
            // 
            btnGen4.BackColor = Color.FromArgb(50, 50, 65);
            btnGen4.FlatStyle = FlatStyle.Flat;
            btnGen4.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen4.FlatAppearance.BorderSize = 1;
            btnGen4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen4.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen4.Location = new Point(255, 16);
            btnGen4.Name = "btnGen4";
            btnGen4.Size = new Size(75, 68);
            btnGen4.TabIndex = 8;
            btnGen4.Text = "ПК #4";
            btnGen4.Click += SeatButton_Click;
            // 
            // btnGen5
            // 
            btnGen5.BackColor = Color.FromArgb(50, 50, 65);
            btnGen5.FlatStyle = FlatStyle.Flat;
            btnGen5.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen5.FlatAppearance.BorderSize = 1;
            btnGen5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen5.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen5.Location = new Point(336, 16);
            btnGen5.Name = "btnGen5";
            btnGen5.Size = new Size(75, 68);
            btnGen5.TabIndex = 9;
            btnGen5.Text = "ПК #5";
            btnGen5.Click += SeatButton_Click;
            // 
            // btnGen6
            // 
            btnGen6.BackColor = Color.FromArgb(50, 50, 65);
            btnGen6.FlatStyle = FlatStyle.Flat;
            btnGen6.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen6.FlatAppearance.BorderSize = 1;
            btnGen6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen6.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen6.Location = new Point(417, 16);
            btnGen6.Name = "btnGen6";
            btnGen6.Size = new Size(75, 68);
            btnGen6.TabIndex = 10;
            btnGen6.Text = "ПК #6";
            btnGen6.Click += SeatButton_Click;
            // 
            // btnGen7
            // 
            btnGen7.BackColor = Color.FromArgb(50, 50, 65);
            btnGen7.FlatStyle = FlatStyle.Flat;
            btnGen7.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen7.FlatAppearance.BorderSize = 1;
            btnGen7.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen7.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen7.Location = new Point(499, 16);
            btnGen7.Name = "btnGen7";
            btnGen7.Size = new Size(75, 68);
            btnGen7.TabIndex = 11;
            btnGen7.Text = "ПК #7";
            btnGen7.Click += SeatButton_Click;
            // 
            // btnGen8
            // 
            btnGen8.BackColor = Color.FromArgb(50, 50, 65);
            btnGen8.FlatStyle = FlatStyle.Flat;
            btnGen8.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen8.FlatAppearance.BorderSize = 1;
            btnGen8.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen8.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen8.Location = new Point(580, 16);
            btnGen8.Name = "btnGen8";
            btnGen8.Size = new Size(75, 68);
            btnGen8.TabIndex = 12;
            btnGen8.Text = "ПК #8";
            btnGen8.Click += SeatButton_Click;
            // 
            // btnGen9
            // 
            btnGen9.BackColor = Color.FromArgb(50, 50, 65);
            btnGen9.FlatStyle = FlatStyle.Flat;
            btnGen9.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen9.FlatAppearance.BorderSize = 1;
            btnGen9.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen9.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen9.Location = new Point(664, 16);
            btnGen9.Name = "btnGen9";
            btnGen9.Size = new Size(75, 68);
            btnGen9.TabIndex = 13;
            btnGen9.Text = "ПК #9";
            btnGen9.Click += SeatButton_Click;
            // 
            // btnGen10
            // 
            btnGen10.BackColor = Color.FromArgb(50, 50, 65);
            btnGen10.FlatStyle = FlatStyle.Flat;
            btnGen10.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen10.FlatAppearance.BorderSize = 1;
            btnGen10.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen10.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen10.Location = new Point(745, 16);
            btnGen10.Name = "btnGen10";
            btnGen10.Size = new Size(75, 68);
            btnGen10.TabIndex = 14;
            btnGen10.Text = "ПК #10";
            btnGen10.Click += SeatButton_Click;
            // 
            // btnGen11
            // 
            btnGen11.BackColor = Color.FromArgb(50, 50, 65);
            btnGen11.FlatStyle = FlatStyle.Flat;
            btnGen11.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen11.FlatAppearance.BorderSize = 1;
            btnGen11.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen11.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen11.Location = new Point(15, 105);
            btnGen11.Name = "btnGen11";
            btnGen11.Size = new Size(75, 68);
            btnGen11.TabIndex = 15;
            btnGen11.Text = "ПК #11";
            btnGen11.Click += SeatButton_Click;
            // 
            // btnGen12
            // 
            btnGen12.BackColor = Color.FromArgb(50, 50, 65);
            btnGen12.FlatStyle = FlatStyle.Flat;
            btnGen12.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen12.FlatAppearance.BorderSize = 1;
            btnGen12.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen12.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen12.Location = new Point(95, 105);
            btnGen12.Name = "btnGen12";
            btnGen12.Size = new Size(75, 68);
            btnGen12.TabIndex = 16;
            btnGen12.Text = "ПК #12";
            btnGen12.Click += SeatButton_Click;
            // 
            // btnGen13
            // 
            btnGen13.BackColor = Color.FromArgb(50, 50, 65);
            btnGen13.FlatStyle = FlatStyle.Flat;
            btnGen13.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen13.FlatAppearance.BorderSize = 1;
            btnGen13.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen13.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen13.Location = new Point(176, 105);
            btnGen13.Name = "btnGen13";
            btnGen13.Size = new Size(75, 68);
            btnGen13.TabIndex = 17;
            btnGen13.Text = "ПК #13";
            btnGen13.Click += SeatButton_Click;
            // 
            // btnGen14
            // 
            btnGen14.BackColor = Color.FromArgb(50, 50, 65);
            btnGen14.FlatStyle = FlatStyle.Flat;
            btnGen14.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen14.FlatAppearance.BorderSize = 1;
            btnGen14.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen14.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen14.Location = new Point(255, 105);
            btnGen14.Name = "btnGen14";
            btnGen14.Size = new Size(75, 68);
            btnGen14.TabIndex = 18;
            btnGen14.Text = "ПК #14";
            btnGen14.Click += SeatButton_Click;
            // 
            // btnGen15
            // 
            btnGen15.BackColor = Color.FromArgb(50, 50, 65);
            btnGen15.FlatStyle = FlatStyle.Flat;
            btnGen15.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen15.FlatAppearance.BorderSize = 1;
            btnGen15.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen15.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen15.Location = new Point(339, 105);
            btnGen15.Name = "btnGen15";
            btnGen15.Size = new Size(75, 68);
            btnGen15.TabIndex = 19;
            btnGen15.Text = "ПК #15";
            btnGen15.Click += SeatButton_Click;
            // 
            // btnGen16
            // 
            btnGen16.BackColor = Color.FromArgb(50, 50, 65);
            btnGen16.FlatStyle = FlatStyle.Flat;
            btnGen16.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen16.FlatAppearance.BorderSize = 1;
            btnGen16.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen16.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen16.Location = new Point(421, 105);
            btnGen16.Name = "btnGen16";
            btnGen16.Size = new Size(75, 68);
            btnGen16.TabIndex = 20;
            btnGen16.Text = "ПК #16";
            btnGen16.Click += SeatButton_Click;
            // 
            // btnGen17
            // 
            btnGen17.BackColor = Color.FromArgb(50, 50, 65);
            btnGen17.FlatStyle = FlatStyle.Flat;
            btnGen17.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen17.FlatAppearance.BorderSize = 1;
            btnGen17.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen17.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen17.Location = new Point(502, 106);
            btnGen17.Name = "btnGen17";
            btnGen17.Size = new Size(75, 68);
            btnGen17.TabIndex = 21;
            btnGen17.Text = "ПК #17";
            btnGen17.Click += SeatButton_Click;
            // 
            // btnGen18
            // 
            btnGen18.BackColor = Color.FromArgb(50, 50, 65);
            btnGen18.FlatStyle = FlatStyle.Flat;
            btnGen18.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen18.FlatAppearance.BorderSize = 1;
            btnGen18.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen18.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen18.Location = new Point(583, 107);
            btnGen18.Name = "btnGen18";
            btnGen18.Size = new Size(75, 68);
            btnGen18.TabIndex = 22;
            btnGen18.Text = "ПК #18";
            btnGen18.Click += SeatButton_Click;
            // 
            // btnGen19
            // 
            btnGen19.BackColor = Color.FromArgb(50, 50, 65);
            btnGen19.FlatStyle = FlatStyle.Flat;
            btnGen19.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen19.FlatAppearance.BorderSize = 1;
            btnGen19.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen19.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen19.Location = new Point(664, 106);
            btnGen19.Name = "btnGen19";
            btnGen19.Size = new Size(75, 68);
            btnGen19.TabIndex = 23;
            btnGen19.Text = "ПК #19";
            btnGen19.Click += SeatButton_Click;
            // 
            // btnGen20
            // 
            btnGen20.BackColor = Color.FromArgb(50, 50, 65);
            btnGen20.FlatStyle = FlatStyle.Flat;
            btnGen20.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen20.FlatAppearance.BorderSize = 1;
            btnGen20.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen20.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen20.Location = new Point(745, 107);
            btnGen20.Name = "btnGen20";
            btnGen20.Size = new Size(75, 68);
            btnGen20.TabIndex = 24;
            btnGen20.Text = "ПК #20";
            btnGen20.Click += SeatButton_Click;
            // 
            // btnGen21
            // 
            btnGen21.BackColor = Color.FromArgb(50, 50, 65);
            btnGen21.FlatStyle = FlatStyle.Flat;
            btnGen21.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen21.FlatAppearance.BorderSize = 1;
            btnGen21.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen21.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen21.Location = new Point(209, 192);
            btnGen21.Name = "btnGen21";
            btnGen21.Size = new Size(75, 68);
            btnGen21.TabIndex = 25;
            btnGen21.Text = "ПК #21";
            btnGen21.Click += SeatButton_Click;
            // 
            // btnGen22
            // 
            btnGen22.BackColor = Color.FromArgb(50, 50, 65);
            btnGen22.FlatStyle = FlatStyle.Flat;
            btnGen22.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen22.FlatAppearance.BorderSize = 1;
            btnGen22.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen22.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen22.Location = new Point(290, 192);
            btnGen22.Name = "btnGen22";
            btnGen22.Size = new Size(75, 68);
            btnGen22.TabIndex = 26;
            btnGen22.Text = "ПК #22";
            btnGen22.Click += SeatButton_Click;
            // 
            // btnGen23
            // 
            btnGen23.BackColor = Color.FromArgb(50, 50, 65);
            btnGen23.FlatStyle = FlatStyle.Flat;
            btnGen23.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen23.FlatAppearance.BorderSize = 1;
            btnGen23.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen23.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen23.Location = new Point(371, 192);
            btnGen23.Name = "btnGen23";
            btnGen23.Size = new Size(75, 68);
            btnGen23.TabIndex = 27;
            btnGen23.Text = "ПК #23";
            btnGen23.Click += SeatButton_Click;
            // 
            // btnGen24
            // 
            btnGen24.BackColor = Color.FromArgb(50, 50, 65);
            btnGen24.FlatStyle = FlatStyle.Flat;
            btnGen24.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen24.FlatAppearance.BorderSize = 1;
            btnGen24.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen24.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen24.Location = new Point(452, 192);
            btnGen24.Name = "btnGen24";
            btnGen24.Size = new Size(75, 68);
            btnGen24.TabIndex = 28;
            btnGen24.Text = "ПК #24";
            btnGen24.Click += SeatButton_Click;
            // 
            // btnGen25
            // 
            btnGen25.BackColor = Color.FromArgb(50, 50, 65);
            btnGen25.FlatStyle = FlatStyle.Flat;
            btnGen25.FlatAppearance.BorderColor = Color.FromArgb(70, 70, 90);
            btnGen25.FlatAppearance.BorderSize = 1;
            btnGen25.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnGen25.ForeColor = Color.FromArgb(200, 200, 220);
            btnGen25.Location = new Point(533, 192);
            btnGen25.Name = "btnGen25";
            btnGen25.Size = new Size(75, 68);
            btnGen25.TabIndex = 29;
            btnGen25.Text = "ПК #25";
            btnGen25.Click += SeatButton_Click;
            // 
            // pnlRight
            // 
            pnlRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlRight.BackColor = Color.FromArgb(32, 32, 42);
            pnlRight.Controls.Add(pnlVipZone1);
            pnlRight.Controls.Add(pnlVipEntrance);
            pnlRight.Controls.Add(pnlVipZone2);
            pnlRight.Location = new Point(879, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(410, 640);
            pnlRight.TabIndex = 1;
            // 
            // pnlVipZone1
            // 
            pnlVipZone1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlVipZone1.BackColor = Color.FromArgb(38, 28, 52);
            pnlVipZone1.Controls.Add(lblVip1);
            pnlVipZone1.Controls.Add(btnVip1);
            pnlVipZone1.Controls.Add(btnVip2);
            pnlVipZone1.Controls.Add(btnVip3);
            pnlVipZone1.Controls.Add(btnVip4);
            pnlVipZone1.Controls.Add(btnVip5);
            pnlVipZone1.Location = new Point(0, 0);
            pnlVipZone1.Name = "pnlVipZone1";
            pnlVipZone1.Size = new Size(410, 280);
            pnlVipZone1.TabIndex = 5;
            // 
            // lblVip1
            // 
            lblVip1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVip1.ForeColor = Color.FromArgb(255, 200, 60);
            lblVip1.Location = new Point(280, 7);
            lblVip1.Name = "lblVip1";
            lblVip1.Size = new Size(127, 30);
            lblVip1.TabIndex = 0;
            lblVip1.Text = "VIP ZONE 1";
            // 
            // btnVip1
            // 
            btnVip1.BackColor = Color.FromArgb(65, 45, 85);
            btnVip1.FlatStyle = FlatStyle.Flat;
            btnVip1.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip1.FlatAppearance.BorderSize = 1;
            btnVip1.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip1.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip1.Location = new Point(47, 40);
            btnVip1.Name = "btnVip1";
            btnVip1.Size = new Size(70, 70);
            btnVip1.TabIndex = 1;
            btnVip1.Text = "VIP #26";
            btnVip1.Click += SeatButton_Click;
            // 
            // btnVip2
            // 
            btnVip2.BackColor = Color.FromArgb(65, 45, 85);
            btnVip2.FlatStyle = FlatStyle.Flat;
            btnVip2.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip2.FlatAppearance.BorderSize = 1;
            btnVip2.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip2.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip2.Location = new Point(47, 127);
            btnVip2.Name = "btnVip2";
            btnVip2.Size = new Size(70, 70);
            btnVip2.TabIndex = 2;
            btnVip2.Text = "VIP #27";
            btnVip2.Click += SeatButton_Click;
            // 
            // btnVip3
            // 
            btnVip3.BackColor = Color.FromArgb(65, 45, 85);
            btnVip3.FlatStyle = FlatStyle.Flat;
            btnVip3.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip3.FlatAppearance.BorderSize = 1;
            btnVip3.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip3.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip3.Location = new Point(162, 15);
            btnVip3.Name = "btnVip3";
            btnVip3.Size = new Size(70, 70);
            btnVip3.TabIndex = 3;
            btnVip3.Text = "VIP #28";
            btnVip3.Click += SeatButton_Click;
            // 
            // btnVip4
            // 
            btnVip4.BackColor = Color.FromArgb(65, 45, 85);
            btnVip4.FlatStyle = FlatStyle.Flat;
            btnVip4.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip4.FlatAppearance.BorderSize = 1;
            btnVip4.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip4.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip4.Location = new Point(280, 40);
            btnVip4.Name = "btnVip4";
            btnVip4.Size = new Size(70, 70);
            btnVip4.TabIndex = 4;
            btnVip4.Text = "VIP #29";
            btnVip4.Click += SeatButton_Click;
            // 
            // btnVip5
            // 
            btnVip5.BackColor = Color.FromArgb(65, 45, 85);
            btnVip5.FlatStyle = FlatStyle.Flat;
            btnVip5.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip5.FlatAppearance.BorderSize = 1;
            btnVip5.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip5.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip5.Location = new Point(280, 127);
            btnVip5.Name = "btnVip5";
            btnVip5.Size = new Size(70, 70);
            btnVip5.TabIndex = 5;
            btnVip5.Text = "VIP #30";
            btnVip5.Click += SeatButton_Click;
            // 
            // pnlVipEntrance
            // 
            pnlVipEntrance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlVipEntrance.BackColor = Color.FromArgb(60, 42, 30);
            pnlVipEntrance.Controls.Add(lblVipDoor);
            pnlVipEntrance.Location = new Point(0, 280);
            pnlVipEntrance.Name = "pnlVipEntrance";
            pnlVipEntrance.Size = new Size(410, 61);
            pnlVipEntrance.TabIndex = 6;
            // 
            // lblVipDoor
            // 
            lblVipDoor.Anchor = AnchorStyles.None;
            lblVipDoor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVipDoor.ForeColor = Color.FromArgb(255, 200, 100);
            lblVipDoor.Location = new Point(0, 0);
            lblVipDoor.Name = "lblVipDoor";
            lblVipDoor.Size = new Size(410, 61);
            lblVipDoor.TabIndex = 0;
            lblVipDoor.Text = "ВХОД В VIP ЗОНЫ";
            lblVipDoor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlVipZone2
            // 
            pnlVipZone2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlVipZone2.BackColor = Color.FromArgb(42, 30, 58);
            pnlVipZone2.Controls.Add(lblVip2);
            pnlVipZone2.Controls.Add(btnVip6);
            pnlVipZone2.Controls.Add(btnVip7);
            pnlVipZone2.Controls.Add(btnVip8);
            pnlVipZone2.Controls.Add(btnVip9);
            pnlVipZone2.Controls.Add(btnVip10);
            pnlVipZone2.Location = new Point(0, 335);
            pnlVipZone2.Name = "pnlVipZone2";
            pnlVipZone2.Size = new Size(410, 305);
            pnlVipZone2.TabIndex = 7;
            // 
            // lblVip2
            // 
            lblVip2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVip2.ForeColor = Color.FromArgb(255, 200, 60);
            lblVip2.Location = new Point(280, 7);
            lblVip2.Name = "lblVip2";
            lblVip2.Size = new Size(130, 30);
            lblVip2.TabIndex = 0;
            lblVip2.Text = "VIP ZONE 2";
            // 
            // btnVip6
            // 
            btnVip6.BackColor = Color.FromArgb(65, 45, 85);
            btnVip6.FlatStyle = FlatStyle.Flat;
            btnVip6.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip6.FlatAppearance.BorderSize = 1;
            btnVip6.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip6.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip6.Location = new Point(47, 66);
            btnVip6.Name = "btnVip6";
            btnVip6.Size = new Size(70, 70);
            btnVip6.TabIndex = 1;
            btnVip6.Text = "VIP #31";
            btnVip6.Click += SeatButton_Click;
            // 
            // btnVip7
            // 
            btnVip7.BackColor = Color.FromArgb(65, 45, 85);
            btnVip7.FlatStyle = FlatStyle.Flat;
            btnVip7.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip7.FlatAppearance.BorderSize = 1;
            btnVip7.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip7.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip7.Location = new Point(47, 156);
            btnVip7.Name = "btnVip7";
            btnVip7.Size = new Size(70, 70);
            btnVip7.TabIndex = 2;
            btnVip7.Text = "VIP #32";
            btnVip7.Click += SeatButton_Click;
            // 
            // btnVip8
            // 
            btnVip8.BackColor = Color.FromArgb(65, 45, 85);
            btnVip8.FlatStyle = FlatStyle.Flat;
            btnVip8.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip8.FlatAppearance.BorderSize = 1;
            btnVip8.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip8.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip8.Location = new Point(162, 205);
            btnVip8.Name = "btnVip8";
            btnVip8.Size = new Size(70, 70);
            btnVip8.TabIndex = 3;
            btnVip8.Text = "VIP #33";
            btnVip8.Click += SeatButton_Click;
            // 
            // btnVip9
            // 
            btnVip9.BackColor = Color.FromArgb(65, 45, 85);
            btnVip9.FlatStyle = FlatStyle.Flat;
            btnVip9.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip9.FlatAppearance.BorderSize = 1;
            btnVip9.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip9.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip9.Location = new Point(280, 156);
            btnVip9.Name = "btnVip9";
            btnVip9.Size = new Size(70, 70);
            btnVip9.TabIndex = 4;
            btnVip9.Text = "VIP #34";
            btnVip9.Click += SeatButton_Click;
            // 
            // btnVip10
            // 
            btnVip10.BackColor = Color.FromArgb(65, 45, 85);
            btnVip10.FlatStyle = FlatStyle.Flat;
            btnVip10.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 160);
            btnVip10.FlatAppearance.BorderSize = 1;
            btnVip10.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnVip10.ForeColor = Color.FromArgb(220, 190, 255);
            btnVip10.Location = new Point(280, 66);
            btnVip10.Name = "btnVip10";
            btnVip10.Size = new Size(70, 70);
            btnVip10.TabIndex = 5;
            btnVip10.Text = "VIP #35";
            btnVip10.Click += SeatButton_Click;
            // 
            // pnlBottom
            // 
            pnlBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBottom.BackColor = Color.FromArgb(30, 30, 40);
            pnlBottom.Controls.Add(btnAddHours);
            pnlBottom.Controls.Add(btnCloseSession);
            pnlBottom.Controls.Add(btnInfoUser);
            pnlBottom.Controls.Add(btnFindFreeSeat);
            pnlBottom.Controls.Add(btnRefresh);
            pnlBottom.Controls.Add(btnManageOperators);
            pnlBottom.Controls.Add(btnRevenue);
            pnlBottom.Controls.Add(btnAdminPanel);
            pnlBottom.Location = new Point(0, 640);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1289, 60);
            pnlBottom.TabIndex = 8;
            // 
            // btnAddHours
            // 
            btnAddHours.BackColor = Color.FromArgb(100, 30, 30);
            btnAddHours.FlatStyle = FlatStyle.Flat;
            btnAddHours.FlatAppearance.BorderSize = 0;
            btnAddHours.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddHours.ForeColor = Color.White;
            btnAddHours.Location = new Point(525, 9);
            btnAddHours.Name = "btnAddHours";
            btnAddHours.Size = new Size(158, 40);
            btnAddHours.TabIndex = 7;
            btnAddHours.Text = "Добавить часы";
            btnAddHours.UseVisualStyleBackColor = false;
            btnAddHours.Click += btnAddHours_Click;
            // 
            // btnCloseSession
            // 
            btnCloseSession.BackColor = Color.FromArgb(140, 40, 40);
            btnCloseSession.FlatStyle = FlatStyle.Flat;
            btnCloseSession.FlatAppearance.BorderSize = 0;
            btnCloseSession.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCloseSession.ForeColor = Color.White;
            btnCloseSession.Location = new Point(365, 9);
            btnCloseSession.Name = "btnCloseSession";
            btnCloseSession.Size = new Size(154, 40);
            btnCloseSession.TabIndex = 6;
            btnCloseSession.Text = "Закрыть сессию";
            btnCloseSession.UseVisualStyleBackColor = false;
            btnCloseSession.Click += btnCloseSession_Click;
            // 
            // btnInfoUser
            // 
            btnInfoUser.BackColor = Color.FromArgb(30, 110, 100);
            btnInfoUser.FlatStyle = FlatStyle.Flat;
            btnInfoUser.FlatAppearance.BorderSize = 0;
            btnInfoUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInfoUser.ForeColor = Color.White;
            btnInfoUser.Location = new Point(6, 9);
            btnInfoUser.Name = "btnInfoUser";
            btnInfoUser.Size = new Size(143, 40);
            btnInfoUser.TabIndex = 4;
            btnInfoUser.Text = "Пользователь";
            btnInfoUser.UseVisualStyleBackColor = false;
            btnInfoUser.Click += btnInfoUser_Click;
            // 
            // btnFindFreeSeat
            // 
            btnFindFreeSeat.BackColor = Color.FromArgb(30, 90, 155);
            btnFindFreeSeat.FlatStyle = FlatStyle.Flat;
            btnFindFreeSeat.FlatAppearance.BorderSize = 0;
            btnFindFreeSeat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFindFreeSeat.ForeColor = Color.White;
            btnFindFreeSeat.Location = new Point(158, 9);
            btnFindFreeSeat.Name = "btnFindFreeSeat";
            btnFindFreeSeat.Size = new Size(200, 40);
            btnFindFreeSeat.TabIndex = 0;
            btnFindFreeSeat.Text = "Найти свободный ПК\nОткрыть сессию";
            btnFindFreeSeat.UseVisualStyleBackColor = false;
            btnFindFreeSeat.Click += btnFindFreeSeat_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(20, 90, 40);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(690, 9);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 40);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить карту";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnRevenue
            // 
            btnRevenue.BackColor = Color.FromArgb(150, 80, 10);
            btnRevenue.FlatStyle = FlatStyle.Flat;
            btnRevenue.FlatAppearance.BorderSize = 0;
            btnRevenue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRevenue.ForeColor = Color.White;
            btnRevenue.Location = new Point(998, 9);
            btnRevenue.Name = "btnRevenue";
            btnRevenue.Size = new Size(120, 40);
            btnRevenue.TabIndex = 2;
            btnRevenue.Text = "Выручка";
            btnRevenue.UseVisualStyleBackColor = false;
            btnRevenue.Click += btnRevenue_Click;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.BackColor = Color.FromArgb(90, 20, 120);
            btnAdminPanel.FlatStyle = FlatStyle.Flat;
            btnAdminPanel.FlatAppearance.BorderSize = 0;
            btnAdminPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdminPanel.ForeColor = Color.White;
            btnAdminPanel.Location = new Point(1124, 9);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new Size(152, 40);
            btnAdminPanel.TabIndex = 3;
            btnAdminPanel.Text = "Настроить цену тарифа";
            btnAdminPanel.UseVisualStyleBackColor = false;
            btnAdminPanel.Click += btnAdminPanel_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(16, 16, 22);
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 700);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1289, 22);
            statusStrip.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.FromArgb(100, 220, 100);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(88, 17);
            lblStatus.Text = "Готов к работе";
            // 
            // btnManageOperators
            // 
            btnManageOperators.BackColor = Color.FromArgb(20, 90, 90);
            btnManageOperators.FlatStyle = FlatStyle.Flat;
            btnManageOperators.FlatAppearance.BorderSize = 0;
            btnManageOperators.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnManageOperators.ForeColor = Color.White;
            btnManageOperators.Location = new Point(826, 9);
            btnManageOperators.Name = "btnManageOperators";
            btnManageOperators.Size = new Size(165, 40);
            btnManageOperators.TabIndex = 10;
            btnManageOperators.Text = "Операторы";
            btnManageOperators.UseVisualStyleBackColor = false;
            btnManageOperators.Click += btnManageOperators_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(1289, 722);
            Controls.Add(pnlBottom);
            Controls.Add(statusStrip);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CyberX";
            FormClosing += MainForm_FormClosing;
            pnlLeft.ResumeLayout(false);
            pnlGeneralZone.ResumeLayout(false);
            pnlEntrance.ResumeLayout(false);
            pnlBar.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlVipZone1.ResumeLayout(false);
            pnlVipEntrance.ResumeLayout(false);
            pnlVipZone2.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGeneralTitle;
        private Label lblBar;
        private Label lblVip1;
        private Label lblVipDoor;
        private Label lblVip2;
        private Label lblEntranceTitle;
        private Label lblRegistration;
        private Button btnInfoUser;
        private Button btnCloseSession;
        private Button btnAddHours;
        private Button btnManageOperators;
    }
}