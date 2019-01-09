namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DkimSigningHandler.Impl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Runtime.Serialization;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;

    [Export(typeof(IHandler))]
    [DataContract(Name = "DkimSigningHandler", Namespace = "")]
    public class DkimSigningHandler : FilterableHandlerBase, IDkimSigningHandler
    {
        [DataMember]
        public DkimAlgorithmKind Algorithm { get; set; } = DkimAlgorithmKind.RsaSha1;

        [DataMember]
        public string Selector { get; internal set; }

        [DataMember]
        public string Domain { get; internal set; }

        [DataMember]
        public IList<string> HeadersToSign { get; internal set; }

        [DataMember]
        public string EncodedKey { get; internal set; }
        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (AppliesTo(emailItem, lastExitCode))
            {
                if (null != emailItem && !emailItem.Message.IsSystemMessage && null == emailItem.Message.TnefPart)
                {
                    using (var dkimSigner = new DefaultDkimSigner(Algorithm, HeadersToSign, Selector, Domain, EncodedKey))
                    {
                        using (var inputStream = emailItem.MimeReadStream)
                        {
                            if (dkimSigner.CanSign(inputStream))
                            {
                                using (var outputStream = emailItem.GetMimeWriteStream())
                                {
                                    dkimSigner.Sign(inputStream, outputStream);
                                }
                            }
                        }
                    }
                }

                if (null != Handlers && Handlers.Count > 0)
                {
                    foreach (var handler in Handlers)
                    {
                        handler.Execute(emailItem, lastExitCode);
                    }
                }
            }
        }

        public override string Name => "DkimSigningHandler";

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
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
