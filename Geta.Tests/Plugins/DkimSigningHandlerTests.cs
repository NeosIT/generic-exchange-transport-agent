using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DkimSigningHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    public class DkimSigningHandlerHandlerTests : OptionsHandlerTestBase<DkimSigningHandler>
    {
        [SetUp]
        public void TestFixtureSetUp()
        {
            Name = "DkimSigningHandler";
        }
    }
}
