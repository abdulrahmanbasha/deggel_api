using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bknsystem.privateApi.Models
{
    public class hotel
    {
           //  "ConnStr": "Data Source=SQL5057.site4now.net;Initial Catalog=DB_A447BB_abdulrahmanbash;User Id=DB_A447BB_abdulrahmanbash_admin;Password=rmVPzPHrQFX72;" 
        public hotel()
        {
            this.image_url = "https://res.cloudinary.com/ddcqvyjdy/image/upload/v1558421365/file_fdreky.jpg";
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string hotel_name { get; set; }
        public string description { get; set; }
        public decimal stars { get; set; }
        public string image_url { get; set; }
        public address address { get; set; }

        public IEnumerable<room> rooms { get; set; } = new List<room>();
        public IEnumerable<file> files { get; set; } = new List<file>();
        public amenity amenities { get; set; }
        public IEnumerable<address> addresses { get; set; }
        public IEnumerable<rating> ratings { get; set; } = new List<rating>();
        public IEnumerable<review> reviews { get; set; } = new List<review>();
        public IEnumerable<nearest_essential> nearest_essentials { get; set; } = new List<nearest_essential>();
        public IEnumerable<nearby_place> nearby_places { get; set; } = new List<nearby_place>();
        public IEnumerable<house_rule> house_rules { get; set; } = new List<house_rule>();
        public IEnumerable<nearby_hotel> nearby_hotels { get; set; } = new List<nearby_hotel>();
        public IEnumerable<getting_around> get_around { get; set; }
        public property_detail property_detail { get;  set; }
    }
}