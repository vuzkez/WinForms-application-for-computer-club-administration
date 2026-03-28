namespace AdminPanelComputerClub
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            btnOk.Location = new Point(12, 135);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(102, 37);
            btnOk.TabIndex = 0;
            btnOk.Text = "Ок";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(151, 135);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 37);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblPrompt
            // 
            lblPrompt.Location = new Point(14, 39);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(248, 28);
            lblPrompt.TabIndex = 2;
            lblPrompt.Text = "label1";
            lblPrompt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // inputBox
            // 
            inputBox.Location = new Point(46, 81);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(165, 23);
            inputBox.TabIndex = 3;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 191);
            Controls.Add(inputBox);
            Controls.Add(lblPrompt);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "InputDialog";
            Text = "InputDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private Label lblPrompt;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private TextBox inputBox;
    }
}