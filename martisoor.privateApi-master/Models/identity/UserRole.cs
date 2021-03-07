using Microsoft.AspNetCore.Identity;

namespace bknsystem.privateApi.Models.identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public Users User { get; set; }
        public Role Role { get; set; }
    }
}