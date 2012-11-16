using System.Linq;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins.Common.Config
{
    [TestFixture]
    public class TransportAgentConfigTests
    {
        private TransportAgentConfig TestObject { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestObject = new TransportAgentConfig();
        }

        [Test]
        public void AssertNotNullTest()
        {
            Assert.NotNull(TestObject);
        }

        [Test]
        public void DeliveryAgentConfigTest()
        {
            Assert.NotNull(TestObject.DeliveryAgentConfig);
            Assert.NotNull(TestObject.DeliveryAgentConfig.OnCloseConnection);
            Assert.IsFalse(TestObject.DeliveryAgentConfig.OnCloseConnection.Any());
            Assert.NotNull(TestObject.DeliveryAgentConfig.OnDeliverMailItem);
            Assert.IsFalse(TestObject.DeliveryAgentConfig.OnDeliverMailItem.Any());
            Assert.NotNull(TestObject.DeliveryAgentConfig.OnOpenConnection);
            Assert.IsFalse(TestObject.DeliveryAgentConfig.OnOpenConnection.Any());
        }

        [Test]
        public void RoutingAgentConfigTest()
        {
            Assert.NotNull(TestObject.RoutingAgentConfig);
            Assert.NotNull(TestObject.RoutingAgentConfig.OnCategorizedMessage);
            Assert.IsFalse(TestObject.RoutingAgentConfig.OnCategorizedMessage.Any());
            Assert.NotNull(TestObject.RoutingAgentConfig.OnResolvedMessage);
            Assert.IsFalse(TestObject.RoutingAgentConfig.OnResolvedMessage.Any());
            Assert.NotNull(TestObject.RoutingAgentConfig.OnRoutedMessage);
            Assert.IsFalse(TestObject.RoutingAgentConfig.OnRoutedMessage.Any());
            Assert.NotNull(TestObject.RoutingAgentConfig.OnSubmittedMessage);
            Assert.IsFalse(TestObject.RoutingAgentConfig.OnSubmittedMessage.Any());
        }

        [Test]
        public void SmtpReceiveAgentConfigTest()
        {
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig);
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnAuthCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnAuthCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnConnect);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnConnect.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnDataCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnDataCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnDisconnect);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnDisconnect.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnEhloCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnEhloCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnEndOfAuthentication);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnEndOfAuthentication.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnEndOfData);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnEndOfData.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnEndOfHeaders);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnEndOfHeaders.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnHeloCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnHeloCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnHelpCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnHelpCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnMailCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnMailCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnNoopCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnNoopCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnRcptCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnRcptCommand.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnReject);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnReject.Any());
            Assert.NotNull(TestObject.SmtpReceiveAgentConfig.OnRsetCommand);
            Assert.IsFalse(TestObject.SmtpReceiveAgentConfig.OnRsetCommand.Any());
        }
    }
}
