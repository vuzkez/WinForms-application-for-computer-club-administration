using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;
using AdminPanelLibrary.Repositories;

namespace AdminPanelComputerClub
{
    public partial class OpenSessionForm : Form
    {
        public int SelectedSeatId { get; private set; }
        public TariffType SelectedTariff { get; private set; }
        public DateTime StartTime { get; private set; }
        public int Hours { get; private set; }

        private readonly ISeatRepository _seatRepo;
        private readonly ITariffSettingRepository _tariffRepo;
        private readonly ISessionRepository _sessionRepo;
        private decimal dayPrice;
        private decimal nightPrice;

        public OpenSessionForm(
            ISeatRepository seatRepo,
            ITariffSettingRepository tariffRepo,
            ISessionRepository sessionRepo)
        {
            InitializeComponent();

            try
            {
                _seatRepo = seatRepo;
                _tariffRepo = tariffRepo;
                _sessionRepo = sessionRepo;

                dayPrice = _tariffRepo.GetPrice(TariffType.Day);
                nightPrice = _tariffRepo.GetPrice(TariffType.Night);

                radioButton1.Text = $"Дневной ({dayPrice} руб/час)";
                radioButton2.Text = $"Ночной ({nightPrice} руб/час)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки тарифов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;
            textBox3.Text = "1";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox2.Text, out int seatId) || seatId <= 0 || seatId > 35)
                {
                    MessageBox.Show($"Введите корректный номер ПК (1-35)", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Выберите хотя бы один вариант тарифа!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox3.Text, out int hours) || hours <= 0)
                {
                    MessageBox.Show("Введите корректное количество часов (>0)", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var seats = _seatRepo.GetAll();
                var seat = seats.FirstOrDefault(s => s.SeatId == seatId);

                if (seat == null)
                {
                    MessageBox.Show($"ПК #{seatId} не существует!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var activeSession = _sessionRepo.GetActiveSessionBySeatId(seatId);

                if (activeSession != null)
                {
                    MessageBox.Show($"ПК #{seatId} уже занят! Сессия активна до {activeSession.EndTime}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SelectedSeatId = seatId;
                SelectedTariff = radioButton1.Checked ? TariffType.Day : TariffType.Night;
                StartTime = dateTimePicker1.Value;
                Hours = hours;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии сессии: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}