using System;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.NoopHandler.Impl;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    [TestFixture]
    public abstract class HandlerTestBase<T> where T : IHandler, new()
    {
        protected T TestObject { get; set; }

        protected string Name { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestObject = new T();
            TestObject.Handlers.Add(new NoopHandler());
        }
        [Test]
        public void NameTest()
        {
            Assert.AreEqual(Name, TestObject.Name);
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual(Name, TestObject.ToString());
        }

        protected void PrepareLogger()
        {
            PrepareLogger(TestObject);
        }

        protected void PrepareLogger(object testObject)
        {
            if (testObject is LoggingBase loggingBase)
            {
                loggingBase.Kernel = NInjectHelper.GetKernel();
                loggingBase.Logger = loggingBase.Kernel.Get<ILoggerFactory>().GetLogger(typeof(T));
            }

            if (testObject is IHandler ihandler)
            {
                if (null != ihandler.Handlers && ihandler.Handlers.Count > 0)
                {
                    foreach (var handler in ihandler.Handlers)
                    {
                        PrepareLogger(handler);
                    }
                }
            }

            if (testObject is IFilterable ifilterable)
            {
                if (null != ifilterable.Filters && ifilterable.Filters.Count > 0)
                {
                    foreach (var filter in ifilterable.Filters)
                    {
                        PrepareLogger(filter);
                    }
                }
            }
        }
    }
}
