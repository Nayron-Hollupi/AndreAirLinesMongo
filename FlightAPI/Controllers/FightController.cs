﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using FlightsAPI.Service;

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
        public ActionResult<List<Flights>> Get() =>
            _fightService.Get();


        [HttpGet("{id:length(24)}", Name = "GetFight")]
        public ActionResult<Flights> Get(string id)
        {
            var fight = _fightService.Get(id);

            if (fight == null)
            {
                return NotFound();
            }

            return fight;
        }

        [HttpPost]
        public ActionResult<Flights> Create(Flights fight)
        {
                _fightService.Create(fight);
           
           
            return CreatedAtRoute("GetFight", new { Id = fight.Id.ToString() }, fight);
        }

        [HttpPut("{id:length(24)}")]
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
