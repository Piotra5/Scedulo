using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Rooms;
using Scedulo.Server.Data.Entities.ServiceReservations;
using Scedulo.Server.Data.Entities.Services;
using Scedulo.Shared.Models.Base;
using Scedulo.Shared.Models.Reservation;
using Scedulo.Shared.Models.Reservations;
using Scedulo.Shared.Models.RoomPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        #region AddReservationsService()
        public async Task<PassInfoModel> AddServiceReservationAsync(AddReservationViewModel addReservation, string userId)
        {
            var passedInfo = await CanEmployeeDo(addReservation.EmployeeId, addReservation.ServiceId);
            if (passedInfo.Successful == true)
            {
                var guidServiceId = new Guid(addReservation.ServiceId);
                var service = await _context.Services
                    .Where(x => x.Id == guidServiceId)
                    .FirstOrDefaultAsync();
                if (addReservation.ServiceTimeInMinutes <= service.TimeRequiredInMinutes)
                {
                    var reservationSechedule = new ReservationSechdule
                    {
                        StartDate = addReservation.StartTime,
                        EndTime = addReservation.EndTime,
                        EmployeeId = addReservation.EmployeeId,
                        ServiceTimeInMinutes = addReservation.ServiceTimeInMinutes
                    };
                    passedInfo = await CanReservationBeScheduled(reservationSechedule);
                    if (passedInfo.Successful == false)
                    {
                        return passedInfo;
                    }
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
                    if ((reservation.ServiceTimeInMinutes > (reservation.StartTime - reservation.EndTime).TotalMinutes + 5))
                    {
                        passedInfo.Successful = false;
                        passedInfo.Message = "Service time is longer than your reservation. ";
                        return passedInfo;
                    }
                    await _context.ServiceReservations.AddAsync(reservation);
                    var saveResult = await _context.SaveChangesAsync();
                    if (saveResult == 1)
                    {
                        passedInfo.Message = "Added reservation to database ID: " + reservation.Id +
                            "\n By employeeID: " + reservation.EmployeeId + " \n Service ID: " + reservation.ServiceId +
                            "\n For " + reservation.StartTime.ToString("dd-mm-yyyy HH:MM") + " - " + reservation.EndTime.ToString("dd-mm-yyyy HH:MM");
                        passedInfo.Successful = true;
                        return passedInfo;
                    }
                    else
                    {
                        passedInfo.Message = "Could not safe to database";
                        passedInfo.Successful = false;
                        return passedInfo;
                    }
                }
                passedInfo.Successful = false;
                passedInfo.Message = "Service take longer than your reservation";
                return passedInfo;
            }
            return passedInfo;
        }
        #endregion

        public async Task<PassInfoModel> CanEmployeeDo(string employeeId, string serviceId)
        {
            var guidEmployeeID = new Guid(employeeId);
            var guidServiceId = new Guid(serviceId);
            //var employeeRoleMatch = await _context.Employees
            //    .Where(x => x.Id == guidEmployeeID
            //    && x.AvailableRoles.Any(s => s.Id == guidServiceId))
            //    .ToListAsync();

            return new PassInfoModel { Message = "Employee can do", Successful = true };



            //var allEmployeeRoles = await _context.EmployeePermissions
            //    .Where(x => x.EmployeeId == employeeId)
            //    .ToListAsync();
            //List<RoleServicePermssion> roleServicePermssionsList = new List<RoleServicePermssion>();

            //foreach (var erole in allEmployeeRoles)
            //{
            //    var servicePerm = await _context.RoleServicePermission
            //        .Where(x => x.ServiceRoleId == erole.RoleId)
            //        .ToListAsync();
            //    foreach (var sp in servicePerm)
            //    {
            //        roleServicePermssionsList.Add(sp);
            //    }
            //}
            //foreach (var sRole in roleServicePermssionsList)
            //{
            //    if (sRole.ServiceId == serviceId)
            //        return new PassInfoModel { Message = "Employee can do", Successful = true };
            //}
            //return new PassInfoModel { Message = "Employee is not permitted to do this service", Successful = false };
        }
        #region IsEmployeeScheduledd()
        public async Task<PassInfoModel> CanReservationBeScheduled(ReservationSechdule reservationSchedule)
        {
            var employeeScheduled = await _context.EmployeeSchedules
                .Where(x => x.EmployeeId == reservationSchedule.EmployeeId
                && x.StartTime <= reservationSchedule.StartDate && x.StartTime < reservationSchedule.EndTime
                && x.EndTime > reservationSchedule.StartDate && x.EndTime >= reservationSchedule.EndTime)
                .FirstOrDefaultAsync();
            if (employeeScheduled != null)
                if (await IsEmployeerFree(reservationSchedule))
                    return new PassInfoModel { Message = "Added", Successful = true };
                else return new PassInfoModel { Message = "Employee has other services booked", Successful = false };
            return new PassInfoModel { Message = "Employee is not at work then ", Successful = false };
        }
        #endregion

        public async Task<bool> IsEmployeerFree(ReservationSechdule reservationSchedule)
        {
            var employeeReservations = await _context.ServiceReservations
                .Where(x => x.EmployeeId == reservationSchedule.EmployeeId
                && ((x.StartTime >= reservationSchedule.StartDate && x.StartTime < reservationSchedule.EndTime) ||
                (x.EndTime > reservationSchedule.StartDate && x.EndTime <= reservationSchedule.EndTime)))
                .FirstOrDefaultAsync();
            if (employeeReservations == null)
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
        public async Task<IEnumerable<ReservationViewModel>> GetListOfAllReservationsAsync()
        {
            var reservations = await _context.ServiceReservations
                .ToListAsync();
            var list = new List<ReservationViewModel>();
            foreach (var reservation in reservations)
            {
                var reservationModel = new ReservationViewModel
                {
                    ID = reservation.Id.ToString(),
                    CustomerId = reservation.CustomerId,
                    ServiceId = reservation.ServiceId,
                    EmployeeId = reservation.EmployeeId,
                    ReservationTime = reservation.ReservationTime,
                    StartTime = reservation.StartTime,
                    EndTime = reservation.EndTime,
                    ServiceTimeInMinutes = reservation.ServiceTimeInMinutes,
                    Done = reservation.Done,
                    AbsenceReason = reservation.AbsenceReason
                };
                list.Add(reservationModel);
            }
            return list;
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
