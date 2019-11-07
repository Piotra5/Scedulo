using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalendaroNet.Shared.Models.Services;
using Microsoft.AspNetCore.Identity;

namespace Scedulo.Server.Services.Services
{
using Scedulo.Server.Models.Services;

public interface IServicesService
    {
        Task<Service> GetServiceAsync(string id);
        Task<List<Service>> GetListOfAllServicesAsync();
        Task<bool> AddServiceAsync(ServiceViewModel newService);
        Task<bool> DeleteServiceAsync(string id);
        Task<bool> UpdateServiceAsync(string id, ServiceViewModel changedService);
    }
}