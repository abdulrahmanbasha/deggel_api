using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Helpers;
using bknsystem.privateApi.Models;
using bknsystem.privateApi.Repositories;
using bknsystem.privateApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bknsystem.privateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class HotelController : ControllerBase
    {


        private readonly IHotelRepository _repository;
        private readonly HotelService _hotelservice;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly Datalayer _context;


        public HotelController(HotelService hotelService, IHotelRepository repo,
                                        IHttpContextAccessor httpContextAccessor, Datalayer context)
        {
            _hotelservice = hotelService;
            _context = context;

            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPut("UpdateHotel/{id}")]
        public async Task<IActionResult> Edithotel(string id, hotel hotel)
        {
            if (id != hotel.id)
            {
                return BadRequest();
            }

            try
            {
                var hotel_update = _repository.UpdateHotel(id, hotel);
                return Ok(hotel_update);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(501);
                }
            }
        }



        [HttpDelete("DeleteHotel/{id}")]
        public async Task<IActionResult> DeleteHotel(string id)
        {
            try
            {
                var delete_hotel = _repository.DeleteHotel(id);
                return Ok(delete_hotel);
            }
            catch (Exception e)
            {
                return StatusCode(501);
            }
        }

        [HttpPost("register_hotel")]
        public async Task<ActionResult<hotel>> Posthotel(HotelCreateForm_Dto hotelCreateForm_)
        {
            try
            {
                var created_hotel = _repository.Create(hotelCreateForm_);
                return Created("api/hotel/Gethotel", new { id = created_hotel.id });
            }
            catch (Exception e)
            {
                return StatusCode(501);
            }
        }


        [HttpGet("GetHotel/{id}")]
        public async Task<ActionResult<hotel>> Gethotel(string id)
        {
            try
            {
                var hotel_info = _repository.GetHotelById(id);
                hotel_info.rooms = _context.room.Where(m => m.hotel_id == id).Include(a => a.room_amenity).ToList();
                hotel_info.address = _context.address.Where(m => m.hotel_id == id).FirstOrDefault();
                hotel_info.amenities = _context.hotel_amenity.Where(m => m.hotel_id == id).FirstOrDefault();
                hotel_info.addresses = _context.address.Where(m => m.hotel_id == id).ToList();
                hotel_info.files = _context.Files.Where(m => m.hotel_id == id).ToList();
                hotel_info.reviews = _context.review.Where(m => m.hotel_id == id).ToList();
                hotel_info.ratings = _context.rating.Where(m => m.hotel_id == id).ToList();
                hotel_info.get_around = _context.getting_around.Where(m => m.hotel_id == id).ToList();
                hotel_info.property_detail = _context.property_detail.Where(m => m.hotel_id == id).FirstOrDefault();
                hotel_info.nearest_essentials = _context.nearest_essential.Where(m => m.hotel_id == id).ToList();

                return hotel_info;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        


        [HttpGet("GetHotelSummary")]
        public async Task<ActionResult<List<HotelListSummary_Dto>>> Get_hotel_summary([FromQuery]RequestParams requestParams = default)
        {

            // [FromBody] SearchFilter searchFilter
            try
            {
                var hotels = _repository.GetHotelListSummaries(requestParams);

                Response.AddPagination(hotels.CurrentPage, hotels.PageSize,
                 hotels.TotalCount, hotels.TotalPages);
                return Ok(hotels);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                //var logResult = _logger.Log(e, User.Identity.Name);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }





        private bool hotelExists(string id)
        {
            return _context.hotel.Any(e => e.id == id);
        }







        /// ROOMS

        [HttpGet("Rooms")]
        public async Task<ActionResult<IEnumerable<room>>> Getroom()
        {
            return await _context.room.ToListAsync();
        }

        // GET: api/rooms/5
        [HttpGet("Room/{id}")]
        public async Task<ActionResult<room>> Getroom(int id)
        {
            var room = await _context.room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/rooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_room/{id}")]
        public async Task<IActionResult> Putroom(int id, room room)
        {
            if (id != room.id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomExists(id))
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

        // POST: api/rooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_rooms/{id}")]
        public async Task<ActionResult<room>> Postroom(room room)
        {
            _context.room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom", new { id = room.id }, room);
        }

        // DELETE: api/rooms/5
        [HttpDelete("delete_rooms/{id}")]
        public async Task<ActionResult<room>> Deleteroom(int id)
        {
            var room = await _context.room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.room.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool roomExists(int id)
        {
            return _context.room.Any(e => e.id == id);
        }




        // nearest essential

        [HttpGet("nearest_essentials")]
        public async Task<ActionResult<IEnumerable<nearest_essential>>> Getnearest_essential()
        {
            return await _context.nearest_essential.ToListAsync();
        }

        // GET: api/nearest_essential/5
        [HttpGet("nearest_essential/{id}")]
        public async Task<ActionResult<nearest_essential>> Getnearest_essential(int id)
        {
            var nearest_essential = await _context.nearest_essential.FindAsync(id);

            if (nearest_essential == null)
            {
                return NotFound();
            }

            return nearest_essential;
        }

        // PUT: api/nearest_essential/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_nearest_essential/{id}")]
        public async Task<IActionResult> Putnearest_essential(int id, nearest_essential nearest_essential)
        {
            if (id != nearest_essential.id)
            {
                return BadRequest();
            }

            _context.Entry(nearest_essential).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nearest_essentialExists(id))
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

        // POST: api/nearest_essential
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_nearest_essential")]
        public async Task<ActionResult<nearest_essential>> Postnearest_essential(nearest_essential nearest_essential)
        {
            _context.nearest_essential.Add(nearest_essential);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnearest_essential", new { id = nearest_essential.id }, nearest_essential);
        }

        // DELETE: api/nearest_essential/5
        [HttpDelete("delete_nearest_essential/{id}")]
        public async Task<ActionResult<nearest_essential>> Deletenearest_essential(int id)
        {
            var nearest_essential = await _context.nearest_essential.FindAsync(id);
            if (nearest_essential == null)
            {
                return NotFound();
            }

            _context.nearest_essential.Remove(nearest_essential);
            await _context.SaveChangesAsync();

            return nearest_essential;
        }

        private bool nearest_essentialExists(int id)
        {
            return _context.nearest_essential.Any(e => e.id == id);
        }





        // checkin checkout  times

        // GET: api/check_in_check_out
        [HttpGet("check_in_check_outs")]
        public async Task<ActionResult<IEnumerable<check_in_check_out>>> Getcheck_in_check_out()
        {
            return await _context.check_in_check_out.ToListAsync();
        }

        // GET: api/check_in_check_out/5
        [HttpGet("check_in_check_out/{id}")]
        public async Task<ActionResult<check_in_check_out>> Getcheck_in_check_out(int id)
        {
            var check_in_check_out = await _context.check_in_check_out.FindAsync(id);

            if (check_in_check_out == null)
            {
                return NotFound();
            }

            return check_in_check_out;
        }

        // PUT: api/check_in_check_out/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_check_in_check_out/{id}")]
        public async Task<IActionResult> Putcheck_in_check_out(int id, check_in_check_out check_in_check_out)
        {
            if (id != check_in_check_out.id)
            {
                return BadRequest();
            }

            _context.Entry(check_in_check_out).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!check_in_check_outExists(id))
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

        // POST: api/check_in_check_out
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_check_in_check_out")]
        public async Task<ActionResult<check_in_check_out>> Postcheck_in_check_out(check_in_check_out check_in_check_out)
        {
            _context.check_in_check_out.Add(check_in_check_out);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcheck_in_check_out", new { id = check_in_check_out.id }, check_in_check_out);
        }

        // DELETE: api/check_in_check_out/5
        [HttpDelete("delete_check_in_check_out/{id}")]
        public async Task<ActionResult<check_in_check_out>> Deletecheck_in_check_out(int id)
        {
            var check_in_check_out = await _context.check_in_check_out.FindAsync(id);
            if (check_in_check_out == null)
            {
                return NotFound();
            }

            _context.check_in_check_out.Remove(check_in_check_out);
            await _context.SaveChangesAsync();

            return check_in_check_out;
        }

        private bool check_in_check_outExists(int id)
        {
            return _context.check_in_check_out.Any(e => e.id == id);
        }


        // getting around actions

        // GET: api/getting_around
        [HttpGet("getting_around")]
        public async Task<ActionResult<IEnumerable<getting_around>>> Getgetting_around()
        {
            return await _context.getting_around.ToListAsync();
        }

        // GET: api/getting_around/5
        [HttpGet("getting_around/{id}")]
        public async Task<ActionResult<getting_around>> Getgetting_around(int id)
        {
            var getting_around = await _context.getting_around.FindAsync(id);

            if (getting_around == null)
            {
                return NotFound();
            }

            return getting_around;
        }

        // PUT: api/getting_around/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_getting_around/{id}")]
        public async Task<IActionResult> Putgetting_around(int id, getting_around getting_around)
        {
            if (id != getting_around.id)
            {
                return BadRequest();
            }

            _context.Entry(getting_around).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!getting_aroundExists(id))
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

        // POST: api/getting_around
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_getting_around")]
        public async Task<ActionResult<getting_around>> Postgetting_around(getting_around getting_around)
        {
            _context.getting_around.Add(getting_around);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgetting_around", new { id = getting_around.id }, getting_around);
        }

        // DELETE: api/getting_around/5
        [HttpDelete("delete_getting_around/{id}")]
        public async Task<ActionResult<getting_around>> Deletegetting_around(int id)
        {
            var getting_around = await _context.getting_around.FindAsync(id);
            if (getting_around == null)
            {
                return NotFound();
            }

            _context.getting_around.Remove(getting_around);
            await _context.SaveChangesAsync();

            return getting_around;
        }

        private bool getting_aroundExists(int id)
        {
            return _context.getting_around.Any(e => e.id == id);
        }



        // GET: api/property_detail
        [HttpGet("property_detail")]
        public async Task<ActionResult<IEnumerable<property_detail>>> Getproperty_detail()
        {
            return await _context.property_detail.ToListAsync();
        }

        // GET: api/property_detail/5
        [HttpGet("property_detail/{id}")]
        public async Task<ActionResult<property_detail>> Getproperty_detail(int id)
        {
            var property_detail = await _context.property_detail.FindAsync(id);

            if (property_detail == null)
            {
                return NotFound();
            }

            return property_detail;
        }

        // PUT: api/property_detail/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_property_detail/{id}")]
        public async Task<IActionResult> Putproperty_detail(int id, property_detail property_detail)
        {
            if (id != property_detail.id)
            {
                return BadRequest();
            }

            _context.Entry(property_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!property_detailExists(id))
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

        // POST: api/property_detail
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_property_detail")]
        public async Task<ActionResult<property_detail>> Postproperty_detail(property_detail property_detail)
        {
            _context.property_detail.Add(property_detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproperty_detail", new { id = property_detail.id }, property_detail);
        }

        // DELETE: api/property_detail/5
        [HttpDelete("delete_property_detail/{id}")]
        public async Task<ActionResult<property_detail>> Deleteproperty_detail(int id)
        {
            var property_detail = await _context.property_detail.FindAsync(id);
            if (property_detail == null)
            {
                return NotFound();
            }

            _context.property_detail.Remove(property_detail);
            await _context.SaveChangesAsync();

            return property_detail;
        }

        private bool property_detailExists(int id)
        {
            return _context.property_detail.Any(e => e.id == id);
        }

        // amenties


        // GET: api/amenities
        [HttpGet("hotel_amenity")]
        public async Task<ActionResult<IEnumerable<amenity>>> Getamenity()
        {
            return await _context.hotel_amenity.ToListAsync();
        }

        // GET: api/amenities/5
        [HttpGet("hotel_amenity/{id}")]
        public async Task<ActionResult<amenity>> Getamenity(int id)
        {
            var amenity = await _context.hotel_amenity.FindAsync(id);

            if (amenity == null)
            {
                return NotFound();
            }

            return amenity;
        }

        // PUT: api/amenities/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_hotel_amenity/{id}")]
        public async Task<IActionResult> Putamenity(int id, amenity amenity)
        {
            if (id != amenity.id)
            {
                return BadRequest();
            }

            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!amenityExists(id))
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

        // POST: api/amenities
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_hotel_amenity")]
        public async Task<ActionResult<amenity>> Postamenity(amenity amenity)
        {
            _context.hotel_amenity.Add(amenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getamenity", new { id = amenity.id }, amenity);
        }

        // DELETE: api/amenities/5
        [HttpDelete("delete_hotel_amenity/{id}")]
        public async Task<ActionResult<amenity>> Deleteamenity(int id)
        {
            var amenity = await _context.hotel_amenity.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }

            _context.hotel_amenity.Remove(amenity);
            await _context.SaveChangesAsync();

            return amenity;
        }

        private bool amenityExists(int id)
        {
            return _context.hotel_amenity.Any(e => e.id == id);
        }


        // reviews

        // GET: api/reviews
        [HttpGet("hotel_reviews")]
        public async Task<ActionResult<IEnumerable<review>>> Getreview()
        {
            return await _context.review.ToListAsync();
        }

        // GET: api/reviews/5
        [HttpGet("hotel_reviews/{id}")]
        public async Task<ActionResult<review>> Getreview(int id)
        {
            var review = await _context.review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/reviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_hotel_reviews/{id}")]
        public async Task<IActionResult> Putreview(int id, review review)
        {
            if (id != review.id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reviewExists(id))
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

        // POST: api/reviews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_hotel_reviews")]
        public async Task<ActionResult<review>> Postreview(review review)
        {
            _context.review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreview", new { id = review.id }, review);
        }

        // DELETE: api/reviews/5
        [HttpDelete("delte_hotel_reviews/{id}")]
        public async Task<ActionResult<review>> Deletereview(int id)
        {
            var review = await _context.review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.review.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool reviewExists(int id)
        {
            return _context.review.Any(e => e.id == id);
        }


        // ratings

        // GET: api/ratings
        [HttpGet("hotel_ratings")]
        public async Task<ActionResult<IEnumerable<rating>>> Getrating()
        {
            return await _context.rating.ToListAsync();
        }

        // GET: api/ratings/5
        [HttpGet("hotel_ratings/{id}")]
        public async Task<ActionResult<rating>> Getrating(int id)
        {
            var rating = await _context.rating.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }

        // PUT: api/ratings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_hotel_ratings/{id}")]
        public async Task<IActionResult> Putrating(int id, rating rating)
        {
            if (id != rating.id)
            {
                return BadRequest();
            }

            _context.Entry(rating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ratingExists(id))
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

        // POST: api/ratings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_hotel_ratings")]
        public async Task<ActionResult<rating>> Postrating(rating rating)
        {
            _context.rating.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrating", new { id = rating.id }, rating);
        }

        // DELETE: api/ratings/5
        [HttpDelete("delete_hotel_ratings/{id}")]
        public async Task<ActionResult<rating>> Deleterating(int id)
        {
            var rating = await _context.rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            _context.rating.Remove(rating);
            await _context.SaveChangesAsync();
            return rating;
        }
        private bool ratingExists(int id)
        {
            return _context.rating.Any(e => e.id == id);
        }


    }
}