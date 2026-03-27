using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
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

        public void AddHours(Session session, int hours)
        {
            using (var db = dataContext.Create())
            {
                var sessionDb = db.GetTable<Session>().FirstOrDefault(p => p.SessionId == session.SessionId);
                if (sessionDb != null)
                {
                    var tariff = sessionDb.Tariff;
                    var pricePerHour = db.GetTable<TariffSetting>().First(x => x.Type == tariff).PricePerHour;
                    sessionDb.EndTime = sessionDb.EndTime.AddHours(hours);
                    sessionDb.TotalAmount = sessionDb.TotalAmount + (pricePerHour * hours);
                }
                db.SubmitChanges();
            }
        }

        public void CloseSession(Session session)
        {
            using (var db = dataContext.Create())
            {
                db.GetTable<Session>().DeleteOnSubmit(session);
                db.SubmitChanges();
            }
        }

        public void OpenSession(int seatId, int userId, TariffType tariff, DateTime startTime, DateTime endTime)
        {
            var newClient = new Session();
            newClient.Tariff = tariff;
            newClient.UserId = userId;
            newClient.SeatId = seatId;
            newClient.StartTime = startTime;
            newClient.EndTime = endTime;

            int hours = (int)(endTime - startTime).TotalHours;
            using (var db = dataContext.Create())
            {
                var pricePerHour = db.GetTable<TariffSetting>().First(p => p.Type == tariff).PricePerHour;
                newClient.TotalAmount = pricePerHour * hours;
                db.GetTable<Session>().InsertOnSubmit(newClient);
                db.SubmitChanges();
            }
        }
    }
}
