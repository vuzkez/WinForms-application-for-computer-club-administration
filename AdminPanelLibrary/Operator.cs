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

        public void OpenSession(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime)
        {
            var newClient = new Session();
            newClient.Tariff = tariff;
            newClient.UserId = userId;
            newClient.StartTime = startTime;
            newClient.EndTime = endTime;

            int hours = (int)(endTime - startTime).TotalHours;
            using (var db = dataContext.Create())
            {
                var pricePerHour = db.GetTable<TariffSetting>().Where(p => p.Type == tariff).Select(x => x.PricePerHour).ToString();
                if (pricePerHour != null)
                {
                    newClient.TotalAmount = decimal.Parse(pricePerHour) * hours;
                }
                db.GetTable<Session>().InsertOnSubmit(newClient);
                db.SubmitChanges();
            }
        }
    }
}
