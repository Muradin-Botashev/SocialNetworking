using System.ComponentModel.DataAnnotations;

namespace SocialNetworking.Models.Requests
{
    public class GetUserRequest
    {
        [Required]
        public int id { get; set; }
    }
}