using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using PriceBaseAPI.Service;
using Service;

namespace PriceBaseAPI.Controllers
{
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
        public ActionResult<List<PriceBase>> Get() =>
            _priceBaseService.Get();


        [HttpGet("{id:length(24)}", Name = "GetPriceBase")]
        public ActionResult<PriceBase> Get(string id)
        {
            var priceBase = _priceBaseService.Get(id);

            if (priceBase == null)
            {
                return NotFound();
            }

            return priceBase;
        }

        [HttpPost]
        public async Task<ActionResult<PriceBase>> CreateAsync(PriceBase priceBase)
        {
              
            var origin = await ServiceSeachAirport.SeachAirport(priceBase.Origin.CodeIATA);
            var Destination = await ServiceSeachAirport.SeachAirport(priceBase.Destination.CodeIATA);

            if (origin != null && Destination != null)
            {
                if (origin.CodeIATA != Destination.CodeIATA)
                {

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
