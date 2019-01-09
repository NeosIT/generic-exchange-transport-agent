namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    using System.IO;
    using Microsoft.Exchange.Data.Transport.Email;

    public static class EmailMessageHelper
    {
        public static EmailMessage CreateHtmlEmailMessage(string subject, string body)
        {
            return FillEmailMessage(EmailMessage.Create(BodyFormat.Html), subject, body);
        }

        public static EmailMessage CreateRtfEmailMessage(string subject, string body)
        {
            return FillEmailMessage(EmailMessage.Create(BodyFormat.Rtf), subject, body);
        }

        public static EmailMessage CreateTextEmailMessage(string subject, string body)
        {
            return FillEmailMessage(EmailMessage.Create(BodyFormat.Text), subject, body);
        }

        private static EmailMessage FillEmailMessage(EmailMessage emailMessage, string subject, string body)
        {
            emailMessage.From = new EmailRecipient("Alice", "alice@neos-it.de");
            emailMessage.To.Add(new EmailRecipient("Bob", "bob@neos-it.de"));
            emailMessage.Subject = subject;

            using (var stream = emailMessage.Body.GetContentWriteStream())
            {
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(body);
                }
            }

            return emailMessage;
        }
    }
}
