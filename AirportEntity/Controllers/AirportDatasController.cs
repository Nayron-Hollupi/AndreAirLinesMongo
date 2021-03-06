using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirportEntity.Data;
using Model;
using Microsoft.AspNetCore.Authorization;

namespace AirportEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportDatasController : ControllerBase
    {
        private readonly AirportEntityContext _context;

        public AirportDatasController(AirportEntityContext context)
        {
            _context = context;
        }

        // GET: api/AirportDatas
        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult<IEnumerable<AirportData>>> GetAirportData()
        {
            return await _context.AirportData.ToListAsync();
        }

        // GET: api/AirportDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportData>> GetAirportData(int id)
        {
            var airportData = await _context.AirportData.FindAsync(id);

            if (airportData == null)
            {
                return NotFound();
            }

            return airportData;
        }

        // PUT: api/AirportDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> PutAirportData(int id, AirportData airportData)
        {
            if (id != airportData.Id)
            {
                return BadRequest();
            }

            _context.Entry(airportData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AirportDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirportData>> PostAirportData(AirportData airportData)
        {

            _context.AirportData.Add(airportData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirportData", new { id = airportData.Id }, airportData);
        }

        // DELETE: api/AirportDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirportData(int id)
        {
            var airportData = await _context.AirportData.FindAsync(id);
            if (airportData == null)
            {
                return NotFound();
            }

            _context.AirportData.Remove(airportData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirportDataExists(int id)
        {
            return _context.AirportData.Any(e => e.Id == id);
        }
    }
}
