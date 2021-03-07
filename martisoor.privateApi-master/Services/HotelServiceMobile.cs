using System.Collections.Generic;
using System.Linq;
using bknsystem.privateApi.Interfaces;
using bknsystem.privateApi.Models;
using MongoDB.Driver;

namespace bknsystem.privateApi.Services
{
    public class HotelServiceMobile
    {

        private readonly IMongoCollection<hotel> _hotels;

        private readonly IMongoCollection<guestHouse> _guest_house;

        public HotelServiceMobile(IHotelDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase("deggeldb");

            _hotels = database.GetCollection<hotel>("hotel");
            _guest_house = database.GetCollection<guestHouse>("gues_houses");
        }

        internal List<hotel> GetTopVisitedHotels()
        {
            var query = _hotels.AsQueryable();
            var hotels = query.Take(5).ToList();

            return hotels;
        }

        internal List<hotel> GetAllHotels()
        {
            var query = _hotels.AsQueryable();
            var hotels = query.ToList();

            return hotels;
        }

        public List<hotel> GetHotelsByCitty(string city)
        {
            var query = _hotels.AsQueryable().Where(h => h.address.city.Equals(city)).ToList();
            return query;
        }

        public List<hotel> SearchHotelsByName(string name)
        {
            var query = _hotels.AsQueryable();
            var hotels = query.Where(h => h.hotel_name.Contains($"{name}")).ToList();
            return hotels;
        }
    }
}