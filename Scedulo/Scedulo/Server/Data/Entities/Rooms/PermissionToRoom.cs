using Scedulo.Server.Data.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Rooms
{
    public class PermissionToRoom
    {
        public Guid Id { get; set; }

        public RolePermission RolePermission { get; set; }
        public string RolePermissionId { get; set; }
        public Room Room { get; set; }
        public string RoomId { get; set; }
    }
}
