using System;
using System.Linq;
using Microsoft.Exchange.Data.Transport.Routing;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents
{
    public class GenericRoutingAgent : RoutingAgent
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        private readonly TransportAgentConfig _config;

        public GenericRoutingAgent()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();

            _config = ConfigFactory.GetConfig();

            OnCategorizedMessage += OnCategorizedMessageHandler;
            OnResolvedMessage += OnResolvedMessageHandler;
            OnRoutedMessage += OnRoutedMessageHandler;
            OnSubmittedMessage += OnSubmittedMessageHandler;
        }

        private void OnCategorizedMessageHandler(CategorizedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnCategorizedMessage fired...");
            foreach (var x in _config.RoutingAgentConfig.OnCategorizedMessage)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error Executing ""OnCategorizedMessage""");
                }
            }
        }

        private void OnResolvedMessageHandler(ResolvedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnResolvedMessage fired...");
            foreach (var x in _config.RoutingAgentConfig.OnResolvedMessage)
            {
                 try
                 {
                     x.Execute(new EmailItem(e.MailItem));
                 }
                 catch (Exception ex)
                 {
                     Logger.Error(ex, @"Error Executing ""OnResolvedMessage""");
                 }
            }
        }

        private void OnRoutedMessageHandler(RoutedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnRoutedMessage fired...");
            foreach (var x in _config.RoutingAgentConfig.OnRoutedMessage)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error Executing ""OnRoutedMessage""");
                }
            }
        }

        private void OnSubmittedMessageHandler(SubmittedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnSubmittedMessage fired...");
            foreach (var x in _config.RoutingAgentConfig.OnSubmittedMessage)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error Executing ""OnSubmittedMessage""");
                }
            }
        }
    }
}