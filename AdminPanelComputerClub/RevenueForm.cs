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
    public partial class RevenueForm : Form
    {
        private readonly IAdministrator _adminService;

        public RevenueForm(IAdministrator adminService)
        {
            InitializeComponent();
            _adminService = adminService;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                decimal revenue = _adminService.GetRevenue(from, to);

                txtTotal.Text = $"{revenue:N2} руб";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении выручки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
