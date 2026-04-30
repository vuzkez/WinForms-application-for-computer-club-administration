namespace GameClub.GUI
{
    partial class CloseSessionForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbActiveSeats;
        private Label lblSelectSeat;
        private Label lblSessionInfo;
        private Button btnClose;
        private Button btnCancel;

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
            cmbActiveSeats = new ComboBox();
            lblSelectSeat = new Label();
            lblSessionInfo = new Label();
            btnClose = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbActiveSeats
            // 
            cmbActiveSeats.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActiveSeats.Font = new Font("Segoe UI", 10F);
            cmbActiveSeats.Location = new Point(157, 14);
            cmbActiveSeats.Margin = new Padding(3, 2, 3, 2);
            cmbActiveSeats.Name = "cmbActiveSeats";
            cmbActiveSeats.Size = new Size(263, 25);
            cmbActiveSeats.TabIndex = 1;
            cmbActiveSeats.SelectedIndexChanged += cmbActiveSeats_SelectedIndexChanged;
            // 
            // lblSelectSeat
            // 
            lblSelectSeat.AutoSize = true;
            lblSelectSeat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSelectSeat.Location = new Point(10, 16);
            lblSelectSeat.Name = "lblSelectSeat";
            lblSelectSeat.Size = new Size(140, 20);
            lblSelectSeat.TabIndex = 0;
            lblSelectSeat.Text = "Выберите сессию:";
            // 
            // lblSessionInfo
            // 
            lblSessionInfo.BackColor = Color.LightGray;
            lblSessionInfo.BorderStyle = BorderStyle.FixedSingle;
            lblSessionInfo.Font = new Font("Segoe UI", 10F);
            lblSessionInfo.Location = new Point(10, 52);
            lblSessionInfo.Name = "lblSessionInfo";
            lblSessionInfo.Size = new Size(409, 229);
            lblSessionInfo.TabIndex = 2;
            lblSessionInfo.Text = "Выберите активную сессию из списка...";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.DarkRed;
            btnClose.Enabled = false;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(10, 292);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 36);
            btnClose.TabIndex = 3;
            btnClose.Text = "Закрыть сессию";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(306, 292);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 36);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // CloseSessionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 339);
            Controls.Add(btnCancel);
            Controls.Add(btnClose);
            Controls.Add(lblSessionInfo);
            Controls.Add(cmbActiveSeats);
            Controls.Add(lblSelectSeat);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CloseSessionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Закрытие сессии";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}