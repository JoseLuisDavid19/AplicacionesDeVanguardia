using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core
{
    public class RatePlanDataTransferObject
    {
        public RatePlanDataTransferObject()
        {
            Season = new List<SeasonDataTransferObject>();
            RatePlanRooms = new List<RatePlanRoomDataTransferObject>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int RatePlanType { get; set; }

        public double Price { get; set; }

        public ICollection<SeasonDataTransferObject> Season { get; set; }

        public ICollection<RatePlanRoomDataTransferObject> RatePlanRooms { get; set; }
    }
}
