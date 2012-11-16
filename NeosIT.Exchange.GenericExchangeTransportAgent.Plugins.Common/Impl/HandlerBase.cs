namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "")]
    public abstract class HandlerBase : LoggingBase, IHandler
    {
        private IList<IHandler> _handlers = new List<IHandler>();

        [DataMember]
        public IList<IHandler> Handlers
        {
            get { return _handlers; }
            set { _handlers = value; }
        }

        public abstract string Name { get; }
        public abstract void Execute(IEmailItem emailItem = null, int? lastExitCode = null);
    }
}
