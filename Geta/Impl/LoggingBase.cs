using System.Runtime.Serialization;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl
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
