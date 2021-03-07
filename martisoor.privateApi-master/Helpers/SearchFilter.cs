namespace bknsystem.privateApi.Helpers
{
    public class SearchFilter
    {
        public SortParams searchParams { get; set; }
        public FilterParams filterParams { get; set; }


        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;

        public int PageSize
        {

            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}