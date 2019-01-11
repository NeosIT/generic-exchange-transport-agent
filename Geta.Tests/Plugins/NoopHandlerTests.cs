using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.NoopHandler.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins
{
    [TestFixture]
    public class NoopHandlerHandlerTests : HandlerTestBase<NoopHandler>
    {
        [SetUp]
        public void TestFixtureSetUp()
        {
            Name = "NoopHandler";
        }

        [Test]
        public void AppliesToTest()
        {
            var emailMessage = EmailMessageHelper.CreateHtmlEmailMessage("NoopHandlerAppliesToTest Subject",
                                                                         "NoopHandlerAppliesToTest Body");

            PrepareLogger();
            Assert.IsTrue(TestObject.AppliesTo(new EmailItem(emailMessage)));
        }

        [Test]
        public void ExecuteTest()
        {
            var emailMessage = EmailMessageHelper.CreateHtmlEmailMessage("NoopHandlerExecuteTest Subject",
                                                                         "NoopHandlerExecuteTest Body");

            PrepareLogger();
            TestObject.Execute(new EmailItem(emailMessage));
        }
    }
}
