using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config
{
    [DataContract(Name = "GenericTransportAgent", Namespace = "")]
    public class TransportAgentConfig
    {
        private DeliveryAgentConfig _deliveryAgentConfig = new DeliveryAgentConfig();
        private RoutingAgentConfig _routingAgentConfig = new RoutingAgentConfig();
        private SmtpReceiveAgentConfig _smtpReceiveAgentConfig = new SmtpReceiveAgentConfig();

        [DataMember(Name = "DeliveryAgent")]
        public DeliveryAgentConfig DeliveryAgentConfig
        {
            get { return _deliveryAgentConfig; }
            set { _deliveryAgentConfig = value; }
        }

        [DataMember(Name = "RoutingAgent")]
        public RoutingAgentConfig RoutingAgentConfig
        {
            get { return _routingAgentConfig; }
            set { _routingAgentConfig = value; }
        }

        [DataMember(Name = "SmtpReceiveAgent")]
        public SmtpReceiveAgentConfig SmtpReceiveAgentConfig
        {
            get { return _smtpReceiveAgentConfig; }
            set { _smtpReceiveAgentConfig = value; }
        }
    }
}