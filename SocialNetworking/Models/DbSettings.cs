namespace SocialNetworking.Models
{
    public class DbSettings
    {
        public string ASPNETCORE_ENVIRONMENT { get; set; }
        public string DB_ENDPOINT { get; set; }
        public string DB_NAME { get; set; }
        public string DB_USERNAME { get; set; }
        public string DB_PASSWORD { get; set; }
        public int DB_PORT { get; set; }
    }
}