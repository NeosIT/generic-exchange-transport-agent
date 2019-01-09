﻿using System;
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
        bool IsExported { get; }
        bool IsImported { get; }
        Stream GetMimeWriteStream();
        object GetUnderlyingObject();
        void Save(string filename);
        void Load(string filename);
        bool ShouldBeDeletedFromQueue { get; set; }
    }
}
