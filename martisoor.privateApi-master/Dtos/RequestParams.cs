using System.Collections.Generic;

namespace bknsystem.privateApi.Dtos
{
    public class RequestParams
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public string[] Q { get; set; } = System.Array.Empty<string>();

        public List<Filter> GetFilters()
        {
            var filters = new List<Filter>(Q.Length);
            foreach (var q in Q)
            {
                var parts = q.Split('=');
                var filter = new Filter
                {
                    Field = parts[0],
                    Value = parts.Length > 1 ? parts[1] : null
                };

                filters.Add(filter);
            }

            return filters;
        }
    }

    public class Filter
    {
        public string Field { get; set; }

        public object Value { get; set; }
    }
}