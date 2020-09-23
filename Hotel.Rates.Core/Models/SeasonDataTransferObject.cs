using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core
{
    public class SeasonDataTransferObject
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RatePlanDataTransferObject RatePlan { get; set; }

        public int RatePlanId { get; set; }
    }
}
