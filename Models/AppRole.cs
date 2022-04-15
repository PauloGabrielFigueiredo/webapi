using Microsoft.AspNetCore.Identity;

namespace webapi.Models
{
    public class AppRole : IdentityRole<int>
    {
       public ICollection<AppUserRole> UsersRoles { get; set; }
    }
}