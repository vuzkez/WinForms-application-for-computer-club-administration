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
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            this.btnOpenSession = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelectedSeat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSeats
            // 
            this.dgvSeats.AllowUserToAddRows = false;
            this.dgvSeats.AllowUserToDeleteRows = false;
            this.dgvSeats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeats.BackgroundColor = Color.FromArgb(25, 25, 34);
            this.dgvSeats.BorderStyle = BorderStyle.None;
            this.dgvSeats.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 42);
            this.dgvSeats.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(150, 150, 175);
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 34);
            this.dgvSeats.DefaultCellStyle.ForeColor = Color.FromArgb(210, 210, 230);
            this.dgvSeats.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 80, 120);
            this.dgvSeats.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvSeats.GridColor = Color.FromArgb(60, 60, 80);
            this.dgvSeats.Location = new System.Drawing.Point(12, 50);
            this.dgvSeats.MultiSelect = false;
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.ReadOnly = true;
            this.dgvSeats.RowHeadersVisible = false;
            this.dgvSeats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeats.Size = new System.Drawing.Size(560, 280);
            this.dgvSeats.TabIndex = 0;
            this.dgvSeats.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeats_CellDoubleClick);
            this.dgvSeats.SelectionChanged += new System.EventHandler(this.dgvSeats_SelectionChanged);
            // 
            // btnOpenSession
            // 
            this.btnOpenSession.BackColor = Color.FromArgb(30, 100, 160);
            this.btnOpenSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSession.FlatAppearance.BorderSize = 0;
            this.btnOpenSession.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenSession.ForeColor = System.Drawing.Color.White;
            this.btnOpenSession.Location = new System.Drawing.Point(12, 370);
            this.btnOpenSession.Name = "btnOpenSession";
            this.btnOpenSession.Size = new System.Drawing.Size(150, 40);
            this.btnOpenSession.TabIndex = 1;
            this.btnOpenSession.Text = "Открыть сессию";
            this.btnOpenSession.UseVisualStyleBackColor = false;
            this.btnOpenSession.Click += new System.EventHandler(this.btnOpenSession_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(140, 30, 30);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(422, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(0, 190, 180);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 30);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Список свободных ПК";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedSeat
            // 
            this.lblSelectedSeat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectedSeat.ForeColor = Color.FromArgb(100, 220, 100);
            this.lblSelectedSeat.Location = new System.Drawing.Point(12, 340);
            this.lblSelectedSeat.Name = "lblSelectedSeat";
            this.lblSelectedSeat.Size = new System.Drawing.Size(560, 25);
            this.lblSelectedSeat.TabIndex = 4;
            this.lblSelectedSeat.Text = "Выберите ПК из списка";
            this.lblSelectedSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FreeSeatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(18, 18, 24);
            this.ClientSize = new System.Drawing.Size(584, 425);
            this.Controls.Add(this.lblSelectedSeat);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenSession);
            this.Controls.Add(this.dgvSeats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FreeSeatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Свободные компьютеры";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);
        }
    }
}