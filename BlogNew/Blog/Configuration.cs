namespace Blog
{
    public static class Configuration
    {

        public static string JwtKey = "Z7Z5a2711A77f495TT7888473744098v007cv9387x2776a78134";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_api_Z7Z5a2##577)f49&5TT7888473744098v007cv9387x2776a78134==";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 587;
            public string UserName { get; set; }
            public string Password { get; set; }
        }

    }
}

