namespace IntegrationAPI.Communications.SharedStorage
{
    public class SftpConfig
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public SftpConfig()
        {
            Host = "localhost";
            Port = "8880";
            Username = "psw";
            Password = "psw4";
        }
    }
}