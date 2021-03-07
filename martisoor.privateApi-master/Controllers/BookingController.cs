using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bknsystem.privateApi.Models;
using martisoor.privateApi_master.Models;

namespace bknsystem.privateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly Datalayer _context;

        public BookingController(Datalayer context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hotel_booking>>> Gethotel_booking()
        {
            return await _context.hotel_booking.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<hotel_booking>> Gethotel_booking(int id)
        {
            var hotel_booking = await _context.hotel_booking.FindAsync(id);

            if (hotel_booking == null)
            {
                return NotFound();
            }

            return hotel_booking;
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Puthotel_booking(int id, hotel_booking hotel_booking)
        {
            if (id != hotel_booking.id)
            {
                return BadRequest();
            }

            _context.Entry(hotel_booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotel_bookingExists(id))
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

        // POST: api/Booking
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post")]
        public async Task<ActionResult<hotel_booking>> Posthotel_booking(hotel_booking hotel_booking)
        {
            _context.hotel_booking.Add(hotel_booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethotel_booking", new { id = hotel_booking.id }, hotel_booking);
        }

        // DELETE: api/Booking/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<hotel_booking>> Deletehotel_booking(int id)
        {
            var hotel_booking = await _context.hotel_booking.FindAsync(id);
            if (hotel_booking == null)
            {
                return NotFound();
            }

            _context.hotel_booking.Remove(hotel_booking);
            await _context.SaveChangesAsync();

            return hotel_booking;
        }

        private bool hotel_bookingExists(int id)
        {
            return _context.hotel_booking.Any(e => e.id == id);
        }

        
           [HttpGet("get-guesthouses-booking")]
        public async Task<ActionResult<IEnumerable<guesthouse_booking>>> GetGuestHouse_booking()
        {
            return await _context.guesthouse_booking.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("get-guesthouse-booking/{id}")]
        public async Task<ActionResult<guesthouse_booking>> GetGuestHouse_booking(int id)
        {
            var guest_booking = await _context.guesthouse_booking.FindAsync(id);

            if (guest_booking == null)
            {
                return NotFound();
            }

            return guest_booking;
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_guesthouse_booking/{id}")]
        public async Task<IActionResult> PutGuestHouse_booking(int id, guesthouse_booking guest_booking)
        {
            if (id != guest_booking.id)
            {
                return BadRequest();
            }

            _context.Entry(guest_booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!guestHouse_bookingExists(id))
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

        // POST: api/Booking
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("add-guesthousebooking")]
        public async Task<ActionResult<guesthouse_booking>> PostGuestHouse_booking(guesthouse_booking guest_booking)
        {
            _context.guesthouse_booking.Add(guest_booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuestHouse_booking", new { id = guest_booking.id }, guest_booking);
        }

        // DELETE: api/Booking/5
        [HttpDelete("delete-booking-guesthouse/{id}")]
        public async Task<ActionResult<guesthouse_booking>> DeleteGuestHouse_booking(int id)
        {
            var guest_booking = await _context.guesthouse_booking.FindAsync(id);
            if (guest_booking == null)
            {
                return NotFound();
            }

            _context.guesthouse_booking.Remove(guest_booking);
            await _context.SaveChangesAsync();

            return guest_booking;
        }

        private bool guestHouse_bookingExists(int id)
        {
            return _context.guesthouse_booking.Any(e => e.id == id);
        }
    }
}
