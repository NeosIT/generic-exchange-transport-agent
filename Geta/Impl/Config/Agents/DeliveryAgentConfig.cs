using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config.Agents
{
    [DataContract(Name = "DeliveryAgent", Namespace = "")]
    public class DeliveryAgentConfig : IAgentConfig
    {
        [DataMember(Name = "OnCloseConnection")]
        public IList<IAgentEventHandler> OnCloseConnection { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnDeliverMailItem")]
        public IList<IAgentEventHandler> OnDeliverMailItem { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnOpenConnection")]
        public IList<IAgentEventHandler> OnOpenConnection { get; set; } = new List<IAgentEventHandler>();
    }
}