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
using AdminPanelLibrary.Enums;

namespace AdminPanelComputerClub
{
    public partial class AddHoursForm : Form
    {
        public int SelectedSeatId { get; private set; }
        public int AdditionalHours { get; private set; }
        public int SessionId { get; private set; }

        private readonly IOperator _operatorService;

        public AddHoursForm(IOperator operatorService)
        {
            InitializeComponent();
            _operatorService = operatorService;

            nudHours.Minimum = 1;
            nudHours.Maximum = 24;
            nudHours.Value = 1;

            txtSeatId.TextChanged += TxtSeatId_TextChanged;
            nudHours.ValueChanged += NudHours_ValueChanged;
        }

        private void TxtSeatId_TextChanged(object sender, EventArgs e)
        {
            UpdateSessionInfo();
        }

        private void NudHours_ValueChanged(object sender, EventArgs e)
        {
            UpdateSessionInfo();
        }

        private void UpdateSessionInfo()
        {
            if (!int.TryParse(txtSeatId.Text, out int seatId))
            {
                ClearSessionInfo();
                return;
            }

            var activeSession = _operatorService.GetActiveSessionBySeatId(seatId);

            if (activeSession != null)
            {
                var remaining = activeSession.EndTime - DateTime.Now;
                lblSessionInfo.Text =
                    $"Сессия найдена!\n" +
                    $"ID сессии: {activeSession.SessionId}\n" +
                    $"Начало: {activeSession.StartTime:dd.MM.yyyy HH:mm}\n" +
                    $"Окончание: {activeSession.EndTime:dd.MM.yyyy HH:mm}\n" +
                    $"Осталось: {remaining.Hours}ч {remaining.Minutes}мин\n" +
                    $"Тариф: {(activeSession.Tariff == TariffType.Day ? "Дневной" : "Ночной")}\n" +
                    $"Текущая сумма: {activeSession.TotalAmount} руб";

                lblSessionInfo.ForeColor = Color.Green;
                SessionId = activeSession.SessionId;
                btnOk.Enabled = true;
            }
            else
            {
                lblSessionInfo.Text = "На данном ПК нет активной сессии.";
                lblSessionInfo.ForeColor = Color.Red;
                SessionId = 0;
                btnOk.Enabled = false;
            }
        }

        private void ClearSessionInfo()
        {
            lblSessionInfo.Text = "Введите номер ПК...";
            lblSessionInfo.ForeColor = Color.Gray;
            SessionId = 0;
            btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSeatId.Text, out int seatId))
            {
                MessageBox.Show("Введите корректный номер ПК.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var activeSession = _operatorService.GetActiveSessionBySeatId(seatId);

            if (activeSession == null)
            {
                MessageBox.Show($"На ПК #{seatId} нет активной сессии.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hours = (int)nudHours.Value;

            var confirmResult = MessageBox.Show(
                $"Добавить {hours} час(ов) к сессии на ПК #{seatId}?\n\n" +
                $"Текущее окончание: {activeSession.EndTime:dd.MM.yyyy HH:mm}\n" +
                $"Новое окончание: {activeSession.EndTime.AddHours(hours):dd.MM.yyyy HH:mm}\n" +
                $"Дополнительная сумма: {activeSession.TotalAmount} руб",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                SelectedSeatId = seatId;
                AdditionalHours = hours;
                SessionId = activeSession.SessionId;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
