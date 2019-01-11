using System;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using System.Text;
using HtmlAgilityPack;
using Microsoft.Exchange.Data.Transport.Email;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DisclaimerHandler.Impl.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DisclaimerHandler.Impl
{
    [Export(typeof(IHandler))]
    [DataContract(Name = "DisclaimerHandler", Namespace = "")]
    public class DisclaimerHandler : FilterableHandlerBase, IDisclaimerHandler
    {
        [DataMember(Name = "Text")]
        public string Text { get; set; }

        [DataMember(Name = "Rtf")]
        public string Rtf { get; set; }

        [DataMember(Name = "Html")]
        public string Html { get; set; }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (!AppliesTo(emailItem, lastExitCode)) return;

            // AppliesTo() will return false, if emailItem is null.
            // ReSharper disable once PossibleNullReferenceException
            if (BodyFormat.Text == emailItem.Message.Body.BodyFormat)
            {
                var sb = new StringBuilder();
                sb.Append(emailItem.Message.GetBody());
                sb.AppendLine();
                sb.AppendLine();
                sb.Append(Text);
                emailItem.Message.SetBody(sb.ToString());
            }

            if (BodyFormat.Rtf == emailItem.Message.Body.BodyFormat)
            {
                var messageRtf = new RtfDocument(emailItem.Message.GetBody());
                var mergeRtf = new RtfDocument(Rtf);

                if (messageRtf.Merge(mergeRtf))
                {
                    emailItem.Message.SetBody(messageRtf.Content);
                }
            }

            if (BodyFormat.Html == emailItem.Message.Body.BodyFormat)
            {
                var messageDoc = new HtmlDocument();
                messageDoc.LoadHtml(emailItem.Message.GetBody());

                var disclaimerDoc = new HtmlDocument();
                disclaimerDoc.LoadHtml(Html);

                var messageBodyNode = messageDoc.DocumentNode.SelectSingleNode("//body");
                var disclaimerBodyNode = disclaimerDoc.DocumentNode.SelectSingleNode("//body");

                var brNode = messageDoc.CreateElement("br");

                messageBodyNode.AppendChild(brNode);

                messageBodyNode.AppendChildren(disclaimerBodyNode.ChildNodes);

                emailItem.Message.SetBody(messageDoc.DocumentNode.InnerHtml);
            }

            if (null == Handlers || Handlers.Count <= 0) return;

            foreach (var handler in Handlers)
            {
                handler.Execute(emailItem, lastExitCode);
            }
        }

        public override string Name => "DisclaimerHandler";

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
