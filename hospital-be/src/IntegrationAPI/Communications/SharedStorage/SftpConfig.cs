namespace IntegrationAPI.Communications.SharedStorage
{
    public class SftpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public SftpConfig()
        {
            Host = "localhost";
            Port = 22;
            Username = "psw";
            Password = "psw";
        }
    }
}