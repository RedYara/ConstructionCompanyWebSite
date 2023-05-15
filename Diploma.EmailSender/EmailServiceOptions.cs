namespace Diploma.EmailSender
{
    public class EmailServiceOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string SenderLogin { get; set; }
        public string SenderPassword { get; set; }
    }
}