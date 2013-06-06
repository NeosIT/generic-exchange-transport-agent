namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Runtime.Serialization;
    using Microsoft.Exchange.Data.Transport.Email;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl.Forms;

    [Export(typeof(IHandler))]
    [DataContract(Name = "ExtractAttachmentHandler", Namespace = "")]
    public class ExtractAttachmentHandler : FilterableHandlerBase, IExtractAttachmentHandler
    {
        public const string OutputPathKey = "OutputPath";
        private IDictionary<string, string> _settings = new Dictionary<string, string> { { OutputPathKey, "" }, };

        [DataMember]
        public IDictionary<string, string> Settings
        {
            get { return _settings; }
            internal set { _settings = value; }
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

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (AppliesTo(emailItem, lastExitCode))
            {
                if (null != emailItem &&
                null != emailItem.Message &&
                null != emailItem.Message.Attachments &&
                0 != emailItem.Message.Attachments.Count
                )
                {
                    string outputPath = GetSetting(OutputPathKey);

                    foreach (Attachment attachment in emailItem.Message.Attachments)
                    {
                        Stream contentStream;
                        if (attachment.TryGetContentReadStream(out contentStream))
                        {
                            this.Debug("[MessageId {0}] Extracting {1} to {2}...", emailItem.Message.MessageId, attachment.FileName, outputPath);
                            using (
                                var fs = new FileStream(Path.Combine(outputPath, attachment.FileName), FileMode.Create,
                                                        FileAccess.ReadWrite))
                            {
                                contentStream.CopyTo(fs);
                            }
                        }
                    }
                }

                if (null != Handlers && Handlers.Count > 0)
                {
                    foreach (IHandler handler in Handlers)
                    {
                        handler.Execute(emailItem, lastExitCode);
                    }
                }
            }
        }

        public override string Name
        {
            get { return "ExtractAttachmentHandler"; }
        }

        private string GetSetting(string key)
        {
            return _settings.ContainsKey(key) ? _settings[key] : string.Empty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
