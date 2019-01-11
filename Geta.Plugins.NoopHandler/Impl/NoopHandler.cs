using System;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.NoopHandler.Impl
{
    [Export(typeof(IHandler))]
    [DataContract(Name = "NoopHandler", Namespace = "")]
    public class NoopHandler : FilterableHandlerBase, INoopHandler
    {
        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (null == emailItem) return;
            if (null == Handlers || Handlers.Count <= 0) return;

            foreach (var handler in Handlers)
            {
                handler.Execute(emailItem, lastExitCode);
            }
        }

        public override string Name => "NoopHandler";

        public override string ToString()
        {
            return Name;
        }
    }
}
