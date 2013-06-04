using System.Text;
using Microsoft.Exchange.Data.Transport;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.MailEndpointHandler.Impl.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.MailEndpointHandler.Impl
{
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;

    [Export(typeof(IHandler))]
    [DataContract(Name = "MailEndpointHandler", Namespace="")]
    public class MailEndpointHandler : FilterableHandlerBase, IMailEndpointHandler
    {
        [DataMember(Name = "Endpoint")]
        public string Endpoint { get; set; }

        [DataMember(Name = "ServiceMail")]
        public string ServiceMail { get; set; }

        [DataMember(Name = "HttpMethod")]
        public HttpMethod HttpMethod { get; set; }

        [DataMember(Name = "MailContent")]
        public MailContent MailContent { get; set; }

        [DataMember(Name = "AttachmentFileExtensions")]
        public string AttachmentFileExtensions { get; set; }

        [DataMember(Name = "RecipientsHeader")]
        public string RecipientsHeader { get; set; }

        [DataMember(Name = "DropMailAfterProcessing")]
        public bool DropMailAfterProcessing { get; set; }
        
        public override string Name
        {
            get { return "MailEndpointHandler"; }
        }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (AppliesTo(emailItem, lastExitCode))
            {
                var rcpts =
                    emailItem.Message.To.Where(
                        x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)).ToList();

                var httpMethod = HttpMethod.ToString();

                foreach (var rcpt in rcpts)
                {
                    emailItem.Message.To.Remove(rcpt);
                }

                if (MailContent.Attachments == MailContent)
                {
                    var attachments = emailItem.Message.Attachments.ToList();
                    
                    if (!string.IsNullOrEmpty(AttachmentFileExtensions))
                    {
                        var includedFileExts = AttachmentFileExtensions.Split(new[] { ';', });
                        attachments = attachments.Where(c => includedFileExts.Any(i => c.FileName.EndsWith(i))).ToList();
                    }



                    foreach (var attachment in attachments)
                    {
                        var fileName = Path.GetFileName(attachment.FileName);
                        var webRequest = WebRequest.Create(Endpoint);

                        var sb = new StringBuilder();
                        /*var mailItem = emailItem.GetUnderlyingObject() as MailItem;

                        if (null != mailItem)
                        {
                            var recipients = mailItem.Recipients.Where(x => !ServiceMail.Equals(x.Address.ToString(), StringComparison.InvariantCultureIgnoreCase));

                            foreach (var rcpt in recipients)
                            {
                                sb.Append(rcpt.Address.ToString() + ";");
                            }
                        }*/

                        var recipients = emailItem.Message.To.ToList();
                        rcpts.AddRange(emailItem.Message.Cc);
                        rcpts.AddRange(emailItem.Message.Bcc);

                        if (!string.IsNullOrEmpty(ServiceMail))
                        {
                            recipients =
                            recipients.Where(
                                x => !ServiceMail.Equals(x.SmtpAddress, StringComparison.InvariantCultureIgnoreCase))
                                      .Distinct()
                                      .ToList();
                        }
                        
                        foreach (var rcpt in recipients)
                        {
                            sb.Append(rcpt.SmtpAddress + ";");
                        }


                        webRequest.Headers.Add(RecipientsHeader, sb.ToString());
                        Stream stream;
                        if (attachment.TryGetContentReadStream(out stream))
                        {
                            webRequest.UploadFile(stream, httpMethod, fileName, attachment.ContentType, "file");

                            var response = webRequest.GetResponse();
                            var responseStream = response.GetResponseStream();
                            Logger.Info("[GenericTransportAgent] [MessageID {0}] Response from server: {1}...", emailItem.Message.MessageId, Encoding.Default.GetString(responseStream.ReadToEnd()));
                        }
                        
                    }
                }
                

                if (DropMailAfterProcessing)
                {
                    emailItem.ShouldBeDeletedFromQueue = true;
                }
            }
        }

        public override bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Fatal("[GenericTransportAgent] MailEndpointHandler - No MailItem available...");
                return false;
            }

            if (
                !emailItem.Message.To.Any(
                    x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)))
            {
                Logger.Info("[GenericTransportAgent] MailEndpointHandler - ServiceMail not found in recipients...");
                return false;
            }

            if (
                !emailItem.Message.To.Any(
                    x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)))
            {
                emailItem.ShouldBeDeletedFromQueue = true;
                return false;
            }

            return base.AppliesTo(emailItem, lastExitCode);
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ShowConfigDialog()
        {
            var configForm = new ConfigForm(this);
            configForm.ShowDialog();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
