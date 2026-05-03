namespace GameClub.GUI
{
    partial class AddHoursForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblSelectSeat;
        private ComboBox cmbActiveSeats;
        private Label lblHours;
        private NumericUpDown nudHours;
        private Label lblSessionInfo;
        private Button btnOk;
        private Button btnCancel;

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
            btnOk = new Button();
            btnCancel = new Button();
            lblSelectSeat = new Label();
            cmbActiveSeats = new ComboBox();
            lblHours = new Label();
            nudHours = new NumericUpDown();
            lblSessionInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)nudHours).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(30, 100, 160);
            btnOk.Enabled = false;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(20, 240);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 35);
            btnOk.TabIndex = 5;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(55, 55, 70);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(180, 180, 200);
            btnCancel.Location = new Point(250, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSelectSeat
            // 
            lblSelectSeat.AutoSize = true;
            lblSelectSeat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectSeat.ForeColor = Color.FromArgb(0, 190, 180);
            lblSelectSeat.Location = new Point(20, 22);
            lblSelectSeat.Name = "lblSelectSeat";
            lblSelectSeat.Size = new Size(129, 19);
            lblSelectSeat.TabIndex = 7;
            lblSelectSeat.Text = "Активная сессия:";
            // 
            // cmbActiveSeats
            // 
            cmbActiveSeats.BackColor = Color.FromArgb(35, 35, 50);
            cmbActiveSeats.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActiveSeats.FlatStyle = FlatStyle.Flat;
            cmbActiveSeats.Font = new Font("Segoe UI", 10F);
            cmbActiveSeats.ForeColor = Color.FromArgb(210, 210, 230);
            cmbActiveSeats.Location = new Point(150, 22);
            cmbActiveSeats.Name = "cmbActiveSeats";
            cmbActiveSeats.Size = new Size(200, 25);
            cmbActiveSeats.TabIndex = 8;
            cmbActiveSeats.SelectedIndexChanged += cmbActiveSeats_SelectedIndexChanged;
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHours.ForeColor = Color.FromArgb(0, 190, 180);
            lblHours.Location = new Point(20, 60);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(106, 19);
            lblHours.TabIndex = 2;
            lblHours.Text = "Кол-во часов:";
            // 
            // nudHours
            // 
            nudHours.BackColor = Color.FromArgb(35, 35, 50);
            nudHours.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            nudHours.ForeColor = Color.FromArgb(210, 210, 230);
            nudHours.Location = new Point(132, 56);
            nudHours.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            nudHours.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(100, 27);
            nudHours.TabIndex = 3;
            nudHours.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSessionInfo
            // 
            lblSessionInfo.BackColor = Color.FromArgb(25, 25, 34);
            lblSessionInfo.BorderStyle = BorderStyle.FixedSingle;
            lblSessionInfo.Font = new Font("Segoe UI", 10F);
            lblSessionInfo.ForeColor = Color.FromArgb(210, 210, 230);
            lblSessionInfo.Location = new Point(20, 100);
            lblSessionInfo.Name = "lblSessionInfo";
            lblSessionInfo.Size = new Size(330, 100);
            lblSessionInfo.TabIndex = 4;
            lblSessionInfo.Text = "Выберите активную сессию...";
            lblSessionInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddHoursForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            ClientSize = new Size(370, 300);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblSessionInfo);
            Controls.Add(nudHours);
            Controls.Add(lblHours);
            Controls.Add(lblSelectSeat);
            Controls.Add(cmbActiveSeats);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddHoursForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление часов";
            ((System.ComponentModel.ISupportInitialize)nudHours).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}