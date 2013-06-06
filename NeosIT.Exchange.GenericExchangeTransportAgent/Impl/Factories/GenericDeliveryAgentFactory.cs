using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Delivery;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Factories
{
    public class GenericDeliveryAgentFactory<T> : DeliveryAgentFactory<T> where T : DeliveryAgentManager, new()
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        public GenericDeliveryAgentFactory()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();
        }

        public override DeliveryAgent CreateAgent(SmtpServer server)
        {
            Logger.Debug("[GenericExchangeTransportAgent] [DeliveryAgentFactory] Creating new DeliveryAgent...");
            return new GenericDeliveryAgent();
        }
    }
}