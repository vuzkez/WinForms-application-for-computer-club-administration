namespace GameClub.GUI.Views
{
    partial class RevenueForm
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnShow;
        private Button btnClose;
        private Label lblFrom;
        private Label lblTo;
        private Label lblTotal;
        private TextBox txtTotal;
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Text = "Отчёт по выручке";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFrom
            //
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFrom.Location = new System.Drawing.Point(20, 60);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(71, 20);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "Период с:";
            //
            // dtpFrom
            //
            this.dtpFrom.CalendarForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dtpFrom.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(100, 57);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 25);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.Value = System.DateTime.Now.AddDays(-30);
            //
            // lblTo
            //
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTo.Location = new System.Drawing.Point(235, 60);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 20);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "по:";
            //
            // dtpTo
            //
            this.dtpTo.CalendarForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dtpTo.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(270, 57);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 25);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.Value = System.DateTime.Now;
            //
            // btnShow
            //
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(20, 110);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(120, 35);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Показать";
            this.btnShow.UseVisualStyleBackColor = false;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(107, 107, 107);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(270, 110);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // lblTotal
            //
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.lblTotal.Location = new System.Drawing.Point(20, 170);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 30);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Итого:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTotal
            //
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.txtTotal.Location = new System.Drawing.Point(100, 170);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(290, 29);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.Text = "0.00 руб";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // RevenueForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(410, 230);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RevenueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выручка";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}