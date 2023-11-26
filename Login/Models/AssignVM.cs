using Microsoft.AspNetCore.Identity;

namespace Login.Models
{
    public class AssignVM
    {
        public IdentityUser User   { get;set; }
        public IdentityRole Role { get; set; }
    }
}
