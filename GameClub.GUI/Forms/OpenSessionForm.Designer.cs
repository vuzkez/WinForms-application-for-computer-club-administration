namespace GameClub.GUI
{
    partial class OpenSessionForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnOk;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private Label lblSelectedSeatInfo;
        private TextBox textBox2;

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
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            lblSelectedSeatInfo = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(43, 87, 154);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(35, 400);
            btnOk.Margin = new Padding(4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(186, 63);
            btnOk.TabIndex = 1;
            btnOk.Text = "Открыть сессию";
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
            btnCancel.Location = new Point(358, 402);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(186, 63);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(26, 26, 46);
            label2.Location = new Point(114, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(343, 45);
            label2.TabIndex = 4;
            label2.Text = "Выберите тариф";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 10F);
            radioButton1.ForeColor = Color.FromArgb(50, 50, 50);
            radioButton1.Location = new Point(140, 111);
            radioButton1.Margin = new Padding(4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(120, 32);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Дневной";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 10F);
            radioButton2.ForeColor = Color.FromArgb(50, 50, 50);
            radioButton2.Location = new Point(140, 154);
            radioButton2.Margin = new Padding(4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(110, 32);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "Ночной";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(80, 80, 80);
            label4.Location = new Point(151, 214);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(269, 30);
            label4.TabIndex = 12;
            label4.Text = "Начало сессии";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(80, 80, 80);
            label5.Location = new Point(151, 304);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(269, 30);
            label5.TabIndex = 13;
            label5.Text = "Количество часов";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBox3.ForeColor = Color.FromArgb(30, 30, 30);
            textBox3.Location = new Point(216, 346);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(142, 34);
            textBox3.TabIndex = 14;
            textBox3.Text = "1";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSelectedSeatInfo
            // 
            lblSelectedSeatInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectedSeatInfo.ForeColor = Color.FromArgb(43, 87, 154);
            lblSelectedSeatInfo.Location = new Point(86, 16);
            lblSelectedSeatInfo.Margin = new Padding(4, 0, 4, 0);
            lblSelectedSeatInfo.Name = "lblSelectedSeatInfo";
            lblSelectedSeatInfo.Size = new Size(400, 40);
            lblSelectedSeatInfo.TabIndex = 15;
            lblSelectedSeatInfo.Text = "Выбрано место номер: 0";
            lblSelectedSeatInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblSelectedSeatInfo.Visible = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            textBox2.ForeColor = Color.FromArgb(30, 30, 30);
            textBox2.Location = new Point(214, 16);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(142, 37);
            textBox2.TabIndex = 6;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(114, 244);
            label1.Name = "label1";
            label1.Size = new Size(346, 45);
            label1.TabIndex = 16;
            label1.Text = "Дата";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OpenSessionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(579, 478);
            Controls.Add(label1);
            Controls.Add(lblSelectedSeatInfo);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenSessionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Открытие новой сессии";
            ResumeLayout(false);
            PerformLayout();
        }

    }
}