using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core
{
    public class RoomDataTransferObject
    {
        public RoomDataTransferObject()
        {
            RatePlanRooms = new List<RatePlanRoomDataTransferObject>();
        }
        public int Id { get; set; }

        public int MaxAdults { get; set; }

        public int MaxChildren { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public ICollection<RatePlanRoomDataTransferObject> RatePlanRooms { get; set; }

    }
}
