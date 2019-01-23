using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl
{
    [Export(typeof(IHandler))]
    [DataContract(Name = "ExtractAttachmentHandler", Namespace = "")]
    public class ExtractAttachmentHandler : FilterableHandlerBase, IExtractAttachmentHandler
    {
        public const string OutputPathKey = "OutputPath";

        [DataMember]
        public IDictionary<string, string> Settings { get; set; } = new Dictionary<string, string> { { OutputPathKey, "" }, };

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (!AppliesTo(emailItem, lastExitCode)) return;

            if (emailItem?.Message?.Attachments != null &&
                emailItem.Message.Attachments.Count != 0
            )
            {
                string outputPath = GetSetting(OutputPathKey);

                foreach (var attachment in emailItem.Message.Attachments)
                {
                    if (!attachment.TryGetContentReadStream(out var contentStream)) continue;

                    Logger.Debug("[GenericTransportAgent] Extracting {1} to {2}...", attachment.FileName, outputPath);
                    Directory.CreateDirectory(outputPath);
                    using (var fs = new FileStream(
                        Path.Combine(outputPath, attachment.FileName),
                        FileMode.Create,
                        FileAccess.ReadWrite))
                    {
                        contentStream.CopyTo(fs);
                    }
                }
            }

            if (null == Handlers || Handlers.Count <= 0) return;

            foreach (var handler in Handlers)
            {
                handler.Execute(emailItem, lastExitCode);
            }
        }

        public override string Name => "ExtractAttachmentHandler";

        private string GetSetting(string key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : string.Empty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
