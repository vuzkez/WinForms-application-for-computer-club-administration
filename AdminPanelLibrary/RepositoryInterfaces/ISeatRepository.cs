using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelLibrary.Entities;
using AdminPanelLibrary.Enums;

namespace AdminPanelLibrary.RepositoryInterfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        IEnumerable<Seat> GetFreeSeatsByRoomType(string roomType);
        void UpdateStatus(int seatId,SeatStatus seatStatus);
    }
}
