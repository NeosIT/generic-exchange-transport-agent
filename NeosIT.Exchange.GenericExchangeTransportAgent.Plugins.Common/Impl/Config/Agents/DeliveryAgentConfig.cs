using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents
{
    [DataContract(Name = "DeliveryAgent", Namespace = "")]
    public class DeliveryAgentConfig : IAgentConfig
    {
        private IList<IAgentEventHandler> _onCloseConnection = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onDeliverMailItem = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onOpenConnection = new List<IAgentEventHandler>();

        [DataMember(Name = "OnCloseConnection")]
        public IList<IAgentEventHandler> OnCloseConnection
        {
            get { return _onCloseConnection; }
            set { _onCloseConnection = value; }
        }

        [DataMember(Name = "OnDeliverMailItem")]
        public IList<IAgentEventHandler> OnDeliverMailItem
        {
            get { return _onDeliverMailItem; }
            set { _onDeliverMailItem = value; }
        }

        [DataMember(Name = "OnOpenConnection")]
        public IList<IAgentEventHandler> OnOpenConnection
        {
            get { return _onOpenConnection; }
            set { _onOpenConnection = value; }
        }
    }
}