using Microsoft.AspNetCore.Identity;

namespace DotNetAuthApp.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
