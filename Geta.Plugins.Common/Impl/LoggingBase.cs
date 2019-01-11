using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    [DataContract(Namespace = "")]
    public abstract class LoggingBase
    {
        public IKernel Kernel { get; set; }
        public ILogger Logger { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext c)
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();
        }
    }
}
