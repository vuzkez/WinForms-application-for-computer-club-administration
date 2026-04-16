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
    public partial class InputDialog : Form
    {
        public string Result { get; private set; }

        public InputDialog(string prompt, string title)
        {
            InitializeComponent();
            Text = title;
            lblPrompt.Text = prompt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Result = inputBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}