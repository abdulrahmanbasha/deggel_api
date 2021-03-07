using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Helpers;
using bknsystem.privateApi.Models;
using bknsystem.privateApi.Services;
using martisoor.privateApi_master.Dtos;
using martisoor.privateApi_master.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace martisoor.privateApi_master.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class GuestHouseController : ControllerBase
    {
        
        private readonly IGuestRepository _repository;
        private readonly HotelService _hotelservice;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly Datalayer _context;


        public GuestHouseController(HotelService hotelService, IGuestRepository repo,
                                        IHttpContextAccessor httpContextAccessor, Datalayer context)
        {
            _hotelservice = hotelService;
            _context = context;

            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPut("UpdateGuestHouse/{id}")]
        public async Task<IActionResult> Edithotel(string id, guestHouse hotel)
        {
            if (id != hotel.id)
            {
                return BadRequest();
            }

            try
            {
                var hotel_update = _repository.UpdateGuest(id, hotel);
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



        [HttpDelete("DeleteGuestHouse/{id}")]
        public async Task<IActionResult> DeleteHotel(string id)
        {
            try
            {
                var delete_hotel = _repository.DeleteGuestHouse(id);
                return Ok(delete_hotel);
            }
            catch (Exception e)
            {
                return StatusCode(501);
            }
        }

        [HttpPost("register_guesthouse")]
        public async Task<ActionResult<hotel>> Posthotel(GuestHouseCreateForm_Dto hotelCreateForm_)
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


        [HttpGet("GetGuestHouse/{id}")]
        public async Task<ActionResult<guestHouse>> Gethotel(string id)
        {
            try
            {
                var hotel_info = _repository.GetGuestHouseById(id);
                hotel_info.rooms = _context.room_guest.Where(m => m.guest_id == id).FirstOrDefault();
                hotel_info.address = _context.address_guest.Where(m => m.guest_id== id).FirstOrDefault();
                hotel_info.amenities = _context.amenity_guest.Where(m => m.guest_id == id).FirstOrDefault();
                //hotel_info.files = _context.file_gueset.Where(m => m.guest_id == id).ToList();
                //hotel_info.reviews = _context.review.Where(m => m.hotel_id == id).ToList();
               // hotel_info.ratings = _context.rating.Where(m => m.hotel_id == id).ToList();
              //  hotel_info.get_around = _context.getting_around.Where(m => m.hotel_id == id).ToList();
              //  hotel_info.property_detail = _context.property_detail.Where(m => m.hotel_id == id).FirstOrDefault();
              //  hotel_info.nearest_essentials = _context.nearest_essential.Where(m => m.hotel_id == id).ToList();

                return hotel_info;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        


        [HttpGet("GetGuestHouseSummary")]
        public async Task<ActionResult<List<GuestHouseListSummary_Dto>>> Get_hotel_summary([FromQuery]RequestParams requestParams = default)
        {

            // [FromBody] SearchFilter searchFilter
            try
            {
                var hotels = _repository.GetGuestHouseListSummaries(requestParams);

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
            return _context.guest_house.Any(e => e.id == id);
        }







        /// ROOMS

        [HttpGet("Rooms_Guest")]
        public async Task<ActionResult<IEnumerable<RoomGuest>>> Getroom()
        {
            return await _context.room_guest.ToListAsync();
        }

        // GET: api/rooms/5
        [HttpGet("Room_Guest/{id}")]
        public async Task<ActionResult<RoomGuest>> Getroom(int id)
        {
            var room = await _context.room_guest.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/rooms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_room_guest/{id}")]
        public async Task<IActionResult> Putroom(int id, RoomGuest room)
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

        
        private bool roomExists(int id)
        {
            return _context.room_guest.Any(e => e.id == id);
        }

        // POST: api/rooms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("post_rooms_guest/{id}")]
        public async Task<ActionResult<room>> Postroom(RoomGuest room)
        {
            _context.room_guest.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom", new { id = room.id }, room);
        }

        // DELETE: api/rooms/5
        [HttpDelete("delete_rooms/{id}")]
        public async Task<ActionResult<RoomGuest>> Deleteroom(int id)
        {
            var room = await _context.room_guest.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.room_guest.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }







        // GET: api/amenities
        [HttpGet("guesthouse_amenity")]
        public async Task<ActionResult<IEnumerable<AmenityGuest>>> Getamenity()
        {
            return await _context.amenity_guest.ToListAsync();
        }

        // GET: api/amenities/5
        [HttpGet("guesthouse_amenity/{id}")]
        public async Task<ActionResult<AmenityGuest>> Getamenity(int id)
        {
            var amenity = await _context.amenity_guest.FindAsync(id);

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
        public async Task<IActionResult> Putamenity(int id, AmenityGuest amenity)
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
        [HttpPost("post_guesthouse_amenity")]
        public async Task<ActionResult<amenity>> Postamenity(AmenityGuest amenity)
        {
            _context.amenity_guest.Add(amenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getamenity", new { id = amenity.id }, amenity);
        }

        // DELETE: api/amenities/5
        [HttpDelete("delete_guesthouse_amenity/{id}")]
        public async Task<ActionResult<AmenityGuest>> Deleteamenity(int id)
        {
            var amenity = await _context.amenity_guest.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }

            _context.amenity_guest.Remove(amenity);
            await _context.SaveChangesAsync();

            return amenity;
        }

        private bool amenityExists(int id)
        {
            return _context.amenity_guest.Any(e => e.id == id);
        }


        // reviews

        // GET: api/reviews
        [HttpGet("guesthouse_reviews")]
        public async Task<ActionResult<IEnumerable<ReviewGuest>>> Getreview()
        {
            return await _context.review_guest.ToListAsync();
        }

        // GET: api/reviews/5
        [HttpGet("guesthouse_reviews/{id}")]
        public async Task<ActionResult<ReviewGuest>> Getreview(int id)
        {
            var review = await _context.review_guest.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/reviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_guesthouse_reviews/{id}")]
        public async Task<IActionResult> Putreview(int id, ReviewGuest review)
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
        [HttpPost("post_guesthouse_reviews")]
        public async Task<ActionResult<review>> Postreview(ReviewGuest review)
        {
            _context.review_guest.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreview", new { id = review.id }, review);
        }

        // DELETE: api/reviews/5
        [HttpDelete("delte_guesthouse_reviews/{id}")]
        public async Task<ActionResult<ReviewGuest>> Deletereview(int id)
        {
            var review = await _context.review_guest.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.review_guest.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool reviewExists(int id)
        {
            return _context.review.Any(e => e.id == id);
        }


        // ratings

        // GET: api/ratings
        [HttpGet("guesthouse_ratings")]
        public async Task<ActionResult<IEnumerable<RatingGuest>>> Getrating()
        {
            return await _context.rating_guest.ToListAsync();
        }

        // GET: api/ratings/5
        [HttpGet("guesthouse_ratings/{id}")]
        public async Task<ActionResult<RatingGuest>> Getrating(int id)
        {
            var rating = await _context.rating_guest.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            return rating;
        }

        // PUT: api/ratings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("edit_guest_ratings/{id}")]
        public async Task<IActionResult> Putrating(int id, RatingGuest rating)
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
        [HttpPost("post_guesthouse_ratings")]
        public async Task<ActionResult<rating>> Postrating(rating rating)
        {
            _context.rating.Add(rating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrating", new { id = rating.id }, rating);
        }

        // DELETE: api/ratings/5
        [HttpDelete("delete_guesthouse_ratings/{id}")]
        public async Task<ActionResult<RatingGuest>> Deleterating(int id)
        {
            var rating = await _context.rating_guest.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            _context.rating_guest.Remove(rating);
            await _context.SaveChangesAsync();
            return rating;
        }
        private bool ratingExists(int id)
        {
            return _context.rating_guest.Any(e => e.id == id);
        }
    }
}