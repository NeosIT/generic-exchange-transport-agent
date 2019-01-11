using System.Linq;
using NUnit.Framework;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using Ninject;
using Ninject.Extensions.Logging.Log4net;
using Ninject.Modules;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Common
{
    [TestFixture]
    public class NInjectHelperTests
    {
        [Test]
        public void AssertSetUp()
        {
            var kernel = NInjectHelper.GetKernel();
            Assert.NotNull(kernel);
            Assert.IsInstanceOf<IKernel>(kernel);
            Assert.IsInstanceOf<StandardKernel>(kernel);
            
            var modules = kernel.GetModules();
            Assert.NotNull(modules);

            var modulesList = modules.ToList();
            Assert.IsTrue(modulesList.Any());

            var log4NetModule = modulesList.SingleOrDefault(x => x.GetType() == typeof(Log4NetModule));
            Assert.NotNull(log4NetModule);
            Assert.IsInstanceOf<INinjectModule>(log4NetModule);
            Assert.IsInstanceOf<Log4NetModule>(log4NetModule);
        }
    }
}
