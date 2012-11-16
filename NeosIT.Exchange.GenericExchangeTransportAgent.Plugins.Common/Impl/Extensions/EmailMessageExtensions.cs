using System.IO;
using System.Text;
using Microsoft.Exchange.Data.Transport.Email;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions
{
    public static class EmailMessageExtensions
    {
        public static string GetBody(this EmailMessage message)
        {
            var charsetName = message.Body.CharsetName;

            using (var reader = new StreamReader(message.Body.GetContentReadStream(), Encoding.GetEncoding(charsetName)))
            {
                return reader.ReadToEnd();
            }
        }

        public static void SetBody(this EmailMessage message, string bodyText)
        {
            var charsetName = message.Body.CharsetName;

            using (var writeStream = message.Body.GetContentWriteStream(charsetName))
            {
                var buffer = Encoding.GetEncoding(charsetName).GetBytes(bodyText);
                writeStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
