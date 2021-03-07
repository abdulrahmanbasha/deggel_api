using bknsystem.privateApi.Models;

namespace martisoor.privateApi_master.Dtos
{
    public class GuestHouseListSummary_Dto
    {
        public string id { get; set; }
        public string guest_name { get; set; }
        public string description { get; set; }
        public decimal stars { get; set; }
        public decimal price { get; set; }

        public string image_url { get; set; }
        public decimal average_review { get; set; }
        public int number_of_review_count { get; set; }
        public AddressGuest  address { get; set; }
  
    }
}