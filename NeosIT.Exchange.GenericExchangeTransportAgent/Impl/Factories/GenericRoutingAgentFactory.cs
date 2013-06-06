using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Routing;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Factories
{
    public class GenericRoutingAgentFactory : RoutingAgentFactory
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        public GenericRoutingAgentFactory()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();
        }

        public override RoutingAgent CreateAgent(SmtpServer server)
        {
            Logger.Debug("[GenericTransportAgent] [RoutingAgentFactory] Creating new RoutingAgent...");
            return new GenericRoutingAgent();
        }
    }
}