using System;
using System.IO;
using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Email;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common
{
    public interface IEmailItem
    {
        EmailMessage Message { get; }
        RoutingAddress FromAddress { get; }
        Stream MimeReadStream { get; }
        Boolean IsExported { get; }
        Boolean IsImported { get; }
        Stream GetMimeWriteStream();
        Object GetUnderlyingObject();
        void Save(string filename);
        void Load(string filename);
        Boolean ShouldBeDeletedFromQueue { get; set; }
    }
}
