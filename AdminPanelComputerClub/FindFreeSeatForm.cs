using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanelComputerClub
{
    public partial class FindFreeSeatForm : Form
    {
        public string Result { get; private set; }
        public FindFreeSeatForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Result = "General";
            else if (radioButton2.Checked)
                Result = "Vip";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
