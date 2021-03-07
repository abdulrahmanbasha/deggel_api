using System;
using bknsystem.privateApi.Models;

namespace martisoor.privateApi_master.Dtos
{
    public class GuestHouseCreateForm_Dto
    {
    
        public string guest_name { get; set; }
        public string description { get; set; }
        public decimal stars { get; set; }
        public decimal price { get; set; }
        public AddressGuest address { get; set; }
        //public RoomGuest rooms { get; set; }
        //public AmenityGuest amenities { get; set; }
    }
}