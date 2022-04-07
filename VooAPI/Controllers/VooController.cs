using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using FlightsAPI.Service;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly VooService _vooService;


        public VooController(VooService vooService)
        {
            _vooService = vooService;
        }

        [HttpGet]
        public ActionResult<List<Flights>> Get() =>
            _vooService.Get();


        [HttpGet("{id:length(24)}", Name = "GetVoo")]
        public ActionResult<Flights> Get(string id)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        [HttpPost]
        public ActionResult<Flights> Create(Flights voo)
        {

            if(voo.Destino == voo.Origem)
            {
                _vooService.Create(voo);
            }
            else
            {
                return Conflict("Origem e Destino não podem ser iguais");
            }
            

            return CreatedAtRoute("GetVoo", new { Id = voo.Id.ToString() }, voo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Flights vooIn)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
            {
                return NotFound();
            }

            _vooService.Update(id, vooIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var voo = _vooService.Get(id);

            if (voo == null)
            {
                return NotFound();
            }

            _vooService.Remove(voo.Id);

            return NoContent();
        }
    }
}
