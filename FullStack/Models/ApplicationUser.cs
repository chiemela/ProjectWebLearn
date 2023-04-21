using Microsoft.AspNetCore.Identity;


namespace FullStack.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        // public string Phone { get; set; }
    }
}
