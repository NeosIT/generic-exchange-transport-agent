using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents
{
    [DataContract(Name = "RoutingAgent", Namespace = "")]
    public class RoutingAgentConfig : IAgentConfig
    {
        [DataMember(Name = "OnCategorizedMessage")]
        public IList<IAgentEventHandler> OnCategorizedMessage { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnResolvedMessage")]
        public IList<IAgentEventHandler> OnResolvedMessage { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnRoutedMessage")]
        public IList<IAgentEventHandler> OnRoutedMessage { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnSubmittedMessage")]
        public IList<IAgentEventHandler> OnSubmittedMessage { get; set; } = new List<IAgentEventHandler>();
    }
}