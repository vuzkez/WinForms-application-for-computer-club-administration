using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClub.GUI.ViewInterfaces
{
    public interface IRevenueView
    {
        event EventHandler ShowRevenue;
        DateTime From {  get; }
        DateTime To { get; }
        string Revenue { get; set; }
        void ShowError(string message);
    }
}
