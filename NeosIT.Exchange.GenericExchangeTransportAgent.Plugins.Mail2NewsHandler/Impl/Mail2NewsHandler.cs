namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Mail2NewsHandler.Impl
{
    using System;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using Microsoft.Exchange.Data.Mime;
    using Microsoft.Exchange.Data.Transport;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Mail2NewsHandler.Impl.Forms;

    [Export(typeof(IHandler))]
    [DataContract(Name = "Mail2NewsHandler", Namespace = "")]
    public class Mail2NewsHandler: FilterableHandlerBase, IMail2NewsHandler
    {
        [DataMember]
        public string ToSmtpAddress { get; set; }

        [DataMember]
        public string HeaderKey { get; set; }

        public override string Name
        {
            get { return "Mail2NewsHandler"; }
        }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (AppliesTo(emailItem, lastExitCode))
            {
                var sb = new StringBuilder();
                var mailItem = emailItem.GetUnderlyingObject() as MailItem;

                if (null != mailItem)
                {
                    var rcptsToRemove = mailItem.Recipients.Where(x => !ToSmtpAddress.Equals(x.Address.ToString(), StringComparison.InvariantCultureIgnoreCase));

                    foreach (var rcpt in rcptsToRemove)
                    {
                        Logger.Info("[GenericTransportAgent] [MessageID {0}] Removing {1} from CC...", emailItem.Message.MessageId, rcpt.Address.ToString());
                        sb.Append(rcpt.Address.ToString() + ";");
                        mailItem.Recipients.Remove(rcpt);
                    }
                }

                Logger.Info("[GenericTransportAgent] [MessageID {0}] Share-With: {1}...", emailItem.Message.MessageId, sb.ToString());

                var header = new TextHeader(HeaderKey, sb.ToString());
                emailItem.Message.RootPart.Headers.AppendChild(header);
            }
        }

        public override bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Fatal("[GenericTransportAgent] {0} - No MailItem available...", Name);
                return false;
            }

            if (string.IsNullOrEmpty(ToSmtpAddress) || string.IsNullOrEmpty(HeaderKey))
            {
                Logger.Info(@"[GenericTransportAgent] {0} - ToSmtpAddress ""{1}"" or HeaderKey ""{2}"" ...", Name, ToSmtpAddress, HeaderKey);
                return false;
            }

            if (
                !emailItem.Message.To.Any(
                    x => x.SmtpAddress.Equals(ToSmtpAddress, StringComparison.InvariantCultureIgnoreCase)))
            {
                Logger.Info("[GenericTransportAgent] {0} - ToSmtpAddress not found in recipients...", Name);
                return false;
            }
            
            return base.AppliesTo(emailItem, lastExitCode);
        }

        public void Load()
        {
        }

        public void Save()
        {
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
