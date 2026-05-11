using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма отчёта по выручке за выбранный период
    /// </summary>
    public partial class RevenueForm : Form, IRevenueView
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public RevenueForm()
        {
            InitializeComponent();

            btnShow.Click += (sender, args) => ShowRevenue.Invoke(this, EventArgs.Empty);
            btnClose.Click += (sender, args) => Close();
            AcceptButton = btnShow;
        }

        /// <summary>
        /// Свойство для получения начальной даты периода
        /// </summary>
        public DateTime From => dtpFrom.Value.Date;

        /// <summary>
        /// Свойство для получения конечной даты периода (включая последний день)
        /// </summary>
        public DateTime To => dtpTo.Value.Date.AddDays(1);

        /// <summary>
        /// Свойство для отображения суммы выручки
        /// </summary>
        public string Revenue
        {
            get => txtTotal.Text;
            set => txtTotal.Text = value;
        }

        /// <summary>
        /// Событие запроса на отображение выручки
        /// </summary>
        public event EventHandler ShowRevenue;

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}