using System.Collections.Generic;
using System.Threading.Tasks;
using AircraftAPI.Service;
using AuthenticationAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AircraftAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly AircraftService _aircraftService;


        public AircraftController(AircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet]
     [Authorize(Roles = "employee,manager")]
        public async  Task<ActionResult<List<Aircraft>>> Get() =>
            _aircraftService.Get();


        [HttpGet("{id:length(24)}", Name = "GetAircraft")]
        [Authorize(Roles = "employee,manager")]
        public async  Task<ActionResult<Aircraft>> Get(string id)
        {
            var aircraft =  _aircraftService.Get(id);

            if (aircraft == null)
            {
                return Conflict("Não possui nenhuma Aeronave cadastrada com esse ID"); 
            }

            return aircraft;
        }


        [HttpGet("{Registry}", Name = "GetRegistry")]
        [AllowAnonymous]
        public ActionResult<Aircraft> GetAirportRegistry(string Registry)
        {
            var aircraft = _aircraftService.GetRegistry(Registry);

            if (aircraft == null)
                return NotFound("Aircraft no Exist");

            return aircraft;
        }


        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Aircraft>> Create(Aircraft aircraft)
        {         

                var registry = _aircraftService.CheckRegistro(aircraft.Registry);

                if (registry == null)
                {
                    _aircraftService.Create(aircraft);
                }
                else
                {
                    return Conflict("Registered  already  aircraft!!");
                }
            
            return CreatedAtRoute("GetAircraft", new { Id = aircraft.Id.ToString() }, aircraft);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Update(string id, Aircraft aircraftIn)
        {
            var aircraft = _aircraftService.Get(id);

  

            if (aircraft == null)
            {
                return Conflict("Id not found!!");  
            }
            _aircraftService.Update(id, aircraftIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Delete(string id)
        {
            var aircraft = _aircraftService.Get(id);

            if (aircraft == null)
            {
                return Conflict("Id not found!!");
            }

            _aircraftService.Remove(aircraft.Id);

            return NoContent();
        }
    }
}
