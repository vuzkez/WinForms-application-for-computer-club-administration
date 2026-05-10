using System;
using System.Linq;
using System.Windows.Forms;
using GameClub.Library;
using GameClub.Library.Enums;
using GameClub.Library.ServiceInterfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GameClub.GUI.Views;

public partial class OpenSessionForm : Form
{
    public int SelectedSeatId { get; private set; }
    public TariffType SelectedTariff { get; private set; }
    public DateTime StartTime { get; private set; }
    public int Hours { get; private set; }

    private readonly IOperator _operatorService;
    private readonly IAdministrator _adminService;
    private decimal dayPrice;
    private decimal nightPrice;

    public OpenSessionForm(IOperator operatorService, IAdministrator adminService, int seatId)
    {
        InitializeComponent();
        _operatorService = operatorService;
        _adminService = adminService;

        LoadTariffsAsync();

        textBox3.Text = "1";

        textBox2.Visible = false;
        lblSelectedSeatInfo.Visible = true;
        lblSelectedSeatInfo.Text = $"Выбрано место номер: {seatId}";
        SelectedSeatId = seatId;
    }

    private async void LoadTariffsAsync()
    {
        try
        {
            dayPrice = await _adminService.GetTariffPriceAsync(TariffType.Day);
            nightPrice = await _adminService.GetTariffPriceAsync(TariffType.Night);

            radioButton1.Text = $"Дневной ({dayPrice} руб/час)";
            radioButton2.Text = $"Ночной ({nightPrice} руб/час)";

            label1.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки тарифов: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }

    private async void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            int seatId;

            if (lblSelectedSeatInfo.Visible)
            {
                seatId = SelectedSeatId;
            }
            else
            {
                if (!int.TryParse(textBox2.Text, out seatId) || seatId <= 0 || seatId > 35)
                {
                    MessageBox.Show("Введите корректный номер ПК (1-35)", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выберите тариф!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox3.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Введите корректное количество часов (>0)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seats = await _operatorService.GetAllSeatsWithStatusAsync();
            var seat = seats.FirstOrDefault(s => s.SeatId == seatId);

            if (seat == null)
            {
                MessageBox.Show($"ПК #{seatId} не существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var activeSession = await _operatorService.GetActiveSessionBySeatIdAsync(seatId);

            if (activeSession != null)
            {
                MessageBox.Show($"ПК #{seatId} уже занят! Сессия активна до {activeSession.EndTime:HH:mm}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedSeatId = seatId;
            SelectedTariff = radioButton1.Checked ? TariffType.Day : TariffType.Night;
            StartTime = DateTime.Now;
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