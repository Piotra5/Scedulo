using Scedulo.Shared.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Services.Schedules
{
    public interface ISchedulesService
    {
        Task<List<ScheduleViewModel>> GetScheduleListForEmployeeAsync(string employeeId);
        Task<List<ScheduleViewModel>> GetScheduleListFromDateAsync(string employeeId, DateTime startTime);
        Task<List<ScheduleViewModel>> GetScheduleList();
        Task<List<ScheduleViewModel>> GetFromDateAll(DateTime startTime);
        Task<bool> AddAbsenceReason(string id, string reasonMessage);
        Task<bool> MarkAsPresent(string id);
        Task<bool> AddScheduleAsync(AddScheduleViewModel schedule);
        Task<bool> DeleteScheduleAsync(string id);
        Task<bool> UpdateScheduleDaysync(string id, AddScheduleViewModel schedule);
        

        Task<bool> CheckIfAlreadyScheduled(string employeeId, DateTime startTime, DateTime endTime);
    }
}
