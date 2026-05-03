using System.Windows.Forms;

namespace GameClub.GUI
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
            dgvOperators = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            lblLogin = new Label();
            lblPassword = new Label();
            lblFullName = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            lblSelected = new Label();
            grpList = new GroupBox();
            grpForm = new GroupBox();
            grpList.SuspendLayout();
            grpForm.SuspendLayout();
            SuspendLayout();
            // 
            // dgvOperators
            // 
            dgvOperators.AllowUserToAddRows = false;
            dgvOperators.AllowUserToDeleteRows = false;
            dgvOperators.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvOperators.BackgroundColor = Color.FromArgb(25, 25, 34);
            dgvOperators.BorderStyle = BorderStyle.None;
            dgvOperators.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 42);
            dgvOperators.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(150, 150, 175);
            dgvOperators.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperators.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 34);
            dgvOperators.DefaultCellStyle.ForeColor = Color.FromArgb(210, 210, 230);
            dgvOperators.DefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 80, 120);
            dgvOperators.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvOperators.GridColor = Color.FromArgb(60, 60, 80);
            dgvOperators.Columns.Clear();
            dgvOperators.Columns.Add("UserId", "ID");
            dgvOperators.Columns.Add("Login", "Логин");
            dgvOperators.Columns.Add("Password", "Пароль");
            dgvOperators.Columns.Add("FullName", "ФИО");
            dgvOperators.Columns["UserId"].Width = 50;
            dgvOperators.Columns["Login"].Width = 90;
            dgvOperators.Columns["Password"].Width = 90;
            dgvOperators.Columns["FullName"].Width = 150;
            dgvOperators.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOperators.Location = new Point(6, 28);
            dgvOperators.MultiSelect = false;
            dgvOperators.Name = "dgvOperators";
            dgvOperators.ReadOnly = true;
            dgvOperators.RowHeadersVisible = false;
            dgvOperators.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperators.Size = new Size(438, 310);
            dgvOperators.TabIndex = 0;
            dgvOperators.SelectionChanged += dgvOperators_SelectionChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(30, 100, 160);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 225);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(161, 40);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(150, 80, 10);
            btnEdit.Enabled = false;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(20, 271);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(161, 40);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(140, 30, 30);
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(187, 225);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 40);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(55, 55, 70);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(180, 180, 200);
            btnClear.Location = new Point(187, 271);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(103, 40);
            btnClear.TabIndex = 9;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(55, 55, 70);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(180, 180, 200);
            btnCancel.Location = new Point(612, 405);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 45);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Закрыть";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 190, 180);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(760, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Управление операторами";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 10F);
            lblLogin.ForeColor = Color.FromArgb(140, 140, 165);
            lblLogin.Location = new Point(20, 35);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(50, 19);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(140, 140, 165);
            lblPassword.Location = new Point(20, 95);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 19);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.ForeColor = Color.FromArgb(140, 140, 165);
            lblFullName.Location = new Point(20, 155);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(43, 19);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "ФИО:";
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.FromArgb(35, 35, 50);
            txtLogin.BorderStyle = BorderStyle.FixedSingle;
            txtLogin.Font = new Font("Segoe UI", 10F);
            txtLogin.ForeColor = Color.FromArgb(210, 210, 230);
            txtLogin.Location = new Point(20, 58);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(260, 25);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(35, 35, 50);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.FromArgb(210, 210, 230);
            txtPassword.Location = new Point(20, 118);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(260, 25);
            txtPassword.TabIndex = 3;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(35, 35, 50);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.ForeColor = Color.FromArgb(210, 210, 230);
            txtFullName.Location = new Point(20, 178);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(260, 25);
            txtFullName.TabIndex = 5;
            // 
            // lblSelected
            // 
            lblSelected.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSelected.ForeColor = Color.FromArgb(100, 220, 100);
            lblSelected.Location = new Point(6, 345);
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new Size(438, 45);
            lblSelected.TabIndex = 1;
            lblSelected.Text = "Выберите оператора из списка";
            lblSelected.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpList
            // 
            grpList.BackColor = Color.FromArgb(28, 28, 38);
            grpList.Controls.Add(dgvOperators);
            grpList.Controls.Add(lblSelected);
            grpList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpList.ForeColor = Color.FromArgb(0, 190, 180);
            grpList.Location = new Point(12, 55);
            grpList.Name = "grpList";
            grpList.Size = new Size(450, 400);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Список операторов";
            // 
            // grpForm
            // 
            grpForm.BackColor = Color.FromArgb(28, 28, 38);
            grpForm.Controls.Add(lblLogin);
            grpForm.Controls.Add(txtLogin);
            grpForm.Controls.Add(lblPassword);
            grpForm.Controls.Add(txtPassword);
            grpForm.Controls.Add(lblFullName);
            grpForm.Controls.Add(txtFullName);
            grpForm.Controls.Add(btnAdd);
            grpForm.Controls.Add(btnEdit);
            grpForm.Controls.Add(btnDelete);
            grpForm.Controls.Add(btnClear);
            grpForm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpForm.ForeColor = Color.FromArgb(0, 190, 180);
            grpForm.Location = new Point(468, 55);
            grpForm.Name = "grpForm";
            grpForm.Size = new Size(304, 340);
            grpForm.TabIndex = 2;
            grpForm.TabStop = false;
            grpForm.Text = "Добавить / Редактировать оператора";
            // 
            // OperatorsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 24);
            ClientSize = new Size(784, 465);
            Controls.Add(btnCancel);
            Controls.Add(grpForm);
            Controls.Add(grpList);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OperatorsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Управление операторами";
            grpList.ResumeLayout(false);
            grpForm.ResumeLayout(false);
            grpForm.PerformLayout();
            ResumeLayout(false);
        }
    }
}