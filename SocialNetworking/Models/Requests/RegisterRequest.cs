using System.ComponentModel.DataAnnotations;

namespace SocialNetworking.Models.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string second_name { get; set; }

        [Required]
        public string password { get; set; }
        public string biography { get; set; }
        public string city { get; set; }
        public int age { get; set; }
        public DateTime birthdate { get; set; }
    }
}