using Microsoft.AspNetCore.Identity;

namespace webapi.Models;

public class AppUser : IdentityUser<int>
{

        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }        

         public string City { get; set; }

        public string Country { get; set; }

        public string Alergies { get; set; }

        public bool? MobilityDifficulties { get; set; }
        public string Profession { get; set; }
 
       // public ICollection<Photo> Photos { get; set; }
       public AppUserConfig config { get; set; }


        public ICollection<AppUserRole> UserRoles { get; set; }


}