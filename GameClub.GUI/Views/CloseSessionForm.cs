using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Views
{
    public partial class CloseSessionForm : Form, ICloseSessionView
    {
        // Результаты для вызывающего кода
        public int SelectedSeatId { get; private set; }
        public int SessionId { get; private set; }

        // Данные с формы, читаемые презентером
        public int SelectedComboSeatId
        {
            get
            {
                if (cmbActiveSeats.SelectedItem == null) return 0;
                dynamic item = cmbActiveSeats.SelectedItem;
                return item.Value;
            }
        }

        public event EventHandler ConfirmClose;
        public event EventHandler SeatSelectionChanged;

        public CloseSessionForm(IOperator operatorService)
        {
            InitializeComponent();

            cmbActiveSeats.SelectedIndexChanged += (s, e) => SeatSelectionChanged?.Invoke(this, EventArgs.Empty);

            btnClose.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    $"Закрыть сессию на месте #{SelectedComboSeatId}?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dynamic item = cmbActiveSeats.SelectedItem;
                    if (item != null) SelectedSeatId = item.Value;

                    ConfirmClose?.Invoke(this, EventArgs.Empty);
                }
            };

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        public void LoadActiveSeats(List<object> items)
        {
            Cursor = Cursors.Default;
            cmbActiveSeats.DisplayMember = "Text";
            cmbActiveSeats.ValueMember = "Value";
            cmbActiveSeats.DataSource = items;
            if (items.Count > 0) cmbActiveSeats.SelectedIndex = 0;
        }

        public void SetNoActiveSeats()
        {
            Cursor = Cursors.Default;
            cmbActiveSeats.Items.Add("Нет активных мест");
            cmbActiveSeats.Enabled = false;
            btnClose.Enabled = false;
            lblSessionInfo.Text = "Нет активных сессий";
            lblSessionInfo.ForeColor = Color.Red;
        }

        public void UpdateSessionInfo(string text)
        {
            lblSessionInfo.Text = text;
            lblSessionInfo.ForeColor = Color.DarkRed;
            btnClose.Enabled = true;

        }

        public void SetSessionId(int sessionId) => SessionId = sessionId;
        public void SetSelectedSeatId(int seatId) => SelectedSeatId = seatId;

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
