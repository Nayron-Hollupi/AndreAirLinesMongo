using System.Collections.Generic;
using System.Threading.Tasks;
using AirportDapper.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace AirportDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportDapperController : ControllerBase
    {
     
            private readonly AirportDataService _airportDataService;


            public AirportDapperController(AirportDataService aiportDataService)
            {
                _airportDataService = aiportDataService;
            }

            [HttpGet]
            public ActionResult<List<AirportData>> Get() =>
                _airportDataService.GetAll();


            [HttpPost]
            public async Task<ActionResult<AirportData>> Create(AirportData airportData)
            {
                                           
                    _airportDataService.Add(airportData);
             
                              
                return CreatedAtRoute("GetAirport", new { Id = airportData.Id }, airportData);
            }


        }
    }

