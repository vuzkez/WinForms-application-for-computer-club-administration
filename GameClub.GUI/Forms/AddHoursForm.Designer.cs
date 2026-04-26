namespace GameClub.GUI
{
    partial class AddHoursForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblSeatId;
        private TextBox txtSeatId;
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
            lblSeatId = new Label();
            txtSeatId = new TextBox();
            lblHours = new Label();
            nudHours = new NumericUpDown();
            lblSessionInfo = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.SteelBlue;
            btnOk.Enabled = false;
            btnOk.FlatStyle = FlatStyle.Flat;
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
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(250, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSeatId
            // 
            lblSeatId.AutoSize = true;
            lblSeatId.Location = new Point(20, 22);
            lblSeatId.Name = "lblSeatId";
            lblSeatId.Size = new Size(76, 20);
            lblSeatId.TabIndex = 0;
            lblSeatId.Text = "Номер ПК:";
            // 
            // txtSeatId
            // 
            txtSeatId.Location = new Point(120, 19);
            txtSeatId.Name = "txtSeatId";
            txtSeatId.Size = new Size(100, 23);
            txtSeatId.TabIndex = 1;
            // 
            // lblHours
            // 
            lblHours.AutoSize = true;
            lblHours.Location = new Point(20, 60);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(94, 20);
            lblHours.TabIndex = 2;
            lblHours.Text = "Кол-во часов:";
            // 
            // nudHours
            // 
            nudHours.Location = new Point(120, 57);
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(100, 23);
            nudHours.TabIndex = 3;
            nudHours.Minimum = 1;
            nudHours.Maximum = 24;
            nudHours.Value = 1;
            // 
            // lblSessionInfo
            // 
            lblSessionInfo.BackColor = Color.LightGray;
            lblSessionInfo.BorderStyle = BorderStyle.FixedSingle;
            lblSessionInfo.Location = new Point(20, 100);
            lblSessionInfo.Name = "lblSessionInfo";
            lblSessionInfo.Size = new Size(330, 100);
            lblSessionInfo.TabIndex = 4;
            lblSessionInfo.Text = "Введите номер ПК...";
            lblSessionInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddHoursForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 300);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(lblSessionInfo);
            Controls.Add(nudHours);
            Controls.Add(lblHours);
            Controls.Add(txtSeatId);
            Controls.Add(lblSeatId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddHoursForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление часов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}