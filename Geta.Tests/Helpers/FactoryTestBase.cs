using Microsoft.Exchange.Data.Transport;
using NUnit.Framework;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    [TestFixture]
    public abstract class FactoryTestBase<T> where T : AgentFactory, new()
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
            Assert.IsInstanceOf<AgentFactory>(TestObject);
            Assert.IsInstanceOf<T>(TestObject);
        }
    }
}
