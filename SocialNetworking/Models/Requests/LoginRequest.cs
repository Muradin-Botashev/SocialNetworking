using System.ComponentModel.DataAnnotations;

namespace SocialNetworking.Models.Requests
{
    public class LoginRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}