using System;

namespace bknsystem.privateApi.Models
{
    public class booking_payment
    {
        public int id { get; set; }
        public string payment_method { get; set; }
        public string phone_number { get; set; }
        public decimal payment_amount { get; set; }
        public string payment_reference { get; set; }
        public DateTime? payment_date { get; set; }
        public string payment_made_by { get; set; }
        public string payment_status { get; set; }
    }
}