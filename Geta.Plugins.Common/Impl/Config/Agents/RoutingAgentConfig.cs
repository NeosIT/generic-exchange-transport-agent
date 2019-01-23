using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents
{
    [DataContract(Name = "RoutingAgent", Namespace = "")]
    public class RoutingAgentConfig : IAgentConfig
    {
        [DataMember(Name = "OnCategorizedMessage")]
        public IList<IHandler> OnCategorizedMessage { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnResolvedMessage")]
        public IList<IHandler> OnResolvedMessage { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnRoutedMessage")]
        public IList<IHandler> OnRoutedMessage { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnSubmittedMessage")]
        public IList<IHandler> OnSubmittedMessage { get; set; } = new List<IHandler>();
    }
}