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
            btnOk.BackColor = Color.SteelBlue;
            btnOk.Enabled = false;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(29, 375);
            btnOk.Margin = new Padding(4, 5, 4, 5);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(143, 55);
            btnOk.TabIndex = 5;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(357, 375);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(143, 55);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSelectSeat
            // 
            lblSelectSeat.AutoSize = true;
            lblSelectSeat.Location = new Point(29, 34);
            lblSelectSeat.Margin = new Padding(4, 0, 4, 0);
            lblSelectSeat.Name = "lblSelectSeat";
            lblSelectSeat.Size = new Size(149, 25);
            lblSelectSeat.TabIndex = 7;
            lblSelectSeat.Text = "Активная сессия:";
            // 
            // cmbActiveSeats
            // 
            cmbActiveSeats.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActiveSeats.Location = new Point(186, 31);
            cmbActiveSeats.Margin = new Padding(4, 5, 4, 5);
            cmbActiveSeats.Name = "cmbActiveSeats";
            cmbActiveSeats.Size = new Size(284, 33);
            cmbActiveSeats.TabIndex = 8;
            cmbActiveSeats.SelectedIndexChanged += cmbActiveSeats_SelectedIndexChanged;
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Location = new Point(29, 94);
            lblHours.Margin = new Padding(4, 0, 4, 0);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(127, 25);
            lblHours.TabIndex = 2;
            lblHours.Text = "Кол-во часов:";
            // 
            // nudHours
            // 
            nudHours.Location = new Point(171, 89);
            nudHours.Margin = new Padding(4, 5, 4, 5);
            nudHours.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            nudHours.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(143, 31);
            nudHours.TabIndex = 3;
            nudHours.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSessionInfo
            // 
            lblSessionInfo.BackColor = Color.LightGray;
            lblSessionInfo.BorderStyle = BorderStyle.FixedSingle;
            lblSessionInfo.Location = new Point(29, 156);
            lblSessionInfo.Margin = new Padding(4, 0, 4, 0);
            lblSessionInfo.Name = "lblSessionInfo";
            lblSessionInfo.Size = new Size(471, 155);
            lblSessionInfo.TabIndex = 4;
            lblSessionInfo.Text = "Введите номер ПК...";
            lblSessionInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddHoursForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 469);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblSessionInfo);
            Controls.Add(nudHours);
            Controls.Add(lblHours);
            Controls.Add(lblSelectSeat);
            Controls.Add(cmbActiveSeats);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
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