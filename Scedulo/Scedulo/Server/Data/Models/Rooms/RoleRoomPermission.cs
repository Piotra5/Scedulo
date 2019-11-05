using Scedulo.Server.Data.Models.Employees;
using Scedulo.Server.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Models.Rooms
{
    public class RoleRoomPermission
    {
        public Guid Id { get; set; }
        public EmployeeRole ServiceRole { get; set; }
        public Service Service { get; set; }
    }
}
