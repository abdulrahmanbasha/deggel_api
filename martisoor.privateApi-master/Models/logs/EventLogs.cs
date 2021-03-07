using System;

namespace bknsystem.privateApi.Models.logs
{
    public class EventLogs
    {
        public int Id { get; set; }
        public DateTime Dated { get; set; }
        public DateTime Time { get; set; }
        public string SerialCode { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public string EventType { get; set; }
}
}