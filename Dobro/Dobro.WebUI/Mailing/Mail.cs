namespace Dobro.WebUI.Mailing
{
    public class Mail
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public Mail(string subject, string body)
        {
            this.Subject = subject;
            this.Body = body;
        }
    }
}