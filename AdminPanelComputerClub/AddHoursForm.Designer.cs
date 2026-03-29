namespace AdminPanelComputerClub
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
            this.lblSeatId = new Label();
            this.txtSeatId = new TextBox();
            this.lblHours = new Label();
            this.nudHours = new NumericUpDown();
            this.lblSessionInfo = new Label();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            this.SuspendLayout();

            // lblSeatId
            this.lblSeatId.AutoSize = true;
            this.lblSeatId.Location = new Point(20, 20);
            this.lblSeatId.Name = "lblSeatId";
            this.lblSeatId.Size = new Size(124, 20);
            this.lblSeatId.TabIndex = 0;
            this.lblSeatId.Text = "Номер ПК:";

            // txtSeatId
            this.txtSeatId.Location = new Point(150, 17);
            this.txtSeatId.Name = "txtSeatId";
            this.txtSeatId.Size = new Size(100, 23);
            this.txtSeatId.TabIndex = 1;

            // lblHours
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new Point(20, 60);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new Size(168, 20);
            this.lblHours.TabIndex = 2;
            this.lblHours.Text = "Дополнительно часов:";

            // nudHours
            this.nudHours.Location = new Point(150, 57);
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new Size(100, 23);
            this.nudHours.TabIndex = 3;
            this.nudHours.Minimum = 1;
            this.nudHours.Maximum = 24;
            this.nudHours.Value = 1;

            // lblSessionInfo
            this.lblSessionInfo.BackColor = System.Drawing.Color.LightGray;
            this.lblSessionInfo.BorderStyle = BorderStyle.FixedSingle;
            this.lblSessionInfo.Location = new Point(20, 100);
            this.lblSessionInfo.Name = "lblSessionInfo";
            this.lblSessionInfo.Size = new Size(330, 120);
            this.lblSessionInfo.TabIndex = 4;
            this.lblSessionInfo.Text = "Введите номер ПК...";
            this.lblSessionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnOk
            this.btnOk.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOk.FlatStyle = FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new Point(20, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(100, 35);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Добавить";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += btnOk_Click;
            this.btnOk.Enabled = false;

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new Point(250, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += btnCancel_Click;

            // AddHoursForm
            this.AutoScaleDimensions = new SizeF(7F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(370, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSessionInfo);
            this.Controls.Add(this.nudHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtSeatId);
            this.Controls.Add(this.lblSeatId);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddHoursForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавление часов";
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}