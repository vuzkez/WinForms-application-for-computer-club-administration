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
        private readonly IOperator operatorService;
        private readonly IAdministrator administratorService;
        private readonly IDataContext dataContext;
        public MainForm(User user,IOperator operatorService, IAdministrator administratorService, IDataContext dataContext)
        {
            InitializeComponent();
            this.user = user;
            this.operatorService = operatorService;
            this.administratorService = administratorService;
            this.dataContext = dataContext;
        }

    }
}
