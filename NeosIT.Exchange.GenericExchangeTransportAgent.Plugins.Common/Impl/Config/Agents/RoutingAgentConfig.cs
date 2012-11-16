using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents
{
    [DataContract(Name = "RoutingAgent", Namespace = "")]
    public class RoutingAgentConfig : IAgentConfig
    {
        private IList<IAgentEventHandler> _onCategorizedMessage = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onResolvedMessage = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onRoutedMessage = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onSubmittedMessage = new List<IAgentEventHandler>();

        [DataMember(Name = "OnCategorizedMessage")]
        public IList<IAgentEventHandler> OnCategorizedMessage
        {
            get { return _onCategorizedMessage; }
            set { _onCategorizedMessage = value; }
        }

        [DataMember(Name = "OnResolvedMessage")]
        public IList<IAgentEventHandler> OnResolvedMessage
        {
            get { return _onResolvedMessage; }
            set { _onResolvedMessage = value; }
        }

        [DataMember(Name = "OnRoutedMessage")]
        public IList<IAgentEventHandler> OnRoutedMessage
        {
            get { return _onRoutedMessage; }
            set { _onRoutedMessage = value; }
        }

        [DataMember(Name = "OnSubmittedMessage")]
        public IList<IAgentEventHandler> OnSubmittedMessage
        {
            get { return _onSubmittedMessage; }
            set { _onSubmittedMessage = value; }
        }
    }
}