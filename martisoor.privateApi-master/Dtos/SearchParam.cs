using System;

namespace martisoor.privateApi_master.Dtos
{
    public class SearchParam
    {
        public string hotelName { get; set; }
        public string destination { get; set; }
      
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 50;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

      
        public DateTime To { get; set; }

        public string Orderby { get; set; } = "Created";
    }
}