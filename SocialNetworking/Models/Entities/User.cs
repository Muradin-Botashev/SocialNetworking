using Newtonsoft.Json;

namespace SocialNetworking.Models.Entities
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("second_name")]
        public string SecondName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("password_hash")]
        public string PasswordHash { get; set; }
    }
}