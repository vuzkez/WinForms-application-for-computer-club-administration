namespace GameClub.GUI
{
    partial class TariffForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblDay;
        private Label lblNight;
        private NumericUpDown nudDayPrice;
        private NumericUpDown nudNightPrice;
        private Button btnSave;
        private Button btnClose;
        private Label lblDayTitle;
        private Label lblNightTitle;
        private Label lblTitle;

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
            lblDay = new Label();
            lblNight = new Label();
            nudDayPrice = new NumericUpDown();
            nudNightPrice = new NumericUpDown();
            btnSave = new Button();
            btnClose = new Button();
            lblDayTitle = new Label();
            lblNightTitle = new Label();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDayPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNightPrice).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 190, 180);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Настройка тарифов";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDayTitle
            // 
            lblDayTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDayTitle.ForeColor = Color.FromArgb(80, 160, 255);
            lblDayTitle.Location = new Point(20, 60);
            lblDayTitle.Name = "lblDayTitle";
            lblDayTitle.Size = new Size(150, 25);
            lblDayTitle.TabIndex = 1;
            lblDayTitle.Text = "Дневной тариф";
            lblDayTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("Segoe UI", 10F);
            lblDay.ForeColor = Color.FromArgb(140, 140, 165);
            lblDay.Location = new Point(20, 95);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(72, 20);
            lblDay.TabIndex = 2;
            lblDay.Text = "Цена (руб):";
            // 
            // nudDayPrice
            // 
            nudDayPrice.BackColor = Color.FromArgb(35, 35, 50);
            nudDayPrice.DecimalPlaces = 2;
            nudDayPrice.Font = new Font("Segoe UI", 10F);
            nudDayPrice.ForeColor = Color.FromArgb(210, 210, 230);
            nudDayPrice.Location = new Point(120, 92);
            nudDayPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDayPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDayPrice.Name = "nudDayPrice";
            nudDayPrice.Size = new Size(120, 23);
            nudDayPrice.TabIndex = 3;
            nudDayPrice.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblNightTitle
            // 
            lblNightTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNightTitle.ForeColor = Color.FromArgb(160, 80, 255);
            lblNightTitle.Location = new Point(20, 140);
            lblNightTitle.Name = "lblNightTitle";
            lblNightTitle.Size = new Size(150, 25);
            lblNightTitle.TabIndex = 4;
            lblNightTitle.Text = "Ночной тариф";
            lblNightTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNight
            // 
            lblNight.AutoSize = true;
            lblNight.Font = new Font("Segoe UI", 10F);
            lblNight.ForeColor = Color.FromArgb(140, 140, 165);
            lblNight.Location = new Point(20, 175);
            lblNight.Name = "lblNight";
            lblNight.Size = new Size(72, 20);
            lblNight.TabIndex = 5;
            lblNight.Text = "Цена (руб):";
            // 
            // nudNightPrice
            // 
            nudNightPrice.BackColor = Color.FromArgb(35, 35, 50);
            nudNightPrice.DecimalPlaces = 2;
            nudNightPrice.Font = new Font("Segoe UI", 10F);
            nudNightPrice.ForeColor = Color.FromArgb(210, 210, 230);
            nudNightPrice.Location = new Point(120, 172);
            nudNightPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudNightPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNightPrice.Name = "nudNightPrice";
            nudNightPrice.Size = new Size(120, 23);
            nudNightPrice.TabIndex = 6;
            nudNightPrice.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(30, 100, 160);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(55, 55, 70);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(180, 180, 200);
            btnClose.Location = new Point(250, 230);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 35);
            btnClose.TabIndex = 8;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // TariffForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            ClientSize = new Size(390, 290);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(nudNightPrice);
            Controls.Add(lblNight);
            Controls.Add(lblNightTitle);
            Controls.Add(nudDayPrice);
            Controls.Add(lblDay);
            Controls.Add(lblDayTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TariffForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройка тарифов";
            ((System.ComponentModel.ISupportInitialize)nudDayPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNightPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}