using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;

namespace GameClub.DataAccess.RepositoryInterfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<List<Seat>> GetFreeSeatsByRoomTypeAsync(string roomType);
        Task UpdateStatusAsync(int seatId,SeatStatus seatStatus);
        Task UpdateStatusBatchAsync(List<int> seatIds, SeatStatus newStatus);
    }
}

