namespace GameClub.GUI
{
    partial class TariffForm
    {
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("Segoe UI", 10F);
            lblDay.ForeColor = Color.FromArgb(80, 80, 80);
            lblDay.Location = new Point(29, 142);
            lblDay.Margin = new Padding(4, 0, 4, 0);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(114, 28);
            lblDay.TabIndex = 2;
            lblDay.Text = "Цена (руб):";
            // 
            // lblNight
            // 
            lblNight.AutoSize = true;
            lblNight.Font = new Font("Segoe UI", 10F);
            lblNight.ForeColor = Color.FromArgb(80, 80, 80);
            lblNight.Location = new Point(29, 262);
            lblNight.Margin = new Padding(4, 0, 4, 0);
            lblNight.Name = "lblNight";
            lblNight.Size = new Size(114, 28);
            lblNight.TabIndex = 5;
            lblNight.Text = "Цена (руб):";
            // 
            // nudDayPrice
            // 
            nudDayPrice.BackColor = Color.White;
            nudDayPrice.DecimalPlaces = 2;
            nudDayPrice.Font = new Font("Segoe UI", 10F);
            nudDayPrice.ForeColor = Color.FromArgb(30, 30, 30);
            nudDayPrice.Location = new Point(171, 138);
            nudDayPrice.Margin = new Padding(4, 4, 4, 4);
            nudDayPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDayPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDayPrice.Name = "nudDayPrice";
            nudDayPrice.Size = new Size(171, 34);
            nudDayPrice.TabIndex = 3;
            nudDayPrice.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // nudNightPrice
            // 
            nudNightPrice.BackColor = Color.White;
            nudNightPrice.DecimalPlaces = 2;
            nudNightPrice.Font = new Font("Segoe UI", 10F);
            nudNightPrice.ForeColor = Color.FromArgb(30, 30, 30);
            nudNightPrice.Location = new Point(171, 258);
            nudNightPrice.Margin = new Padding(4, 4, 4, 4);
            nudNightPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudNightPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNightPrice.Name = "nudNightPrice";
            nudNightPrice.Size = new Size(171, 34);
            nudNightPrice.TabIndex = 6;
            nudNightPrice.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(43, 87, 154);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(29, 345);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(171, 52);
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(107, 107, 107);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(357, 345);
            btnClose.Margin = new Padding(4, 4, 4, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(171, 52);
            btnClose.TabIndex = 8;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblDayTitle
            // 
            lblDayTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDayTitle.ForeColor = Color.FromArgb(43, 87, 154);
            lblDayTitle.Location = new Point(29, 90);
            lblDayTitle.Margin = new Padding(4, 0, 4, 0);
            lblDayTitle.Name = "lblDayTitle";
            lblDayTitle.Size = new Size(214, 38);
            lblDayTitle.TabIndex = 1;
            lblDayTitle.Text = "Дневной тариф";
            lblDayTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNightTitle
            // 
            lblNightTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNightTitle.ForeColor = Color.FromArgb(43, 87, 154);
            lblNightTitle.Location = new Point(29, 210);
            lblNightTitle.Margin = new Padding(4, 0, 4, 0);
            lblNightTitle.Name = "lblNightTitle";
            lblNightTitle.Size = new Size(214, 38);
            lblNightTitle.TabIndex = 4;
            lblNightTitle.Text = "Ночной тариф";
            lblNightTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(26, 26, 46);
            lblTitle.Location = new Point(17, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(514, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Настройка тарифов";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TariffForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(557, 415);
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
            Margin = new Padding(4, 4, 4, 4);
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