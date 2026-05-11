using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Views
{
    /// <summary>
    /// Форма выбора типа зала для поиска свободных мест
    /// </summary>
    public partial class FindFreeSeatForm : Form, IFindFreeSeatView
    {
        /// <summary>
        /// Свойство для получения выбранного типа зала (General / Vip)
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// Событие подтверждения выбора типа зала
        /// </summary>
        public event EventHandler ConfirmSelection;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public FindFreeSeatForm()
        {
            InitializeComponent();

            btnOk.Click += (s, e) =>
            {
                if (radioButton1.Checked)
                    Result = "General";
                else if (radioButton2.Checked)
                    Result = "Vip";
                else
                    Result = null;

                ConfirmSelection?.Invoke(this, EventArgs.Empty);
            };

            btnCancel.Click += (s, e) => Close();
        }

        /// <summary>
        /// Отображение сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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