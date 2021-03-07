using System;
using bknsystem.privateApi.Models;

namespace bknsystem.privateApi.Dtos
{
    public class HotelCreateForm_Dto
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string hotel_name { get; set; }
        public string description { get; set; }
        public decimal stars { get; set; }
        public address address { get; set; }
    }
}