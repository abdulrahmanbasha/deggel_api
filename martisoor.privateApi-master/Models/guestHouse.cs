using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bknsystem.privateApi.Models
{
    public class guestHouse
    {
        public guestHouse()
        {
            this.image_url="https://cf.bstatic.com/images/hotel/max1024x768/154/154095356.jpg";
        }
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  id { get; set; }= Guid.NewGuid().ToString();
        public string guest_name { get; set; }
        public string description { get; set; }
        public string stars { get; set; }
        public string image_url { get; set; }
        public decimal price { get; set; }
        public AddressGuest address { get; set; }
        public RoomGuest rooms { get; set; }
        public FileGuest[] files { get; set; }
        public AmenityGuest amenities { get; set; }

        public RatingGuest[] ratings { get; set; }
        public ReviewGuest[] reviews { get; set; }
      
        public GuestRule[] house_rules { get; set; }
    }

    // public class _Id
    // {
    //     public string oid { get; set; }
    // }

     public class GuestRule
    {
        public int id { get; set; }
        public string rule_name { get; set; }
        public bool allow { get; set; }

        

    }

    public class ReviewGuest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string review { get; set; }
        public string guest_id { get;  set; }

    }

        public class RatingGuest
    {
        public int id { get; set; }
        public int rate { get; set; }
        public string guest_id { get;  set; }
    }

     public class AmenityGuest
    {
        public int id { get; set; }
        public bool wifi { get; set; }
        public bool fitness_center { get; set; }
        public bool cafeteria { get; set; }
        public bool restaurant { get; set; }
        public bool bathrobes { get; set; }
        public bool dry_cleaning { get; set; }
        public bool high_chair { get; set; }
        public bool slipper { get; set; }
        public bool wakeup_call { get; set; }
        public bool telephone { get; set; }
        public bool air_conditioning { get; set; }
        public bool parking { get; set; }
        public string guest_id { get; set; }
    }

       public class FileGuest
    {
        public int id { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "image")]
        [DataType(DataType.ImageUrl)]
        public string file_url { get; set; }
        public string guest_id { get;  set; }
    }

    public class AddressGuest
    {
        public int id { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string guest_id { get; set; }
    }

    public class Address1
    {
        public object _id { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public object hotel_id { get; set; }
    }

    public class RoomGuest{
               public int id { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0}")]

        public string room_type { get; set; }
      
        public int bath_Rooms { get; set; }
      
        public int room_beds { get; set; }
     
        
        public string guest_id { get; set; }
    }


}
