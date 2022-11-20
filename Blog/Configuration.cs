namespace Blog;

public static class Configuration
{
    public static string JwtKey = "mRm1IWV3PkawdgBiVz6dsw==";
    public static string ApiKeyName = "api_key";
    public static string ApiKey = "curso_api_mRm1IWV3Pk==awdgBiVz6dsw";
    public static SmtpConfiguration Smtp = new();

    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; } = 25;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}