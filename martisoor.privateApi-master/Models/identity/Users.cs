using System;
using Microsoft.AspNetCore.Identity;

namespace bknsystem.privateApi.Models.identity
{
    public class Users : IdentityUser
    {
        public DateTime birth_date { get; set; }
        public string last_name { get; set; }
    }
}