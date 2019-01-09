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

        [DataMember(Name = "UploadFieldName")]
        public string UploadFieldName { get; set; }
        
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

                    if (attachments.Any())
                    {
                        var sb = new StringBuilder();

                        var recipients = emailItem.Message.To.ToList();
                        recipients.AddRange(emailItem.Message.Cc.ToList());
                        recipients.AddRange(emailItem.Message.Bcc.ToList());

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

                        foreach (var attachment in attachments)
                        {
                            var fileName = Path.GetFileName(attachment.FileName);
                            var webRequest = (HttpWebRequest)WebRequest.Create(Endpoint);


                            Logger.Debug(@"[MessageID {0}] Added header ""{1}"" with ""{2}""", emailItem.Message.MessageId, RecipientsHeader, sb.ToString());
                            webRequest.Headers.Add(RecipientsHeader, sb.ToString());
                            if (attachment.TryGetContentReadStream(out var stream))
                            {
                                Logger.Debug(@"[MessageID {0}] Uploading file ""{1}""", emailItem.Message.MessageId, fileName);
                                webRequest.UploadFile(stream, httpMethod, fileName, UploadFieldName);

                                var response = webRequest.GetResponse();
                                var responseStream = response.GetResponseStream();
                                Logger.Info("[MessageID {0}] Server response:", emailItem.Message.MessageId);
                                Logger.Info("[MessageID {0}] Headers:{1}{2}", emailItem.Message.MessageId, Environment.NewLine, response.Headers);
                                Logger.Info("[MessageID {0}] Body:{1}{2}", emailItem.Message.MessageId, Environment.NewLine, Encoding.Default.GetString(responseStream.ReadToEnd()));
                            }

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
                Logger.Fatal("No MailItem available...");
                return false;
            }

            if (
                !emailItem.Message.To.Any(
                    x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)))
            {
                Logger.Info("[MessageId {0}] ServiceMail not found in recipients...", emailItem.Message.MessageId);
                return false;
            }

            if (emailItem.Message.To.All(x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)) &&
                emailItem.Message.Cc.All(x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)) &&
                emailItem.Message.Bcc.All(x => x.SmtpAddress.Equals(ServiceMail, StringComparison.InvariantCultureIgnoreCase)))
            {
                Logger.Info("[MessageId {0}] No other recipients found...", emailItem.Message.MessageId);
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
