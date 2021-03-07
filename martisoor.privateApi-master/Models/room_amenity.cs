using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bknsystem.privateApi.Models
{
    public class room_amenity
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
        public string room_id { get; set; }
    }
}
