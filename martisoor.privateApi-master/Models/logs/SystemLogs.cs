using System;

namespace bknsystem.privateApi.Models.logs
{
    public class SystemLogs
    {
        public int Id { get; set; }
        public string ErrorType { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
    }
}