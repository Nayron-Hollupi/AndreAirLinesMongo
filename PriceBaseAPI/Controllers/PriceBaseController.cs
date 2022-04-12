using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using PriceBaseAPI.Service;
using Service;

namespace PriceBaseAPI.Controllers
{
    [EnableCors("AnotherPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PriceBaseController : ControllerBase
    {
        private readonly PriceBaseService _priceBaseService;


        public PriceBaseController(PriceBaseService priceBaseService)
        {
            _priceBaseService = priceBaseService;
        }

        [HttpGet]
       
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<PriceBase>> Get() =>
            _priceBaseService.Get();


        [HttpGet("{id:length(24)}", Name = "GetPriceBase")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<PriceBase> Get(string id)
        {
            var priceBase = _priceBaseService.Get(id);

            if (priceBase == null)
            {
                return NotFound();
            }

            return priceBase;
        }




        [HttpGet("{Origin}/{Destination}", Name = "GetPriceBaseBooking")]
        public async Task<ActionResult<PriceBase>> GetBookingPrice(string destination, string origin)
        {
            var priceBase = _priceBaseService.GetBookingPriBase(destination, origin);

            if (priceBase == null)
            {
                return NotFound();
            }

            return priceBase;
        }









        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<PriceBase>> CreateAsync(PriceBase priceBase)
        {
              
            var origin = await ServiceSeachAirport.SeachAirport(priceBase.Origin.CodeIATA);
            var destination = await ServiceSeachAirport.SeachAirport(priceBase.Destination.CodeIATA);

            
           

            if (origin != null && destination != null)
            {
                if (origin.CodeIATA != destination.CodeIATA)
                {
                    priceBase.Destination = destination;
                    priceBase.Origin = origin;
                    _priceBaseService.Create(priceBase);
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


            return CreatedAtRoute("GetPriceBase", new { Id = priceBase.Id.ToString() }, priceBase);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Update(string id, PriceBase priceBaseIn)
        {
            var priceBase = _priceBaseService.Get(id);

            if (priceBase == null)
            {
                return NotFound();
            }

            _priceBaseService.Update(id, priceBaseIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(string id)
        {
            var priceBase = _priceBaseService.Get(id);

            if (priceBase == null)
            {
                return NotFound();
            }

            _priceBaseService.Remove(priceBase.Id);

            return NoContent();
        }
    }
}
