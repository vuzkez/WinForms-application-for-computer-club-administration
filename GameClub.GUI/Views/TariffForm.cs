using System;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.Library.Enums;
using GameClub.Library.ServiceInterfaces;

namespace GameClub.GUI.Views
{
    public partial class TariffForm : Form, ITariffView
    {
        public decimal DayPrice => nudDayPrice.Value;
        public decimal NightPrice => nudNightPrice.Value;

        public event EventHandler SaveRequested;

        public TariffForm(IAdministrator adminService, decimal dayPrice, decimal nightPrice)
        {
            InitializeComponent();

            nudDayPrice.Value = dayPrice;
            nudNightPrice.Value = nightPrice;

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

        public void SetPrices(decimal dayPrice, decimal nightPrice)
        {
            nudDayPrice.Value = dayPrice;
            nudNightPrice.Value = nightPrice;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
