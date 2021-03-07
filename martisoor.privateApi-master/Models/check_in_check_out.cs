using System;

namespace bknsystem.privateApi.Models
{
    public class check_in_check_out
    {
        public int id { get; set; }
        public DateTime? check_in_from { get; set; }
        public DateTime? check_out_until { get; set; }

    }
}