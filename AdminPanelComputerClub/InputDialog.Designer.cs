namespace AdminPanelComputerClub
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnOk;
        private Button btnCancel;
        private Label lblPrompt;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private TextBox inputBox;

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
            inputBox = new TextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.SteelBlue;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.ForeColor = Color.White;
            btnOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOk.Location = new Point(27, 165);
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
            btnCancel.Location = new Point(163, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPrompt.ForeColor = Color.DarkSlateBlue;
            lblPrompt.Location = new Point(14, 30);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(272, 35);
            lblPrompt.TabIndex = 2;
            lblPrompt.Text = "текст";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // inputBox
            // 
            inputBox.BackColor = Color.LightYellow;
            inputBox.Font = new Font("Segoe UI", 11F);
            inputBox.ForeColor = Color.DarkGreen;
            inputBox.Location = new Point(46, 90);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(208, 27);
            inputBox.TabIndex = 3;
            inputBox.TextAlign = HorizontalAlignment.Center;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 230);
            Controls.Add(inputBox);
            Controls.Add(lblPrompt);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InputDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}