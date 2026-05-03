namespace GameClub.GUI
{
    partial class OpenSessionForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnOk;
        private Button btnCancel;
        private Label label2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private Label lblSelectedSeatInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnOk = new Button();
            btnCancel = new Button();
            label2 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            lblSelectedSeatInfo = new Label();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(30, 100, 160);
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(23, 286);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(130, 42);
            btnOk.TabIndex = 1;
            btnOk.Text = "Открыть сессию";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(55, 55, 70);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(180, 180, 200);
            btnCancel.Location = new Point(244, 286);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 42);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 190, 180);
            label2.Location = new Point(80, 41);
            label2.Name = "label2";
            label2.Size = new Size(240, 30);
            label2.TabIndex = 4;
            label2.Text = "Выберите тариф";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton1.ForeColor = Color.FromArgb(80, 160, 255);
            radioButton1.Location = new Point(98, 74);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(90, 23);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Дневной";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton2.ForeColor = Color.FromArgb(160, 80, 255);
            radioButton2.Location = new Point(98, 103);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(82, 23);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "Ночной";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarForeColor = Color.FromArgb(210, 210, 230);
            dateTimePicker1.CalendarMonthBackground = Color.FromArgb(28, 28, 38);
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePicker1.Font = new Font("Segoe UI", 10F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(106, 166);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(188, 25);
            dateTimePicker1.TabIndex = 11;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(0, 190, 180);
            label4.Location = new Point(106, 143);
            label4.Name = "label4";
            label4.Size = new Size(188, 20);
            label4.TabIndex = 12;
            label4.Text = "Начало сессии";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(0, 190, 180);
            label5.Location = new Point(106, 203);
            label5.Name = "label5";
            label5.Size = new Size(188, 20);
            label5.TabIndex = 13;
            label5.Text = "Количество часов";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(35, 35, 50);
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            textBox3.ForeColor = Color.FromArgb(210, 210, 230);
            textBox3.Location = new Point(151, 231);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 27);
            textBox3.TabIndex = 14;
            textBox3.Text = "1";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSelectedSeatInfo
            // 
            lblSelectedSeatInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectedSeatInfo.ForeColor = Color.FromArgb(100, 220, 100);
            lblSelectedSeatInfo.Location = new Point(60, 11);
            lblSelectedSeatInfo.Name = "lblSelectedSeatInfo";
            lblSelectedSeatInfo.Size = new Size(280, 27);
            lblSelectedSeatInfo.TabIndex = 15;
            lblSelectedSeatInfo.Text = "Выбрано место номер: 0";
            lblSelectedSeatInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblSelectedSeatInfo.Visible = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(35, 35, 50);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            textBox2.ForeColor = Color.FromArgb(210, 210, 230);
            textBox2.Location = new Point(150, 11);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 27);
            textBox2.TabIndex = 6;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // OpenSessionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            ClientSize = new Size(405, 334);
            Controls.Add(lblSelectedSeatInfo);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenSessionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Открытие новой сессии";
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBox2;
    }
}