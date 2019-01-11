using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Smtp;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Factories
{
    public class GenericSmtpReceiveAgentFactory : SmtpReceiveAgentFactory
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        public GenericSmtpReceiveAgentFactory()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();
        }

        public override SmtpReceiveAgent CreateAgent(SmtpServer server)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgentFactory - Creating new SmtpReceiveAgent...");
            return new GenericSmtpReceiveAgent();
        }
    }
}