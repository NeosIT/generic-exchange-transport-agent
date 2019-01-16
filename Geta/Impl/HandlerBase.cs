using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl
{
    [DataContract(Namespace = "")]
    public abstract class HandlerBase : LoggingBase, IHandler
    {
        [DataMember]
        public IList<IHandler> Handlers { get; set; } = new List<IHandler>();

        public abstract string Name { get; }
        public abstract void Execute(IEmailItem emailItem = null, int? lastExitCode = null);
    }
}
