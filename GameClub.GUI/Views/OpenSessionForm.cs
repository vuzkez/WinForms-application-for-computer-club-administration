using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Enums;

namespace GameClub.GUI.Views
{
    public partial class OpenSessionForm : Form, IOpenSessionView
    {
        public int SelectedSeatId { get; private set; }
        public TariffType SelectedTariff { get; private set; }
        public DateTime StartTime { get; private set; }
        public int Hours { get; private set; }

        public string SeatIdText => textBox2.Text;
        public bool IsSeatPreselected => lblSelectedSeatInfo.Visible;
        public bool IsDayTariffSelected => radioButton1.Checked;
        public bool IsNightTariffSelected => radioButton2.Checked;
        public string HoursText => textBox3.Text;

        public event EventHandler ConfirmOpen;
        public event EventHandler FormLoaded;

        public OpenSessionForm(
            Library.ServiceInterfaces.IOperator operatorService,
            Library.ServiceInterfaces.IAdministrator adminService,
            int seatId)
        {
            InitializeComponent();

            textBox3.Text = "1";
            textBox2.Visible = false;
            lblSelectedSeatInfo.Visible = true;
            lblSelectedSeatInfo.Text = $"Место: {seatId}";
            SelectedSeatId = seatId;

            btnOk.Click += (s, e) =>
            {
                if (!IsSeatPreselected && int.TryParse(SeatIdText, out int sid))
                    SelectedSeatId = sid;

                SelectedTariff = radioButton1.Checked ? TariffType.Day : TariffType.Night;
                StartTime = DateTime.Now;
                if (int.TryParse(HoursText, out int h)) Hours = h;

                ConfirmOpen?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            Load += (s, e) => FormLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void SetDayTariffLabel(string text) => radioButton1.Text = text;
        public void SetNightTariffLabel(string text) => radioButton2.Text = text;
        public void SetCurrentDateTime(string text) => label1.Text = text;

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
