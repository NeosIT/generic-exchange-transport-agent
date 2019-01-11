using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class TwitterNotificationHandlerHandlerTests : OptionsHandlerTestBase<TwitterNotificationHandler>
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Name = "TwitterNotificationHandler";
        }
    }
}
