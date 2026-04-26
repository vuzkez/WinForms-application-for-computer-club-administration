namespace GameClub.GUI
{
    partial class RevenueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            btnShow = new Button();
            btnClose = new Button();
            lblFrom = new Label();
            lblTo = new Label();
            lblTotal = new Label();
            txtTotal = new TextBox();
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
            lblTitle.Text = "Отчёт по выручке";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(20, 60);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(91, 20);
            lblFrom.TabIndex = 1;
            lblFrom.Text = "Период с:";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(120, 57);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 23);
            dtpFrom.TabIndex = 2;
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(260, 60);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 20);
            lblTo.TabIndex = 3;
            lblTo.Text = "по:";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(300, 57);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 23);
            dtpTo.TabIndex = 4;
            dtpTo.Value = DateTime.Now;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.SteelBlue;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.ForeColor = Color.White;
            btnShow.Location = new Point(20, 110);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(120, 35);
            btnShow.TabIndex = 5;
            btnShow.Text = "Показать";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DarkRed;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(300, 110);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 35);
            btnClose.TabIndex = 6;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 170);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 30);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Итого:";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = Color.LightYellow;
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.ForeColor = Color.DarkGreen;
            txtTotal.Location = new Point(120, 170);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(300, 29);
            txtTotal.TabIndex = 8;
            txtTotal.Text = "0.00 руб";
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // RevenueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 230);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(btnClose);
            Controls.Add(btnShow);
            Controls.Add(dtpTo);
            Controls.Add(lblTo);
            Controls.Add(dtpFrom);
            Controls.Add(lblFrom);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RevenueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Выручка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}