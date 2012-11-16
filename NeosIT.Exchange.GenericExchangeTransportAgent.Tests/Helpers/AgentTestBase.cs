using Microsoft.Exchange.Data.Transport;
using NUnit.Framework;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    [TestFixture]
    public abstract class AgentTestBase<T> where T : Agent, new()
    {
        protected T TestObject { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestObject = new T();
        }

        [Test]
        public void AssertNotNull()
        {
            Assert.NotNull(TestObject);
        }

        [Test]
        public void AssertInstanceOf()
        {
            Assert.IsInstanceOf<Agent>(TestObject);
            Assert.IsInstanceOf<T>(TestObject);
        }
    }
}
