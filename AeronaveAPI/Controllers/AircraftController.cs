using System.Collections.Generic;
using System.Threading.Tasks;
using AircraftAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AircraftAPI.Controllers
{
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
        public async  Task<ActionResult<List<Aircraft>>> Get() =>
            _aircraftService.Get();


        [HttpGet("{id:length(24)}", Name = "GetAircraft")]
        public async  Task<ActionResult<Model.Aircraft>> Get(string id)
        {
            var aircraft =  _aircraftService.Get(id);

            if (aircraft == null)
            {
                return Conflict("Não possui nenhuma Aeronave cadastrada com esse ID");  NotFound();
            }

            return aircraft;
        }

        [HttpPost]
        public async Task<ActionResult<Aircraft>> Create(Aircraft aircraft)
        {

            var registry =  _aircraftService.CheckRegistro(aircraft.Registry);

                if(registry == null)
            {
                _aircraftService.Create(aircraft);
            }
            else
            {
                return Conflict("Já existe uma aeronave com esse registro cadastrada?");
            }
          

            return CreatedAtRoute("GetAircraft", new { Id = aircraft.Id.ToString() }, aircraft);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Aircraft aircraftIn)
        {
            var aircraft = _aircraftService.Get(id);

            if (aircraft == null)
            {
                return Conflict("Não possui nenhuma Aeronave cadastrada com esse ID");  NotFound();
            }

            _aircraftService.Update(id, aircraftIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var aircraft = _aircraftService.Get(id);

            if (aircraft == null)
            {
                return Conflict("Não possui nenhuma Aeronave cadastrada com esse ID"); NotFound();
            }

            _aircraftService.Remove(aircraft.Id);

            return NoContent();
        }
    }
}
