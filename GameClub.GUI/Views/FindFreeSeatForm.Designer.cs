namespace GameClub.GUI.Views
{
    partial class FindFreeSeatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnOk;
        private Button btnCancel;
        private Label lblPrompt;
        private RadioButton radioButton1;
        private RadioButton radioButton2;

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
            lblPrompt = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(43, 87, 154);
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.White;
            btnOk.Location = new Point(17, 150);
            btnOk.Margin = new Padding(4, 4, 4, 4);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(157, 60);
            btnOk.TabIndex = 0;
            btnOk.Text = "ОК";
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
            btnCancel.Location = new Point(233, 150);
            btnCancel.Margin = new Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(157, 60);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPrompt.ForeColor = Color.FromArgb(43, 87, 154);
            lblPrompt.Location = new Point(17, 22);
            lblPrompt.Margin = new Padding(4, 0, 4, 0);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(394, 45);
            lblPrompt.TabIndex = 2;
            lblPrompt.Text = "Выберите тип комнаты для поиска";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Segoe UI", 10F);
            radioButton1.ForeColor = Color.FromArgb(50, 50, 50);
            radioButton1.Location = new Point(81, 87);
            radioButton1.Margin = new Padding(4, 4, 4, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(104, 32);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "General";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 10F);
            radioButton2.ForeColor = Color.FromArgb(50, 50, 50);
            radioButton2.Location = new Point(244, 87);
            radioButton2.Margin = new Padding(4, 4, 4, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(65, 32);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "VIP";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // FindFreeSeatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(408, 226);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(lblPrompt);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FindFreeSeatForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск свободного места";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}