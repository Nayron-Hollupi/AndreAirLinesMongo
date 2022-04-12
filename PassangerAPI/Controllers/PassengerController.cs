using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using PassengerAPI.Service;
using Service;
using ServicePassenger;

namespace PassengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerService _passengerService;


        public PassengerController(PassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<Passenger>> Get() =>
            _passengerService.Get();


        [HttpGet("{id:length(24)}", Name = "GetPassenger")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<Passenger> Get(string id)
        {
            var passenger = _passengerService.Get(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return passenger;
        }


        [HttpGet("{CodePassenger}", Name = "GetCodePassenger")]
        [AllowAnonymous]
        public async Task<ActionResult<Passenger>> GetCodeBooking(string codePassenger)
        {
            var passenger = await  ServiceSeachPassenger.SeachPassenger(codePassenger);

            if (passenger == null)
                return NotFound("Passenger no Exist");

            return  passenger;
        }

        [HttpPost]
        [Authorize(Roles = "employee,manager")]
        public  async Task<ActionResult<Passenger>> Create(Passenger passenger)
        {
            var cpf = _passengerService.ExistCPF(passenger.CPF);
            var check = _passengerService.CheckCpf(passenger.CPF);
           

            if (check == true)
            {
                if (cpf == null)
                {
                  
                    var address = await ServiceCep.CorreioApi(passenger.Address.CEP);
                    if (address != null)
                    {
                        passenger.Address = address;
                    }
                    _passengerService.Create(passenger);
                }
                else
                {
                    return Conflict("CPF já esta cadastrado");
                }
            }
            else
            {
                return Conflict("CPF invalido");
            }


            return CreatedAtRoute("GetPassenger", new { Id = passenger.Id.ToString() }, passenger);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "employee,manager")]
        public IActionResult Update(string id, Passenger passengerIn)
        {
            var passenger = _passengerService.Get(id);

            if (passenger == null)
            {
                return NotFound();
            }

            _passengerService.Update(id, passengerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(string id)
        {
            var passenger = _passengerService.Get(id);

            if (passenger == null)
            {
                return NotFound();
            }

            _passengerService.Remove(passenger.Id);

            return NoContent();
        }


    }
}
