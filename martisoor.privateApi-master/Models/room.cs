using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bknsystem.privateApi.Models
{
    public class room
    {
        public int id { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,0}")]

        public string room_type { get; set; }
        public IEnumerable<file> files { get; set; }

        public room_amenity room_amenity { get; set; }
        public int room_beds { get; set; }
        public int floor_number { get; set; }
        public decimal room_price { get; set; }
        public string hotel_id { get; set; }
    }
}