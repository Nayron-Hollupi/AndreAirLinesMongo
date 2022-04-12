using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using FlightsAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Service;
using ServicceAircraft;
using System.Threading.Tasks;
using ServicePassenger;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly FightService _fightService;


        public FightController(FightService fightService)
        {
            _fightService = fightService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<Flights>> Get() =>
            _fightService.Get();


        [HttpGet("{id:length(24)}", Name = "GetFlight")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<Flights> Get(string id)
        {
            var flight = _fightService.Get(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        [HttpGet("{Origin}/{Destination}" , Name = "GetFlightBooking")]
        public async Task<ActionResult<Flights>> GetBookingFlights(string destination, string origin)
        {
            var flight = _fightService.GetBooking(destination, origin);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }
       
        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public  async Task<ActionResult<Flights>> Create(Flights flight)
        {
            var destination =  await ServiceSeachAirport.SeachAirport(flight.Destination.CodeIATA);
            var origin = await ServiceSeachAirport.SeachAirport(flight.Origin.CodeIATA);
            var aircraft = await ServiceSeachAircraft.SeachAircraft(flight.Aircraft.Registry);
          

            flight.Destination = destination;
            flight.Origin = origin;
            flight.Aircraft = aircraft;
;

            if (origin != null && destination != null && aircraft != null)
            {
                if (origin.CodeIATA != destination.CodeIATA)
                {
                    flight.Destination = destination;
                    flight.Origin = origin;
                    flight.Aircraft = aircraft;
                    _fightService.Create(flight);
                }
                else
                {
                    return Conflict("A origem e destino não pode ser iguais.");
                }
            }
            else
            {
                return Conflict("Serviço indisponivel no momento.");
            }

            return CreatedAtRoute("GetFight", new { Id = flight.Id.ToString() }, flight);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "employee,manager")]
        public IActionResult Update(string id, Flights fightIn)
        {
            var fight = _fightService.Get(id);

            if (fight == null)
            {
                return NotFound();
            }

            _fightService.Update(id, fightIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "employee,manager")]
        public IActionResult Delete(string id)
        {
            var fight = _fightService.Get(id);

            if (fight == null)
            {
                return NotFound();
            }

            _fightService.Remove(fight.Id);

            return NoContent();
        }
    }
}
