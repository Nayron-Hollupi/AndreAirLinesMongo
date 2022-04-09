using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BookingAPI.Service;
using Microsoft.AspNetCore.Authorization;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;


        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<List<Booking>> Get() =>
            _bookingService.Get();


        [HttpGet("{id:length(24)}", Name = "GetBooking")]
        [Authorize(Roles = "employee,manager")]
        public ActionResult<Booking> Get(string id)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public ActionResult<Booking> Create(Booking booking)
        {
            _bookingService.Create(booking);

            return CreatedAtRoute("GetBooking", new { Id = booking.Id.ToString() }, booking);
        }

        [HttpPut("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Update(string id, Booking bookingIn)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingService.Update(id, bookingIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [Authorize(Roles = "manager")]
        public IActionResult Delete(string id)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingService.Remove(booking.Id);

            return NoContent();
        }
    }
}
