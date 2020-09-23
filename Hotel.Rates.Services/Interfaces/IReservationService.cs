
using Hotel.Rates.Core;
using Hotel.Rates.Data;

namespace Hotel.Rates.Services.Interface
{
    public interface IReservationService
    {
            ServiceResult<NightlyRatePlan> MakeReservationNighlyPlan(ReservationDataTransferObject reservation);

    }
}
