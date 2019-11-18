using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scedulo.Server.Data.Entities.ApplicationUsers;
using Scedulo.Server.Data.Entities.Base;
using Scedulo.Server.Data.Entities.Customers;
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
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
        public DbSet<ServiceReservation> ServiceReservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<PermissionToService> ServicePermissions { get; set; }
        public DbSet<PermissionToRoom> RoomPermissions { get; set; }


    }
}
