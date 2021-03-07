using System;

namespace bknsystem.privateApi.Models.logs
{
    public class UserEventLogs
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LoggedInTime { get; set; }
        public string LoggedInStatus { get; set; }
        public string UserCountry { get; set; }
        public string UserAgent { get; set; }
        public string UserBranch { get; set; }
        public string UserIpAddress { get; set; }
        public string UserType { get; set; }
    }
}