namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System.Runtime.Serialization;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
    using Ninject;
    using Ninject.Extensions.Logging;

    [DataContract(Namespace = "")]
    public abstract class LoggingBase
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext c)
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();
        }
    }
}
