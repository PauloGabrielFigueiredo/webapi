namespace webapi.DTOs
{
    public class MemberUpdateDto
    {
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Alergies { get; set; }
        public string Profession { get; set; }

        public bool MobilityDifficulties {get; set;} 

        public bool HasPrivacyPolicyAccepted { get; set; }

    }
}