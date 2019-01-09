using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    [TestFixture]
    public abstract class FilterTestBase<T> where T : IFilterable, new()
    {
        protected T TestObject { get; set; }

        [SetUp]
        public void SetUp()
        {
            TestObject = new T();
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

            if (!(testObject is IFilterable ifilterable)) return;
            if (null == ifilterable.Filters || ifilterable.Filters.Count <= 0) return;

            foreach (var filter in ifilterable.Filters)
            {
                PrepareLogger(filter);
            }
        }
    }
}
