using Scedulo.Server.Data.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Services
{
    public class PermissionToService
    {
        public Guid Id { get; set; }
        public RolePermission RolePermission { get; set; }
        public string RolePermissionId { get; set; }
        public Service Service { get; set; }
        public string ServiceId { get; set; }
    }
}
