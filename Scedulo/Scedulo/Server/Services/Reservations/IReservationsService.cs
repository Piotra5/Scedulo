using Microsoft.AspNetCore.Identity;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.Reservation;
using Scedulo.Shared.Models.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Reservations
{
    public interface IReservationsService
    {
        Task<IEnumerable<ReservationViewModel>> GetListOfAllReservationsAsync();
        Task<List<ReservationViewModel>> GetReservationsForUser(string userId);
        Task<List<ReservationViewModel>> GetReservationsForEmployee(string employeeId);
        Task<PassInfoModel> AddServiceReservationAsync(AddReservationViewModel reservation, string id);
        Task<string> DeletePermissionAsync(string id);
        Task<string> UpdatePermissionAsync(string id, AddReservationViewModel changedRoomPermission);
        Task<string> MarkReservationAsDone(string reservationID, string UserID);
        Task<string> ForUserAvailable(string userID);

    }
}