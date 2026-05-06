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
            this.lblDay = new System.Windows.Forms.Label();
            this.lblNight = new System.Windows.Forms.Label();
            this.nudDayPrice = new System.Windows.Forms.NumericUpDown();
            this.nudNightPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDayTitle = new System.Windows.Forms.Label();
            this.lblNightTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Настройка тарифов";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDayTitle
            //
            this.lblDayTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDayTitle.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.lblDayTitle.Location = new System.Drawing.Point(20, 60);
            this.lblDayTitle.Name = "lblDayTitle";
            this.lblDayTitle.Size = new System.Drawing.Size(150, 25);
            this.lblDayTitle.TabIndex = 1;
            this.lblDayTitle.Text = "Дневной тариф";
            this.lblDayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblDay
            //
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDay.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDay.Location = new System.Drawing.Point(20, 95);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(72, 20);
            this.lblDay.TabIndex = 2;
            this.lblDay.Text = "Цена (руб):";
            //
            // nudDayPrice
            //
            this.nudDayPrice.BackColor = System.Drawing.Color.White;
            this.nudDayPrice.DecimalPlaces = 2;
            this.nudDayPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDayPrice.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.nudDayPrice.Location = new System.Drawing.Point(120, 92);
            this.nudDayPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudDayPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudDayPrice.Name = "nudDayPrice";
            this.nudDayPrice.Size = new System.Drawing.Size(120, 25);
            this.nudDayPrice.TabIndex = 3;
            this.nudDayPrice.Value = new decimal(new int[] { 100, 0, 0, 0 });
            //
            // lblNightTitle
            //
            this.lblNightTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNightTitle.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.lblNightTitle.Location = new System.Drawing.Point(20, 140);
            this.lblNightTitle.Name = "lblNightTitle";
            this.lblNightTitle.Size = new System.Drawing.Size(150, 25);
            this.lblNightTitle.TabIndex = 4;
            this.lblNightTitle.Text = "Ночной тариф";
            this.lblNightTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblNight
            //
            this.lblNight.AutoSize = true;
            this.lblNight.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNight.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblNight.Location = new System.Drawing.Point(20, 175);
            this.lblNight.Name = "lblNight";
            this.lblNight.Size = new System.Drawing.Size(72, 20);
            this.lblNight.TabIndex = 5;
            this.lblNight.Text = "Цена (руб):";
            //
            // nudNightPrice
            //
            this.nudNightPrice.BackColor = System.Drawing.Color.White;
            this.nudNightPrice.DecimalPlaces = 2;
            this.nudNightPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudNightPrice.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.nudNightPrice.Location = new System.Drawing.Point(120, 172);
            this.nudNightPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudNightPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudNightPrice.Name = "nudNightPrice";
            this.nudNightPrice.Size = new System.Drawing.Size(120, 25);
            this.nudNightPrice.TabIndex = 6;
            this.nudNightPrice.Value = new decimal(new int[] { 150, 0, 0, 0 });
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(107, 107, 107);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(250, 230);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // TariffForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(390, 290);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nudNightPrice);
            this.Controls.Add(this.lblNight);
            this.Controls.Add(this.lblNightTitle);
            this.Controls.Add(this.nudDayPrice);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblDayTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TariffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка тарифов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}