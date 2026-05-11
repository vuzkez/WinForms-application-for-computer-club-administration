using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Domain.Enums;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма открытия новой сессии для выбранного места.
    /// Позволяет выбрать тариф и указать количество часов.
    /// </summary>
    public partial class OpenSessionForm : Form, IOpenSessionView
    {
        /// <summary>
        /// Свойства для передачи результатов презентеру
        /// </summary>
        public int SelectedSeatId { get; private set; }
        public TariffType SelectedTariff { get; private set; }
        public DateTime StartTime { get; private set; }
        public int Hours { get; private set; }

        /// <summary>
        /// Свойства для чтения данных из полей формы
        /// </summary>
        public string SeatIdText => textBox2.Text;
        public bool IsSeatPreselected => lblSelectedSeatInfo.Visible;
        public bool IsDayTariffSelected => radioButton1.Checked;
        public bool IsNightTariffSelected => radioButton2.Checked;
        public string HoursText => textBox3.Text;

        /// <summary>
        /// Событие подтверждения открытия сессии
        /// </summary>
        public event EventHandler ConfirmOpen;

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        public event EventHandler FormLoaded;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public OpenSessionForm()
        {
            InitializeComponent();

            textBox3.Text = "1";

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

        /// <summary>
        /// Установка предвыбранного места (при открытии из списка свободных мест)
        /// </summary>
        /// <param name="seatId">ID места</param>
        public void SetPreselectedSeat(int seatId)
        {
            SelectedSeatId = seatId;
            textBox2.Visible = false;
            lblSelectedSeatInfo.Visible = true;
            lblSelectedSeatInfo.Text = $"Место: {seatId}";
        }

        /// <summary>
        /// Установка текста для дневного тарифа
        /// </summary>
        /// <param name="text">Текст с ценой дневного тарифа</param>
        public void SetDayTariffLabel(string text) => radioButton1.Text = text;

        /// <summary>
        /// Установка текста для ночного тарифа
        /// </summary>
        /// <param name="text">Текст с ценой ночного тарифа</param>
        public void SetNightTariffLabel(string text) => radioButton2.Text = text;

        /// <summary>
        /// Установка текущей даты и времени начала сессии
        /// </summary>
        /// <param name="text">Текст с датой и временем</param>
        public void SetCurrentDateTime(string text) => label1.Text = text;

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Закрытие формы с положительным результатом
        /// </summary>
        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}