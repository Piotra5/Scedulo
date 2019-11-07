using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Shared.Models.Services;
using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data;
using Scedulo.Server.Models.Services;

namespace Scedulo.Server.Services.Services
{
    public class ServicesService : IServicesService
    {
        
        private readonly ApplicationDbContext _context;
        
        #region ServiceService()
        public ServicesService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetServiceById()
        public async Task<Service> GetServiceAsync(string id)
        {
            var service = await _context.Services
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            return service;
        }
        #endregion

        #region AddServiceAsync()
        public async Task<bool> AddServiceAsync(ServiceViewModel newService)
        {

            var service = new Service{
                Id = Guid.NewGuid(),
                Name = newService.Name,
                TimeRequiredInMinutes = newService.TimeRequiredInMinutes,
                Description = newService.Description,
                RoleReqired = newService.RoleReqired,
                PriceInPln = newService.PriceInPln
            };
        
            _context.Services.Add(service);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteServiceAsync()
        public async Task<bool> DeleteServiceAsync(string id)
        {
            var deleted = false;
            var service = await _context.Services
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (service != null)
            { 
                _context.Remove(service);
                deleted = true;
            } else
            {
                deleted = false;
            }
        
        var saveResult = await _context.SaveChangesAsync();
        return saveResult == 1 && deleted == true;
            
        }
        #endregion

        #region UpdateService()
        public async Task<bool> UpdateServiceAsync(string id, ServiceViewModel changedService)
        {
            var service = await _context.Services
                .Where(x => x.Id.ToString() == id)
                .SingleOrDefaultAsync();

            if (service != null)
            { 
                service.Name = changedService.Name;
                service.RoleReqired = changedService.RoleReqired;
                service.TimeRequiredInMinutes = changedService.TimeRequiredInMinutes;
                service.Description = changedService.Description;
                _context.Update(service);
                
            } 
        
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region GetListOfAllServices()
        public async Task<List<Service>> GetListOfAllServicesAsync()
        {
            var services = await _context.Services
                .ToListAsync();
            return services;           
        }
        #endregion
    }
}