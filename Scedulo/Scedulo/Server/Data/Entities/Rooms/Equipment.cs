using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Entities.Rooms
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
