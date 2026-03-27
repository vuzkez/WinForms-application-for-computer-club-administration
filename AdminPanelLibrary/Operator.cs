using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary
{
    public class Operator : IOperator
    {
        private readonly IDataContext dataContext;

        public Operator(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Seat FindFreeSeat(string roomType)
        {
            using (var db = dataContext.Create())
            {

            }
        }

        public void OpenSession(int seatId, int userId, TariffType tariff)
        {
            throw new NotImplementedException();
        }
    }
}
