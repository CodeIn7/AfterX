using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _dataContext;
        public ReservationService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateReservationAsync(Reservation reservation, int clubId, int tableTypeId)
        {
            List<Table> tables = await _dataContext.Tables
                .Include(a => a.Reservations)
                .Where(a =>a.Tabletypeid == tableTypeId&& a.Clubid == clubId).ToListAsync();

            foreach(var t in tables)
            {
                Reservation r = t.Reservations.Where(_r => _r.Reservationdate == reservation.Reservationdate).FirstOrDefault();
                if (r == null)
                {
                    reservation.Table = t ;
                    break;
                }
            };
            if (reservation.Table == null)
            {
                return false;
            }
            _dataContext.Add(reservation);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            var reservation = await GetReservationByIdAsync(reservationId);

            _dataContext.Remove(reservation);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _dataContext.Reservations
                .Include(c => c.Orders).Include(a => a.Table)
                .FirstOrDefaultAsync(m => m.Id == reservationId);

            return reservation;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _dataContext.Reservations.ToListAsync();

        }

        public async Task<List<Reservation>> GetReservationsByUserIdAsync(int userId)
        {
            var reservations = await _dataContext.Reservations
                .Include(a=>a.Table).ThenInclude(b=>b.Tabletype)
                .Where(reservation=>reservation.Userid==userId).ToListAsync();
            return reservations;
        }

        public async Task<bool> UpdateReservationAsync(Reservation reservationToUpdate)
        {
            _dataContext.Update(reservationToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
