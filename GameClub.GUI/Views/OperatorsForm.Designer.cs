namespace GameClub.GUI.Views
{
    partial class OperatorsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvOperators;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;
        private Label lblFullName;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private Label lblSelected;
        private GroupBox grpList;
        private GroupBox grpForm;

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
            this.dgvOperators = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.grpForm = new System.Windows.Forms.GroupBox();
            this.grpList.SuspendLayout();
            this.grpForm.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvOperators
            //
            this.dgvOperators.AllowUserToAddRows = false;
            this.dgvOperators.AllowUserToDeleteRows = false;
            this.dgvOperators.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvOperators.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperators.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.dgvOperators.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.dgvOperators.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperators.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvOperators.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvOperators.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvOperators.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(200, 215, 235);
            this.dgvOperators.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvOperators.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvOperators.Columns.Clear();
            this.dgvOperators.Columns.Add("UserId", "ID");
            this.dgvOperators.Columns.Add("Login", "Логин");
            this.dgvOperators.Columns.Add("Password", "Пароль");
            this.dgvOperators.Columns.Add("FullName", "ФИО");
            this.dgvOperators.Columns["UserId"].Width = 50;
            this.dgvOperators.Columns["Login"].Width = 90;
            this.dgvOperators.Columns["Password"].Width = 90;
            this.dgvOperators.Columns["FullName"].Width = 150;
            this.dgvOperators.Columns["FullName"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvOperators.Location = new System.Drawing.Point(6, 28);
            this.dgvOperators.MultiSelect = false;
            this.dgvOperators.Name = "dgvOperators";
            this.dgvOperators.ReadOnly = true;
            this.dgvOperators.RowHeadersVisible = false;
            this.dgvOperators.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperators.Size = new System.Drawing.Size(438, 310);
            this.dgvOperators.TabIndex = 0;
            this.dgvOperators.SelectionChanged += new System.EventHandler(this.dgvOperators_SelectionChanged);
            //
            // btnAdd
            //
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 225);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 40);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(20, 271);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(161, 40);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(187, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 40);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClear
            //
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(107, 107, 107);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(187, 271);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 40);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(107, 107, 107);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(612, 405);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 45);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(26, 26, 46);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Управление операторами";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblLogin
            //
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblLogin.Location = new System.Drawing.Point(20, 35);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(50, 19);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин:";
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPassword.Location = new System.Drawing.Point(20, 95);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 19);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Пароль:";
            //
            // lblFullName
            //
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFullName.Location = new System.Drawing.Point(20, 155);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(43, 19);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "ФИО:";
            //
            // txtLogin
            //
            this.txtLogin.BackColor = System.Drawing.Color.White;
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLogin.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtLogin.Location = new System.Drawing.Point(20, 58);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(260, 25);
            this.txtLogin.TabIndex = 1;
            //
            // txtPassword
            //
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtPassword.Location = new System.Drawing.Point(20, 118);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(260, 25);
            this.txtPassword.TabIndex = 3;
            //
            // txtFullName
            //
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtFullName.Location = new System.Drawing.Point(20, 178);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(260, 25);
            this.txtFullName.TabIndex = 5;
            //
            // lblSelected
            //
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelected.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.lblSelected.Location = new System.Drawing.Point(6, 345);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(438, 45);
            this.lblSelected.TabIndex = 1;
            this.lblSelected.Text = "Выберите оператора из списка";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // grpList
            //
            this.grpList.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.grpList.Controls.Add(this.dgvOperators);
            this.grpList.Controls.Add(this.lblSelected);
            this.grpList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpList.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.grpList.Location = new System.Drawing.Point(12, 55);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(450, 400);
            this.grpList.TabIndex = 1;
            this.grpList.TabStop = false;
            this.grpList.Text = "Список операторов";
            //
            // grpForm
            //
            this.grpForm.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.grpForm.Controls.Add(this.lblLogin);
            this.grpForm.Controls.Add(this.txtLogin);
            this.grpForm.Controls.Add(this.lblPassword);
            this.grpForm.Controls.Add(this.txtPassword);
            this.grpForm.Controls.Add(this.lblFullName);
            this.grpForm.Controls.Add(this.txtFullName);
            this.grpForm.Controls.Add(this.btnAdd);
            this.grpForm.Controls.Add(this.btnEdit);
            this.grpForm.Controls.Add(this.btnDelete);
            this.grpForm.Controls.Add(this.btnClear);
            this.grpForm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpForm.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.grpForm.Location = new System.Drawing.Point(468, 55);
            this.grpForm.Name = "grpForm";
            this.grpForm.Size = new System.Drawing.Size(304, 340);
            this.grpForm.TabIndex = 2;
            this.grpForm.TabStop = false;
            this.grpForm.Text = "Добавить / Редактировать";
            //
            // OperatorsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(784, 465);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpForm);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление операторами";
            this.grpList.ResumeLayout(false);
            this.grpForm.ResumeLayout(false);
            this.grpForm.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}