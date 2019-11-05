using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data.Models.ApplicationUsers;
using Scedulo.Server.Data.Models.Base;
using Scedulo.Server.Data.Models.Customers;
using Scedulo.Server.Data.Models.Employees;
using Scedulo.Server.Data.Models.Rooms;
using Scedulo.Server.Data.Models.Schedules;
using Scedulo.Server.Data.Models.ServiceReservations;
using Scedulo.Server.Data.Models.Services;
using Scedulo.Server.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RoleRoomPermission> RoleRoomPermissions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public DbSet<ServiceReservation> ServiceReservations { get; set; }
        public DbSet<RoleServicePermission> RoleServicePermission { get; set; }
        public DbSet<Service> Services { get; set; }


    }
}
