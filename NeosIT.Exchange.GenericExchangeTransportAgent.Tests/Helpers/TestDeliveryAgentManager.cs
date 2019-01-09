using Microsoft.Exchange.Data.Transport.Delivery;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    public class TestDeliveryAgentManager : DeliveryAgentManager
    {
        public override string SupportedDeliveryProtocol => "local";
    }
}
