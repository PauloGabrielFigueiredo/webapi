using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }


        public string email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        public string? Alergies { get; set; }

        public bool? MobilityDifficulties { get; set; }
        public string? Profession { get; set; }
 
    }
}