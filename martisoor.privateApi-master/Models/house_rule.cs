namespace bknsystem.privateApi.Models
{
    public class house_rule
    {
        public int id { get; set; }
        public check_in_check_out check_in_check_outs { get; set; }
        public extras extras { get; set; }
        public getting_around getting_around { get; set; }
        public property_detail property_details { get; set; }

        public string hotel_id { get; set; }

    }
}