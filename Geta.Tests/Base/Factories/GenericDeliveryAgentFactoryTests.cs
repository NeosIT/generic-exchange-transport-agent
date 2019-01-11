using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Delivery;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Factories;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Base.Factories
{
    [TestFixture]
    public class GenericDeliveryAgentFactoryTests : FactoryTestBase<GenericDeliveryAgentFactory<TestDeliveryAgentManager>>
    {
        [Test]
        public void CreateAgentTest()
        {
            var agent = TestObject.CreateAgent(null);
            
            Assert.NotNull(agent);
            Assert.IsInstanceOf<Agent>(agent);
            Assert.IsInstanceOf<DeliveryAgent>(agent);
            Assert.IsInstanceOf<GenericDeliveryAgent>(agent);
        }
    }
}
