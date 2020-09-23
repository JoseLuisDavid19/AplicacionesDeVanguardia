using Hotel.Rates.Api.Models;
using Hotel.Rates.Core;
using Hotel.Rates.Data;
using Hotel.Rates.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService context)
        {
            _reservationService = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationDataTransferObject reservationModel)
        { 
            var reservationServiceResult = _reservationService.MakeReservationNighlyPlan(reservationModel);
            if (reservationServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(reservationServiceResult.Error);
            return Ok(reservationServiceResult.Result);
        }
    }
}
