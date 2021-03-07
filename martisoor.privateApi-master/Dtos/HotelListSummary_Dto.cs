using System.Security.Policy;
using bknsystem.privateApi.Models;

namespace bknsystem.privateApi.Dtos
{
    public class HotelListSummary_Dto
    {
        
        public string id { get; set; }
        public string hotel_name { get; set; }
        public string description { get; set; }
        public decimal stars { get; set; }

        public string image_url { get; set; }
        public decimal average_review { get; set; }
        public int number_of_review_count { get; set; }
        public decimal lowest_room_price { get; set; }
        public address address { get; set; }
    }
}