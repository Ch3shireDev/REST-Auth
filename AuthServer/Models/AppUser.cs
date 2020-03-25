using Microsoft.AspNetCore.Identity;

namespace AuthServer.Models
{
    public class AppUser : IdentityUser
    {
        //public string Username { get; set; }
        //public string Password { get; set; }
        public string Password { get; set; }
    }
}