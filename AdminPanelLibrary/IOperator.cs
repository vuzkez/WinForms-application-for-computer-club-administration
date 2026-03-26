using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public interface IOperator
    {
        void OpenSession(int seatId, int userId, TariffType tariff);
        Seat FindFreeSeat(string roomType);
    }
}
