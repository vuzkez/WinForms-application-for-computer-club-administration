using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Views
{
    public partial class FindFreeSeatForm : Form, IFindFreeSeatView
    {
        public string Result { get; private set; }

        public event EventHandler ConfirmSelection;

        public FindFreeSeatForm()
        {
            InitializeComponent();

            btnOk.Click += (s, e) =>
            {
                if (radioButton1.Checked)
                    Result = "General";
                else if (radioButton2.Checked)
                    Result = "Vip";
                else
                    Result = null;

                ConfirmSelection?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) => Close();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
