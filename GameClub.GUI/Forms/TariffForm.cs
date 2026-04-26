using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClub.Library.Enums;
using GameClub.Library.Interfaces;

namespace GameClub.GUI
{
    public partial class TariffForm : Form
    {
        private readonly IAdministrator _adminService;

        public TariffForm(IAdministrator adminService, decimal dayPrice, decimal nightPrice)
        {
            InitializeComponent();
            _adminService = adminService;

            nudDayPrice.Value = dayPrice;
            nudNightPrice.Value = nightPrice;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal newDayPrice = nudDayPrice.Value;
                decimal newNightPrice = nudNightPrice.Value;

                if (newDayPrice <= 0 || newNightPrice <= 0)
                {
                    MessageBox.Show("Цена должна быть больше 0 рублей.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Сохранить новые цены?\n\n" +
                    $"Дневной тариф: {newDayPrice} руб/час\n" +
                    $"Ночной тариф: {newNightPrice} руб/час",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    await _adminService.ConfigureTariffAsync(TariffType.Day, newDayPrice);
                    await _adminService.ConfigureTariffAsync(TariffType.Night, newNightPrice);

                    MessageBox.Show("Цены успешно обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}