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

        private void OnCategorizedMessageHandler(CategorizedMessageEventSource source,
                                                 QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnCategorizedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            _config.RoutingAgentConfig.OnCategorizedMessage.ToList().ForEach(
                x => { try { x.Execute(emailItem); } catch (Exception ex) { Logger.Error(ex, @"Error Executing ""OnCategorizedMessage"""); } });

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }

        private void OnResolvedMessageHandler(ResolvedMessageEventSource source,
                                              QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnResolvedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            _config.RoutingAgentConfig.OnResolvedMessage.ToList().ForEach(
                x => { try { x.Execute(emailItem); } catch (Exception ex) { Logger.Error(ex, @"Error Executing ""OnResolvedMessage"""); } });

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }

        private void OnRoutedMessageHandler(RoutedMessageEventSource source,
                                            QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnRoutedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            _config.RoutingAgentConfig.OnRoutedMessage.ToList().ForEach(
                x => { try { x.Execute(emailItem); } catch (Exception ex) { Logger.Error(ex, @"Error Executing ""OnRoutedMessage"""); } });

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }

        private void OnSubmittedMessageHandler(SubmittedMessageEventSource source,
                                               QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnSubmittedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            _config.RoutingAgentConfig.OnSubmittedMessage.ToList().ForEach(
                x => { try { x.Execute(emailItem); } catch (Exception ex) { Logger.Error(ex, @"Error Executing ""OnSubmittedMessage"""); } });

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }
    }
}