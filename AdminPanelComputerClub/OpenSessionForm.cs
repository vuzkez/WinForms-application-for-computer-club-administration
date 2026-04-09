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
using LinqToDB;

namespace AdminPanelComputerClub
{
    public partial class OpenSessionForm : Form
    {
        public int SelectedSeatId { get; private set; }
        public TariffType SelectedTariff { get; private set; }
        public DateTime StartTime { get; private set; }
        public int Hours { get; private set; }
        public IDataConnection MyDataContext {  get; private set; }

        private decimal dayPrice;
        private decimal nightPrice;
        public OpenSessionForm(IDataConnection dataContext)
        {
            InitializeComponent();

            using (var db = dataContext.Create())
            {
                var daySetting = db.GetTable<TariffSetting>()
                    .FirstOrDefault(t => t.TypeValue == "Day");
                var nightSetting = db.GetTable<TariffSetting>()
                    .FirstOrDefault(t => t.TypeValue == "Night");

                if (daySetting != null)
                    dayPrice = daySetting.PricePerHour;
                if (nightSetting != null)
                    nightPrice = nightSetting.PricePerHour;
            }

            radioButton1.Text = $"Дневной ({dayPrice} руб/час)";
            radioButton2.Text = $"Ночной ({nightPrice} руб/час)";

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;

            textBox3.Text = "1";
            MyDataContext = dataContext;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (var db = MyDataContext.Create())
            {
                var countSeats = db.GetTable<Seat>()
                    .Count();

                if (!int.TryParse(textBox2.Text, out int seatId) || seatId > countSeats || seatId <= 0)
                {
                    MessageBox.Show("Введите корректный номер ПК", "Ошибка",
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

                var seat = db.GetTable<Seat>().FirstOrDefault(s => s.SeatId == seatId);

                if (seat == null)
                {
                    MessageBox.Show($"ПК #{seatId} не существует!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var activeSession = db.GetTable<Session>()
                    .FirstOrDefault(s => s.SeatId == seatId && s.EndTime > DateTime.Now);

                if (activeSession != null)
                {
                    MessageBox.Show($"ПК #{seatId} уже занят! Сессия активна до {activeSession.EndTime}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SelectedSeatId = int.Parse(textBox2.Text);
                SelectedTariff = radioButton1.Checked ? TariffType.Day : TariffType.Night;
                StartTime = dateTimePicker1.Value;
                Hours = hours;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
