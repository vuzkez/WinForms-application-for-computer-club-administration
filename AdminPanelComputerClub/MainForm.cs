using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminPanelLibrary;

namespace AdminPanelComputerClub
{
    public partial class MainForm : Form
    {
        private readonly User user;
        private readonly IDataContext dataContext;
        private readonly IOperator operatorService;
        private readonly IAdministrator administratorService;
        public MainForm(User user, IOperator operatorService, IAdministrator administratorService, IDataContext dataContext)
        {
            this.user = user;
            this.operatorService = operatorService;
            this.administratorService = administratorService;
            this.dataContext = dataContext;
            InitializeComponent();
            ConfigureUIByRole();
        }

        private void ConfigureUIByRole()
        {
            if (user.UserRole == UserRole.Administrator)
            {
                btnRevenue.Visible = true;
                btnAdminPanel.Visible = true;
                this.Text = "GameClub - Администратор";
            }
            else
            {
                btnRevenue.Visible = false;
                btnAdminPanel.Visible = false;
                this.Text = "GameClub - Оператор";
            }
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            using (var db = dataContext.Create())
            {
                var userFromDb = db.GetTable<User>().FirstOrDefault(u => u.UserId == user.UserId);
                if (userFromDb != null)
                {
                    userFromDb.IsActive = false;
                    db.SubmitChanges();
                }
            }
        }
    }
}
