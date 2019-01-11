using System;
using System.IO;
using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Email;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    public sealed class EmailItem : IEmailItem
    {
        private readonly object _underlyingObject;

        private EmailItem(object underlyingObject, EmailMessage message, RoutingAddress fromAddress,
                          Stream mimeReadStream)
        {
            _underlyingObject = underlyingObject;
            Message = message;
            FromAddress = fromAddress;
            MimeReadStream = mimeReadStream;
        }

        public EmailItem(MailItem mailItem)
            : this(mailItem, mailItem.Message, mailItem.FromAddress, mailItem.GetMimeReadStream())
        {
        }

        public EmailItem(DeliverableMailItem mailItem)
            : this(mailItem, mailItem.Message, mailItem.FromAddress, mailItem.GetMimeReadStream())
        {
        }

        public EmailItem(EmailMessage emailMessage) : this (emailMessage, emailMessage, new RoutingAddress(emailMessage.From.SmtpAddress), null)
        {
        }

        #region IEmailItem Members

        public EmailMessage Message { get; internal set; }
        public RoutingAddress FromAddress { get; internal set; }
        public Stream MimeReadStream { get; internal set; }
        public bool IsExported { get; internal set; }
        public bool IsImported { get; internal set; }
        public bool ShouldBeDeletedFromQueue { get; set; }

        public Stream GetMimeWriteStream()
        {
            var underlyingObject = _underlyingObject as MailItem;
            return underlyingObject != null ? underlyingObject.GetMimeWriteStream() : null;
        }

        public object GetUnderlyingObject()
        {
            return _underlyingObject;
        }

        public void Save(string filename)
        {
            if (null != MimeReadStream)
            {
                using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                {
                    MimeReadStream.CopyTo(fs);
                    IsExported = true;
                }
            }
        }

        public void Load(string filename)
        {
            if (File.Exists(filename))
            {
                var writeStream = GetMimeWriteStream();

                if (null != writeStream)
                {
                    using (writeStream)
                    {
                        using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                        {
                            fs.CopyTo(writeStream);
                            IsImported = true;
                        }
                    }
                }
            }
        }

        #endregion
    }
}