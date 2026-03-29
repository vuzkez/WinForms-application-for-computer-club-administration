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
    public partial class OpenSessionForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedSeatId { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TariffType SelectedTariff { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartTime { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Hours { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDataContext MyDataContext {  get; private set; }

        private decimal dayPrice;
        private decimal nightPrice;
        public OpenSessionForm(IDataContext dataContext)
        {
            InitializeComponent();

            // Получаем цены
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

            // Устанавливаем тексты радио-кнопок
            radioButton1.Text = $"Дневной ({dayPrice} руб/час)";
            radioButton2.Text = $"Ночной ({nightPrice} руб/час)";

            // Устанавливаем дату и время по умолчанию
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;

            // Часы по умолчанию
            textBox3.Text = "1";
            MyDataContext = dataContext;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (var db = MyDataContext.Create())
            {
                var countSeats = db.GetTable<Seat>()
                    .Count();
                // Проверка ввода
                if (!int.TryParse(textBox2.Text, out int seatId) || seatId > countSeats || seatId <= 0)
                {
                    MessageBox.Show("Введите корректный номер ПК", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!int.TryParse(textBox3.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Введите корректное количество часов (>0)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedSeatId = int.Parse(textBox2.Text);
            SelectedTariff = radioButton1.Checked ? TariffType.Day : TariffType.Night;
            StartTime = dateTimePicker1.Value;
            Hours = hours;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
