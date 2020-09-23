
using Hotel.Rates.Core;
using Hotel.Rates.Data;
using Hotel.Rates.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Hotel.Rates.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<NightlyRatePlan> _nightlyRatePlanRepository;

        public ReservationService(IRepository<NightlyRatePlan> nightlyRepository)
        {
            _nightlyRatePlanRepository = nightlyRepository;
        }

        public ServiceResult<NightlyRatePlan> MakeReservationNighlyPlan(ReservationDataTransferObject reservation)
        {
            var ratePlan = _nightlyRatePlanRepository.All()
               .Include(r => r.Seasons)
               .Include(r => r.RatePlanRooms)
               .ThenInclude(r => r.Room)
               .First(r => r.Id == reservation.RatePlanId);
            var canReserve = ratePlan.Seasons
                .Any(s => s.StartDate <= reservation.ReservationStart && s.EndDate >= reservation.ReservationEnd);
            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservation.RoomId && r.RatePlanId == reservation.RatePlanId);
            var isRoomAvailable = room.Room.Amount > 0 &&
                room.Room.MaxAdults > reservation.AmountOfChildren &&
                room.Room.MaxChildren >= reservation.AmountOfChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                _nightlyRatePlanRepository.SaveChanges();
                var days = (reservation.ReservationEnd - reservation.ReservationStart).TotalDays;
                return ServiceResult<NightlyRatePlan>.SuccessResult(new NightlyRatePlan
                {
                    Price = days * ratePlan.Price
                });
            }
            return ServiceResult<NightlyRatePlan>.ErrorResult("Bad Request");
        }
    }
}
