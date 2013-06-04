namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Runtime.Serialization;

    [Export(typeof(IFilterable))]
    [DataContract(Name = "EventHandler", Namespace = "")]
    public class AgentEventHandler : LoggingBase, IAgentEventHandler
    {
        public string Name { get { return "EventHandler"; } }

        private IList<IFilterable> _filters = new List<IFilterable>();
        private IList<IHandler> _handlers = new List<IHandler>();

        [DataMember]
        public IList<IHandler> Handlers
        {
            get { return _handlers; }
            set { _handlers = value; }
        }

        [DataMember]
        public IList<IFilterable> Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }

        #region IAgentEventHandler Members

        public void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            Logger.Info("[GenericTransportAgent] AgentEventHandler - Execute called...");
            if (AppliesTo(emailItem))
            {
                Logger.Info("[GenericTransportAgent] AgentEventHandler - Calling execute on handlers...");
                Handlers.ToList().ForEach(x => x.Execute(emailItem));
            }
        }

        public bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Fatal("[GenericTransportAgent] AgentEventHandler - No MailItem available...");
                return false;
            }

            if (null == Filters || 0 == Filters.Count)
            {
                Logger.Warn("[GenericTransportAgent] [MessageID {0}] AgentEventHandler - No filters defined, applying...", emailItem.Message.MessageId);
                return true;
            }

            Logger.Info("[GenericTransportAgent] [MessageID {0}] AgentEventHandler - Applying filters...", emailItem.Message.MessageId);
            return Filters.Aggregate(false, (current, filter) => current || filter.AppliesTo(emailItem, lastExitCode));
        }

        public void Dispose()
        {
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}