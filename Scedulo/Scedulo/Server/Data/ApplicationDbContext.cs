using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data.Entities.ApplicationUsers;
using Scedulo.Server.Data.Entities.Employees;
using Scedulo.Server.Data.Entities.Rooms;
using Scedulo.Server.Data.Entities.Schedules;
using Scedulo.Server.Data.Entities.ServiceReservations;
using Scedulo.Server.Data.Entities.Services;
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
        public DbSet<RoleServicePermssion> RoleServicePermission { get; set; }
        public DbSet<Service> Services { get; set; }


    }
}
