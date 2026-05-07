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
            btnOk.BackColor = Color.FromArgb(43, 87, 154);
            btnOk.Enabled = false;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(26, 385);
            btnOk.Margin = new Padding(4, 4, 4, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(143, 52);
            btnOk.TabIndex = 5;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(107, 107, 107);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(355, 385);
            btnCancel.Margin = new Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(143, 52);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSelectSeat
            // 
            lblSelectSeat.AutoSize = true;
            lblSelectSeat.Font = new Font("Segoe UI", 10F);
            lblSelectSeat.ForeColor = Color.FromArgb(80, 80, 80);
            lblSelectSeat.Location = new Point(29, 33);
            lblSelectSeat.Margin = new Padding(4, 0, 4, 0);
            lblSelectSeat.Name = "lblSelectSeat";
            lblSelectSeat.Size = new Size(166, 28);
            lblSelectSeat.TabIndex = 7;
            lblSelectSeat.Text = "Активная сессия:";
            // 
            // cmbActiveSeats
            // 
            cmbActiveSeats.BackColor = Color.White;
            cmbActiveSeats.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActiveSeats.FlatStyle = FlatStyle.Flat;
            cmbActiveSeats.Font = new Font("Segoe UI", 10F);
            cmbActiveSeats.ForeColor = Color.FromArgb(30, 30, 30);
            cmbActiveSeats.Location = new Point(214, 33);
            cmbActiveSeats.Margin = new Padding(4, 4, 4, 4);
            cmbActiveSeats.Name = "cmbActiveSeats";
            cmbActiveSeats.Size = new Size(284, 36);
            cmbActiveSeats.TabIndex = 8;
            cmbActiveSeats.SelectedIndexChanged += cmbActiveSeats_SelectedIndexChanged;
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Font = new Font("Segoe UI", 10F);
            lblHours.ForeColor = Color.FromArgb(80, 80, 80);
            lblHours.Location = new Point(29, 90);
            lblHours.Margin = new Padding(4, 0, 4, 0);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(140, 28);
            lblHours.TabIndex = 2;
            lblHours.Text = "Кол-во часов:";
            // 
            // nudHours
            // 
            nudHours.BackColor = Color.White;
            nudHours.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            nudHours.ForeColor = Color.FromArgb(30, 30, 30);
            nudHours.Location = new Point(189, 84);
            nudHours.Margin = new Padding(4, 4, 4, 4);
            nudHours.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            nudHours.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(143, 34);
            nudHours.TabIndex = 3;
            nudHours.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSessionInfo
            // 
            lblSessionInfo.BackColor = Color.White;
            lblSessionInfo.BorderStyle = BorderStyle.FixedSingle;
            lblSessionInfo.Font = new Font("Segoe UI", 10F);
            lblSessionInfo.ForeColor = Color.FromArgb(60, 60, 60);
            lblSessionInfo.Location = new Point(26, 134);
            lblSessionInfo.Margin = new Padding(4, 0, 4, 0);
            lblSessionInfo.Name = "lblSessionInfo";
            lblSessionInfo.Size = new Size(471, 231);
            lblSessionInfo.TabIndex = 4;
            lblSessionInfo.Text = "Выберите активную сессию...";
            lblSessionInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddHoursForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(529, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblSessionInfo);
            Controls.Add(nudHours);
            Controls.Add(lblHours);
            Controls.Add(lblSelectSeat);
            Controls.Add(cmbActiveSeats);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
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