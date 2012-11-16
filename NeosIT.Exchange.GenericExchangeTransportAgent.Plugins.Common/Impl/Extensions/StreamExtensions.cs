using System.IO;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions
{
    public static class StreamExtensions
    {
        public static void CopyTo(this Stream input, Stream output)
        {
            input.Position = 0;
            var buffer = new byte[4096];
            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}
