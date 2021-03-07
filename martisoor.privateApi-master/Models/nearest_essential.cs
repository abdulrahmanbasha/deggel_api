using System;

namespace bknsystem.privateApi.Models
{
    public class nearest_essential
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public decimal distance { get; set; }
        public DateTime? created_on { get; set; }
        public string created_by { get; set; }
        public string hotel_id { get; set; }

    }
}