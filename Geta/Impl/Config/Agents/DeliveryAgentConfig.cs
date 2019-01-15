using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config.Agents
{
    [DataContract(Name = "DeliveryAgent", Namespace = "")]
    public class DeliveryAgentConfig : IAgentConfig
    {
        [DataMember(Name = "OnCloseConnection")]
        public IList<IHandler> OnCloseConnection { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnDeliverMailItem")]
        public IList<IHandler> OnDeliverMailItem { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnOpenConnection")]
        public IList<IHandler> OnOpenConnection { get; set; } = new List<IHandler>();
    }
}