using Microsoft.AspNetCore.Identity;

namespace Identity.Data.Models
{
    public class Manager:IdentityUser
    {
        public string Department { get; set; } = string.Empty;

    }
}
