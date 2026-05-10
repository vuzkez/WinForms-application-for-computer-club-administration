using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameClub.Domain.Entities;
using GameClub.Domain.Enums;
using GameClub.DataAccess.RepositoryInterfaces;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;

namespace GameClub.DataAccess.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly DataConnection db;

        public SeatRepository(DataConnection connection)
        {
            db = connection;
        }

        public async Task AddAsync(Seat entity)
        {
            await db.InsertAsync(entity);
        }

        public async Task UpdateAsync(Seat entity)
        {
            await db.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var seat = await db.GetTable<Seat>().FirstOrDefaultAsync(s => s.SeatId == id);
            if (seat != null)
                await db.DeleteAsync(seat);
        }

        public async Task<List<Seat>> GetAllAsync()
        {
             return await db.GetTable<Seat>().ToListAsync();
        }

        public async Task<List<Seat>> GetFreeSeatsByRoomTypeAsync(string roomType)
        {
            return await db.GetTable<Seat>()
                .Where(s => s.SeatRoom == roomType && s.StatusValue == (int)SeatStatus.Free).ToListAsync();
        }

        public async Task UpdateStatusAsync(int seatId, SeatStatus seatStatus)
        {
            var seat = await db.GetTable<Seat>().FirstOrDefaultAsync(s => s.SeatId == seatId);

            if (seat == null)
                throw new Exception($"Место {seatId} не найдено!");

            seat.Status = seatStatus;
            await db.UpdateAsync(seat);
        }

        public async Task UpdateStatusBatchAsync(List<int> seatIds, SeatStatus newStatus)
        {
            if (seatIds == null || seatIds.Count == 0)
                return;

            await db.GetTable<Seat>()
                .Where(s => seatIds.Contains(s.SeatId)) 
                .Set(s => s.StatusValue, (int)newStatus)   
                .UpdateAsync();                              
        }
    }
}

