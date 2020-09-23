using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core
{
    public class RatePlanRoomDataTransferObject
    {
        public int RatePlanId { get; set; }

        public RatePlanDataTransferObject RatePlan { get; set; }

        public int RoomId { get; set; }

        public RoomDataTransferObject Room { get; set; }
    }
}
