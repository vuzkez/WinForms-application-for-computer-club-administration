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
            btnOk.Location = new Point(12, 105);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(102, 37);
            btnOk.TabIndex = 0;
            btnOk.Text = "Ок";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(151, 105);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 37);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.Location = new Point(12, 21);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(248, 28);
            lblPrompt.TabIndex = 2;
            lblPrompt.Text = "Выберите тип комнаты для поиска";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(49, 64);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(65, 20);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "General";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(151, 64);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(42, 20);
            radioButton2.TabIndex = 0;
            radioButton2.TabStop = true;
            radioButton2.Text = "Vip";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // FindFreeSeatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 162);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(lblPrompt);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "FindFreeSeatForm";
            Text = "InputDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}