using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма настройки тарифов (дневного и ночного)
    /// </summary>
    public partial class TariffForm : Form, ITariffView
    {
        /// <summary>
        /// Свойство для получения цены дневного тарифа
        /// </summary>
        public decimal DayPrice => nudDayPrice.Value;

        /// <summary>
        /// Свойство для получения цены ночного тарифа
        /// </summary>
        public decimal NightPrice => nudNightPrice.Value;

        /// <summary>
        /// Событие сохранения новых тарифов
        /// </summary>
        public event EventHandler SaveRequested;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public TariffForm()
        {
            InitializeComponent();

            btnSave.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    $"Сохранить тарифы?\n\nДневной: {nudDayPrice.Value} руб\nНочной: {nudNightPrice.Value} руб",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    SaveRequested?.Invoke(this, EventArgs.Empty);
            };

            btnClose.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        /// <summary>
        /// Установка текущих цен тарифов при загрузке формы
        /// </summary>
        /// <param name="dayPrice">Цена дневного тарифа</param>
        /// <param name="nightPrice">Цена ночного тарифа</param>
        public void SetPrices(decimal dayPrice, decimal nightPrice)
        {
            nudDayPrice.Value = dayPrice;
            nudNightPrice.Value = nightPrice;
        }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Отображение информационного сообщения
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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