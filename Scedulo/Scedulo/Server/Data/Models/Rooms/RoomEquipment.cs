using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scedulo.Server.Data.Models.Rooms
{
    public class RoomEquipment
    {
        public Guid Id { get; set; }

        public Room Room { get; set; }

        public Equipment Equipment { get; set; }
    }
}
