namespace webapi.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
       
       public bool HasPrivacyPolicyAccepted { get; set; }
    }
}