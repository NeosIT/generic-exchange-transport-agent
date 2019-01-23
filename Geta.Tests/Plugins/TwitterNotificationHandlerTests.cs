using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class TwitterNotificationHandlerHandlerTests : HandlerTestBase<TwitterNotificationHandler>
    {
        [SetUp]
        public void TestFixtureSetUp()
        {
            Name = "TwitterNotificationHandler";
        }
    }
}
