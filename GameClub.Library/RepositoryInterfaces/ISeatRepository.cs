using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Library.Entities;
using GameClub.Library.Enums;

namespace GameClub.Library.RepositoryInterfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<List<Seat>> GetFreeSeatsByRoomTypeAsync(string roomType);
        Task UpdateStatusAsync(int seatId,SeatStatus seatStatus);
        Task UpdateStatusBatchAsync(List<int> seatIds, SeatStatus newStatus);
    }
}
