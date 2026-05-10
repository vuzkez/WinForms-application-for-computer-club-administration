using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClub.GUI.ViewInterfaces;
using GameClub.BusinessLogic.ServiceInterfaces;

namespace GameClub.GUI.Views;

public partial class RevenueForm : Form, IRevenueView
{

    public RevenueForm()
    {
        InitializeComponent();

        btnShow.Click += (sender, args) => ShowRevenue.Invoke(this, EventArgs.Empty);
        btnClose.Click += (sender, args) => Close();
        AcceptButton = btnShow;
    }

    public DateTime From => dtpFrom.Value.Date;
    public DateTime To => dtpTo.Value.Date.AddDays(1); 

    public string Revenue
    {
        get => txtTotal.Text;
        set => txtTotal.Text = value;
    }

    public event EventHandler ShowRevenue;

    public void ShowError(string message)
    {
        MessageBox.Show(message, "Ошибка",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}