using System;
using System.ComponentModel.DataAnnotations;

namespace Scedulo.Server.Models.Services
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeRequiredInMinutes { get; set; }
        public bool RoleReqired {get; set;}
        public double PriceInPln {get; set;}

    }
}