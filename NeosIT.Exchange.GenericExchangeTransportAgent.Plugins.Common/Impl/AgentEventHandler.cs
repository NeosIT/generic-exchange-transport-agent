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
        public string Name => "EventHandler";

        [DataMember]
        public IList<IHandler> Handlers { get; set; } = new List<IHandler>();

        [DataMember]
        public IList<IFilterable> Filters { get; set; } = new List<IFilterable>();

        #region IAgentEventHandler Members

        public void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            Logger.Debug("[GenericTransportAgent] AgentEventHandler - Execute called...");
            if (!AppliesTo(emailItem)) return;

            Logger.Debug("[GenericTransportAgent] AgentEventHandler - Calling execute on handlers...");
            Handlers.ToList().ForEach(x => x.Execute(emailItem));
        }

        public bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Warn("[GenericTransportAgent] AgentEventHandler - No MailItem available...");
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