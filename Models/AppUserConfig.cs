using System.Collections.Generic;

namespace webapi.Models
{
    public class AppUserConfig
    {
       public int id { get; set; }
       public AppUser user { get; set; }
       public int pagesize { get; set; }

        public int user_id { get; set; }
    }
}