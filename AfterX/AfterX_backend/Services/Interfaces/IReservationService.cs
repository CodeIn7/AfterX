using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int reservationId);
        Task<bool> CreateReservationAsync(Reservation reservation);
        Task<bool> UpdateReservationAsync(Reservation cityToUpdate);
        Task<bool> DeleteReservationAsync(int reservationId);
    }
}
