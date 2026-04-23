namespace AdminPanelComputerClub
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
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
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
            lblDayTitle.ForeColor = Color.DarkBlue;
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
            lblDay.Location = new Point(20, 95);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(72, 20);
            lblDay.TabIndex = 2;
            lblDay.Text = "Цена (руб):";
            // 
            // nudDayPrice
            // 
            nudDayPrice.DecimalPlaces = 2;
            nudDayPrice.Location = new Point(120, 92);
            nudDayPrice.Maximum = 10000;
            nudDayPrice.Minimum = 1;
            nudDayPrice.Name = "nudDayPrice";
            nudDayPrice.Size = new Size(120, 23);
            nudDayPrice.TabIndex = 3;
            nudDayPrice.Value = 100;
            // 
            // lblNightTitle
            // 
            lblNightTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNightTitle.ForeColor = Color.DarkBlue;
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
            lblNight.Location = new Point(20, 175);
            lblNight.Name = "lblNight";
            lblNight.Size = new Size(72, 20);
            lblNight.TabIndex = 5;
            lblNight.Text = "Цена (руб):";
            // 
            // nudNightPrice
            // 
            nudNightPrice.DecimalPlaces = 2;
            nudNightPrice.Location = new Point(120, 172);
            nudNightPrice.Maximum = 10000;
            nudNightPrice.Minimum = 1;
            nudNightPrice.Name = "nudNightPrice";
            nudNightPrice.Size = new Size(120, 23);
            nudNightPrice.TabIndex = 6;
            nudNightPrice.Value = 150;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
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
            btnClose.BackColor = Color.DarkRed;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}