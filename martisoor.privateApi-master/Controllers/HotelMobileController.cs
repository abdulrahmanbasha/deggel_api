using System;
using System.Collections.Generic;
using System.Linq;
using bknsystem.privateApi.Models;
using bknsystem.privateApi.Repositories;
using bknsystem.privateApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bknsystem.privateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class HotelMobileController : ControllerBase
    {
        private readonly IHotelRepository _repository;
        private readonly HotelServiceMobile _hotelservice;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly Datalayer _context;

        public HotelMobileController(HotelServiceMobile hotelService, IHotelRepository repo,
                                        IHttpContextAccessor httpContextAccessor, Datalayer context)
        {
            _hotelservice = hotelService;
            _context = context;

            _repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetTopVisitedHotels")]
        public ActionResult<List<hotel>> GetTopVisitedHotels()
        {
            try
            {
                var hotels = _hotelservice.GetTopVisitedHotels();
                return hotels;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("GetAllHotels")]
        public ActionResult<List<hotel>> GetAllHotels()
        {
            try
            {
                var hotels = _hotelservice.GetAllHotels();
                //foreach (var hotelDetail in hotels)
                //{
                //    hotelDetail.lowestRoomPrice = hotelDetail.rooms.Count == 0 ? 20 : hotelDetail.rooms.Min(room => room.room_price);
                //}
                return hotels;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("GethotelsByCity/{city}")]
        public ActionResult<List<hotel>> GethotelsByCity(string city)
        {
            try
            {
                var hotels = _hotelservice.GetHotelsByCitty(city);
                return hotels;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpGet("SearchHotelsByName")]
        public ActionResult<List<hotel>> SearchHotelsByName([FromQuery] string name)
        {
            try
            {
                var hotels = _hotelservice.SearchHotelsByName(name);
                return hotels;
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
