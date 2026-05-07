namespace GameClub.GUI
{
    partial class FreeSeatsForm
    {
        private System.Windows.Forms.DataGridView dgvSeats;
        private System.Windows.Forms.Button btnOpenSession;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectedSeat;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvSeats = new DataGridView();
            btnOpenSession = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            lblSelectedSeat = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSeats).BeginInit();
            SuspendLayout();
            // 
            // dgvSeats
            // 
            dgvSeats.AllowUserToAddRows = false;
            dgvSeats.AllowUserToDeleteRows = false;
            dgvSeats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSeats.BackgroundColor = Color.White;
            dgvSeats.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSeats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSeats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(200, 215, 235);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 30, 30);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSeats.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSeats.GridColor = Color.FromArgb(230, 230, 230);
            dgvSeats.Location = new Point(17, 80);
            dgvSeats.Margin = new Padding(4, 5, 4, 5);
            dgvSeats.MultiSelect = false;
            dgvSeats.Name = "dgvSeats";
            dgvSeats.ReadOnly = true;
            dgvSeats.RowHeadersVisible = false;
            dgvSeats.RowHeadersWidth = 62;
            dgvSeats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeats.Size = new Size(1380, 448);
            dgvSeats.TabIndex = 0;
            dgvSeats.CellDoubleClick += dgvSeats_CellDoubleClick;
            dgvSeats.SelectionChanged += dgvSeats_SelectionChanged;
            // 
            // btnOpenSession
            // 
            btnOpenSession.BackColor = Color.FromArgb(43, 87, 154);
            btnOpenSession.FlatAppearance.BorderSize = 0;
            btnOpenSession.FlatStyle = FlatStyle.Flat;
            btnOpenSession.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenSession.ForeColor = Color.White;
            btnOpenSession.Location = new Point(17, 592);
            btnOpenSession.Margin = new Padding(4, 5, 4, 5);
            btnOpenSession.Name = "btnOpenSession";
            btnOpenSession.Size = new Size(214, 64);
            btnOpenSession.TabIndex = 1;
            btnOpenSession.Text = "Открыть сессию";
            btnOpenSession.UseVisualStyleBackColor = false;
            btnOpenSession.Click += btnOpenSession_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(107, 107, 107);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1183, 592);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(214, 64);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(26, 26, 46);
            lblTitle.Location = new Point(17, 24);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1380, 48);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Список свободных ПК";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSelectedSeat
            // 
            lblSelectedSeat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedSeat.ForeColor = Color.FromArgb(43, 87, 154);
            lblSelectedSeat.Location = new Point(13, 547);
            lblSelectedSeat.Margin = new Padding(4, 0, 4, 0);
            lblSelectedSeat.Name = "lblSelectedSeat";
            lblSelectedSeat.Size = new Size(1384, 40);
            lblSelectedSeat.TabIndex = 4;
            lblSelectedSeat.Text = "Выберите ПК из списка";
            lblSelectedSeat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FreeSeatsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1410, 680);
            Controls.Add(lblSelectedSeat);
            Controls.Add(lblTitle);
            Controls.Add(btnCancel);
            Controls.Add(btnOpenSession);
            Controls.Add(dgvSeats);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FreeSeatsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Свободные компьютеры";
            ((System.ComponentModel.ISupportInitialize)dgvSeats).EndInit();
            ResumeLayout(false);
        }
    }
}