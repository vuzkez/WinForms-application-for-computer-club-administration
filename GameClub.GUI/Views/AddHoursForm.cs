using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI.Views
{
    public partial class AddHoursForm : Form, IAddHoursView
    {
        public int SelectedSeatId { get; private set; }
        public int AdditionalHours { get; private set; }
        public int SessionId { get; private set; }

        public int SelectedComboSeatId
        {
            get
            {
                if (cmbActiveSeats.SelectedItem == null) return 0;
                dynamic item = cmbActiveSeats.SelectedItem;
                return item.Value;
            }
        }
        public int NudHoursValue => (int)nudHours.Value;

        public event EventHandler ConfirmAddHours;
        public event EventHandler SeatSelectionChanged;

        public AddHoursForm(IOperator operatorService)
        {
            InitializeComponent();
            nudHours.Minimum = 1;
            nudHours.Maximum = 24;
            nudHours.Value = 1;

            cmbActiveSeats.SelectedIndexChanged += (s, e) => SeatSelectionChanged?.Invoke(this, EventArgs.Empty);

            btnOk.Click += (s, e) =>
            {
                dynamic item = cmbActiveSeats.SelectedItem;
                if (item != null)
                {
                    SelectedSeatId = item.Value;
                    AdditionalHours = (int)nudHours.Value;
                }
                ConfirmAddHours?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        public void LoadActiveSeats(List<object> items)
        {
            cmbActiveSeats.DisplayMember = "Text";
            cmbActiveSeats.ValueMember = "Value";
            cmbActiveSeats.DataSource = items;
            cmbActiveSeats.SelectedIndex = 0;
        }

        public void SetNoActiveSeats()
        {
            cmbActiveSeats.Items.Add("Нет активных мест");
            cmbActiveSeats.Enabled = false;
            btnOk.Enabled = false;
            lblSessionInfo.Text = "Нет активных сессий";
        }

        public void UpdateSessionInfo(string text, bool isValid)
        {
            lblSessionInfo.Text = text;
            lblSessionInfo.ForeColor = isValid ? Color.Green : Color.Red;
            btnOk.Enabled = isValid;
        }

        public void SetSessionId(int sessionId) => SessionId = sessionId;

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public new void Close() => base.Close();
    }
}
