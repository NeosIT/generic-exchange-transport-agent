using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config.Agents;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config
{
    [DataContract(Name = "GenericTransportAgent", Namespace = "")]
    public class TransportAgentConfig
    {
        [DataMember(Name = "DeliveryAgent")]
        public DeliveryAgentConfig DeliveryAgentConfig { get; set; } = new DeliveryAgentConfig();

        [DataMember(Name = "RoutingAgent")]
        public RoutingAgentConfig RoutingAgentConfig { get; set; } = new RoutingAgentConfig();

        [DataMember(Name = "SmtpReceiveAgent")]
        public SmtpReceiveAgentConfig SmtpReceiveAgentConfig { get; set; } = new SmtpReceiveAgentConfig();
    }
}