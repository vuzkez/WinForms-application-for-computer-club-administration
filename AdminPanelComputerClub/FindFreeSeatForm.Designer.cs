namespace AdminPanelComputerClub
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
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
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
            sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.SteelBlue;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.Location = new Point(27, 145);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(110, 40);
            btnOk.TabIndex = 0;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(163, 145);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPrompt.ForeColor = Color.DarkSlateBlue;
            lblPrompt.Location = new Point(12, 15);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(276, 30);
            lblPrompt.TabIndex = 2;
            lblPrompt.Text = "Выберите тип комнаты для поиска";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            radioButton1.ForeColor = Color.SteelBlue;
            radioButton1.Location = new Point(49, 70);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(87, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "General";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            radioButton2.ForeColor = Color.DarkGoldenrod;
            radioButton2.Location = new Point(175, 70);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(58, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "VIP";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // FindFreeSeatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 210);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(lblPrompt);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
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