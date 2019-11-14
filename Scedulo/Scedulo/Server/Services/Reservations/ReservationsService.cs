using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Rooms;
using Scedulo.Server.Data.Entities.ServiceReservations;
using Scedulo.Server.Data.Entities.Services;
using Scedulo.Server.Services.RoomPermissions;
using Scedulo.Shared.Models.Reservation;
using Scedulo.Shared.Models.Reservations;
using Scedulo.Shared.Models.RoomPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Reservations
{
    public class ReservationsService : IReservationsService
    {
        private readonly ApplicationDbContext _context;

        #region ReservationsService()
        public ReservationsService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        #region ReservationsService()
        public async Task<string> AddServiceReservationAsync(AddReservationViewModel addReservation, string userId)
        {
            if (CanEmployeeDo(addReservation.EmployeeId, addReservation.ServiceId) != null)
            {
                var guidServiceId = new Guid(addReservation.ServiceId);
                var service = await _context.Services
                    .Where(x => x.Id == guidServiceId)
                    .FirstOrDefaultAsync();
                if (addReservation.ServiceTimeInMinutes > service.TimeRequiredInMinutes)
                    return null;
                var reservationSechedule = new ReservationSechdule
                {
                    StartDate = addReservation.StartTime,
                    EndTime = addReservation.EndTime,
                    EmployeeId = addReservation.EmployeeId,
                    ServiceTimeInMinutes = addReservation.ServiceTimeInMinutes
                };
                if (await CanReservationBeScheduled(reservationSechedule))
                {
                    var reservation = new ServiceReservation
                    {
                        Id = new Guid(),
                        CustomerId = addReservation.CustomerId,
                        ServiceId = addReservation.ServiceId,
                        EmployeeId = addReservation.EmployeeId,
                        ReservationTime = addReservation.ReservationTime,
                        StartTime = addReservation.StartTime,
                        EndTime = addReservation.EndTime,
                        ServiceTimeInMinutes = addReservation.ServiceTimeInMinutes,
                        Done = false,
                        AbsenceReason = ""
                    };
                    _context.ServiceReservations.Add(reservation);
                    var saveResult = await _context.SaveChangesAsync();
                    if (saveResult == 1)
                        return reservation.Id.ToString();
                    return "Cannot save db";
                }
                return "Cannot reserve service";
            }
            return "Employee is not permitted to do this service";
        }
        #endregion

        public async Task<string> CanEmployeeDo(string employeeId, string serviceId)
        {
            //var guidEmployeeID = new Guid(employeeId);
            //var guidServiceId = new Guid(serviceId);
            var allEmployeeRoles = await _context.EmployeePermissions
                .Where(x => x.EmployeeId == employeeId)
                .ToListAsync();
            
            var allServicesRoles = await _context.RoleServicePermission
                .Where(x => allEmployeeRoles.Any(y => y.RoleId == x.ServiceRoleId))
                .ToListAsync();

            foreach(var sRole in allServicesRoles)
            {
                foreach(var eRole in allEmployeeRoles)
                {
                    if(eRole.RoleId == sRole.ServiceRoleId)
                        return eRole.RoleId;
                }
            }
            return null;
        }
        #region IsEmployeeScheduledd()
        public async Task<bool> CanReservationBeScheduled(ReservationSechdule reservationSchedule)
        {
            var servicesRole = await _context.EmployeeSchedules
                .Where(x => x.EmployeeId == reservationSchedule.EmployeeId 
                && x.StartTime > reservationSchedule.StartDate && x.StartTime < reservationSchedule.EndTime
                && x.EndTime > reservationSchedule.StartDate && x.EndTime < reservationSchedule.EndTime)
                .FirstOrDefaultAsync();
            if(servicesRole.Id.ToString() == "" || servicesRole.Id == null)
                if (await IsEmployeerFree(reservationSchedule))
                    return true;
            return false;
        }
        #endregion

        public async Task<bool> IsEmployeerFree(ReservationSechdule reservationSchedule)
        {
            var servicesRole = await _context.ServiceReservations
                .Where(x => x.EmployeeId == reservationSchedule.EmployeeId
                && x.StartTime > reservationSchedule.StartDate && x.StartTime < reservationSchedule.EndTime
                && x.EndTime > reservationSchedule.StartDate && x.EndTime < reservationSchedule.EndTime)
                .FirstOrDefaultAsync();
            if (servicesRole.Id.ToString() == "" || servicesRole.Id == null)
                return true;
            return false;

        }

        public async Task<bool> CanCustomerDo(string userId, string serviceId)
        {
            return true;
        }

        public Task<bool> CanAtTime(string customerId)
        {

            return null;
        }


        #region DeleteDeletePermissionAsync()
        public Task<string> DeletePermissionAsync(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region ForUserAvailable()
        public Task<string> ForUserAvailable(string userID)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region GetListOfAllReservationsAsync()
        public Task<IEnumerable<ReservationViewModel>> GetListOfAllReservationsAsync(string userId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region GetReservationsForEmployee()
        public Task<List<ReservationViewModel>> GetReservationsForEmployee(string employeeId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region GetReservationsForUser()
        public Task<List<ReservationViewModel>> GetReservationsForUser(string userId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region MarkReservationAsDone()
        public Task<string> MarkReservationAsDone(string reservationID, string UserID)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region UpdatePermissionAsync()
        public Task<string> UpdatePermissionAsync(string id, AddReservationViewModel changedRoomPermission)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
