using System;

namespace bknsystem.privateApi.Helpers
{
    public class FilterParams
    {
        public string destination { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public int no_of_rooms { get; set; }
        public int number_of_guests { get; set; }
        public int star_rating { get; set; }
        public decimal price_range_from { get; set; }
        public decimal price_range_to { get; set; }
        // public  MyProperty { get; set; }

    }
}