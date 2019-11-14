using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Data.Entities.Schedules;
using Scedulo.Shared.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Schedules
{
    public class SchedulesService : ISchedulesService
    {
        private readonly ApplicationDbContext _context;

        #region SchedulesService()
        public SchedulesService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddAbsenceReason()
        public async Task<bool> AddAbsenceReason(string id, string reasonMessage)
        {
            var guidID = new Guid(id);
            var schedule = await _context.EmployeeSchedules
                .Where(x => x.Id == guidID)
                .SingleOrDefaultAsync();

            schedule.Present = true;
            schedule.AbsenceReason = reasonMessage;
            _context.Update(schedule);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region AddScheduleAsync()
        public async Task<bool> AddScheduleAsync(AddScheduleViewModel addSchedule)
        {
            if (await CheckIfAlreadyScheduled(addSchedule.EmployeeId, addSchedule.StartTime, addSchedule.EndTime))
                return false;

            var schedule = new EmployeeSchedule
            {
                Id = new Guid(),
                EmployeeId = addSchedule.EmployeeId,
                StartTime = addSchedule.StartTime,
                EndTime = addSchedule.EndTime,
                Role = addSchedule.Role,
                Present = false,
                AbsenceReason = ""
            };
            _context.EmployeeSchedules.Add(schedule);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region CheckIfAlreadyScheduled()
        public async Task<bool> CheckIfAlreadyScheduled(string employeeId, DateTime startTime, DateTime endTime)
        {
            var scheduleList = await _context.EmployeeSchedules
                .Where(x => x.EmployeeId == employeeId && x.StartTime >= DateTimeOffset.Now &&
                (!(startTime > x.StartTime && startTime < x.EndTime) || // check if startime is higher than any starttime and lower than any endtitme at the same time
                (!(endTime > x.StartTime && endTime < x.EndTime)))) // check if endtime is higher than any starttime and lower than any endtitme at the same time
                .ToListAsync();
            if (scheduleList.Count() == 0)
                return false;

            return true;
        }
        #endregion

        #region DeleteScheduleAsync()
        public async Task<bool> DeleteScheduleAsync(string id)
        {
            var deleted = false;
            var guidID = new Guid(id);
            var schedule = await _context.EmployeeSchedules
                .Where(x => x.Id == guidID)
                .SingleOrDefaultAsync();

            if (schedule != null)
            {
                _context.Remove(schedule);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;
        }
        #endregion

        #region GetScheduleList()
        public async Task<List<ScheduleViewModel>> GetScheduleList()
        {
            var scheduleList = await _context.EmployeeSchedules
                .ToListAsync();
            var list = new List<ScheduleViewModel>();
            foreach (var schedule in scheduleList)
            {
                var scheduleModel = new ScheduleViewModel()
                {
                    Id = schedule.Id.ToString(),
                    EmployeeId = schedule.EmployeeId,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    Role = schedule.Role,
                    Present = schedule.Present,
                    AbsenceReason = schedule.AbsenceReason
                };
                list.Add(scheduleModel);
            }
            return list;
        }
        #endregion

        #region GetFromDateAll()
        public async Task<List<ScheduleViewModel>> GetFromDateAll(DateTime startTime)
        {
            var scheduleList = await _context.EmployeeSchedules
                .Where(x => (x.StartTime >= startTime || x.EndTime >= x.EndTime))
                .ToListAsync();
            var list = new List<ScheduleViewModel>();
            foreach (var schedule in scheduleList)
            {
                var scheduleModel = new ScheduleViewModel()
                {
                    Id = schedule.Id.ToString(),
                    EmployeeId = schedule.EmployeeId,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    Role = schedule.Role,
                    Present = schedule.Present,
                    AbsenceReason = schedule.AbsenceReason
                };
                list.Add(scheduleModel);
            }
            return list;
        }
        #endregion

        #region GetScheduleListForEmployeeAsync()
        public async Task<List<ScheduleViewModel>> GetScheduleListForEmployeeAsync(string employeeId)
        {
            var scheduleList = await _context.EmployeeSchedules
                .Where(x => x.Present != true && x.StartTime >= DateTimeOffset.Now && x.EmployeeId == employeeId)
                .ToListAsync();
            var list = new List<ScheduleViewModel>();
            foreach (var schedule in scheduleList)
            {
                var scheduleModel = new ScheduleViewModel()
                {
                    Id = schedule.Id.ToString(),
                    EmployeeId = schedule.EmployeeId,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    Role = schedule.Role,
                    Present = schedule.Present,
                    AbsenceReason = schedule.AbsenceReason
                };
                list.Add(scheduleModel);
            }
            return list;
        }
        #endregion

        #region GetScheduleListFromDateAsync()
        public async Task<List<ScheduleViewModel>> GetScheduleListFromDateAsync(string employeeId, DateTime startTime)
        {
            var scheduleList = await _context.EmployeeSchedules
                .Where(x => x.EmployeeId == employeeId && (x.StartTime >= startTime || x.EndTime >= startTime))
                .ToListAsync();
            var list = new List<ScheduleViewModel>();
            foreach (var schedule in scheduleList)
            {
                var scheduleModel = new ScheduleViewModel()
                {
                    Id = schedule.Id.ToString(),
                    EmployeeId = schedule.EmployeeId,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    Role = schedule.Role,
                    Present = schedule.Present,
                    AbsenceReason = schedule.AbsenceReason
                };
                list.Add(scheduleModel);
            }
            return list;
        }
        #endregion

        #region MarkAsPresent()
        public async Task<bool> MarkAsPresent(string id)
        {
            var guidID = new Guid(id);
            var schedule = await _context.EmployeeSchedules
               .Where(x => x.Id == guidID)
               .SingleOrDefaultAsync();
            schedule.Present = true;
            _context.Update(schedule);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region UpdateScheduleDaysync()
        public async Task<bool> UpdateScheduleDaysync(string id, AddScheduleViewModel changedSchedule)
        {
            var guidID = new Guid(id);
            var schedule = await _context.EmployeeSchedules
                .Where(x => x.Id == guidID)
                .SingleOrDefaultAsync();

            if (schedule != null)
            {
                schedule.EmployeeId = changedSchedule.EmployeeId;
                schedule.StartTime = changedSchedule.StartTime;
                schedule.EndTime = changedSchedule.EndTime;
                schedule.Role = changedSchedule.Role;
                _context.Update(schedule);
            }
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

    }
}
