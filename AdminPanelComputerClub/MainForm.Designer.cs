namespace AdminPanelComputerClub
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpSeatMap;
        private Panel pnlBottom;
        private Button btnFindFreeSeat;
        private Button btnRefresh;
        private Button btnRevenue;
        private Button btnAdminPanel;
        private Button btnLogout;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

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
            flpSeatMap = new FlowLayoutPanel();
            pnlBottom = new Panel();
            btnFindFreeSeat = new Button();
            btnRefresh = new Button();
            btnRevenue = new Button();
            btnAdminPanel = new Button();
            btnLogout = new Button();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            pnlBottom.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // flpSeatMap
            // 
            flpSeatMap.AutoScroll = true;
            flpSeatMap.Dock = DockStyle.Fill;
            flpSeatMap.Location = new Point(0, 0);
            flpSeatMap.Name = "flpSeatMap";
            flpSeatMap.Padding = new Padding(10, 11, 10, 11);
            flpSeatMap.Size = new Size(984, 547);
            flpSeatMap.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = SystemColors.ControlDark;
            pnlBottom.Controls.Add(btnFindFreeSeat);
            pnlBottom.Controls.Add(btnRefresh);
            pnlBottom.Controls.Add(btnRevenue);
            pnlBottom.Controls.Add(btnAdminPanel);
            pnlBottom.Controls.Add(btnLogout);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 547);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(984, 64);
            pnlBottom.TabIndex = 1;
            // 
            // btnFindFreeSeat
            // 
            btnFindFreeSeat.BackColor = Color.SteelBlue;
            btnFindFreeSeat.FlatStyle = FlatStyle.Flat;
            btnFindFreeSeat.ForeColor = Color.White;
            btnFindFreeSeat.Location = new Point(12, 13);
            btnFindFreeSeat.Name = "btnFindFreeSeat";
            btnFindFreeSeat.Size = new Size(150, 38);
            btnFindFreeSeat.TabIndex = 0;
            btnFindFreeSeat.Text = "Найти свободный ПК";
            btnFindFreeSeat.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DarkGreen;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(178, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 38);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить карту";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnRevenue
            // 
            btnRevenue.BackColor = Color.DarkOrange;
            btnRevenue.FlatStyle = FlatStyle.Flat;
            btnRevenue.ForeColor = Color.White;
            btnRevenue.Location = new Point(324, 13);
            btnRevenue.Name = "btnRevenue";
            btnRevenue.Size = new Size(120, 38);
            btnRevenue.TabIndex = 2;
            btnRevenue.Text = "Выручка";
            btnRevenue.UseVisualStyleBackColor = false;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.BackColor = Color.Purple;
            btnAdminPanel.FlatStyle = FlatStyle.Flat;
            btnAdminPanel.ForeColor = Color.White;
            btnAdminPanel.Location = new Point(460, 13);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new Size(130, 38);
            btnAdminPanel.TabIndex = 3;
            btnAdminPanel.Text = "Админ панель";
            btnAdminPanel.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(881, 13);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 38);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip.Location = new Point(0, 611);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(984, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(88, 17);
            lblStatus.Text = "Готов к работе";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 633);
            Controls.Add(flpSeatMap);
            Controls.Add(pnlBottom);
            Controls.Add(statusStrip);
            MinimumSize = new Size(800, 637);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameClub";
            pnlBottom.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}