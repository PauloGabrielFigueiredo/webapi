using System;
using System.Collections.Generic;

namespace webapi.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        

    //     public ICollection<PhotoDto> Photos { get; set; }

    }
}