using System;
using Microsoft.Exchange.Data.Transport.Routing;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents
{
    public class GenericRoutingAgent : RoutingAgent
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        public GenericRoutingAgent()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();

            OnCategorizedMessage += OnCategorizedMessageHandler;
            OnResolvedMessage += OnResolvedMessageHandler;
            OnRoutedMessage += OnRoutedMessageHandler;
            OnSubmittedMessage += OnSubmittedMessageHandler;
        }

        private void OnCategorizedMessageHandler(CategorizedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnCategorizedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            foreach(var x in Configuration.Config.RoutingAgentConfig.OnCategorizedMessage)
            {
                try
                {
                    x.Execute(emailItem);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error Executing ""OnCategorizedMessage""");
                }
            }

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }

        private void OnResolvedMessageHandler(ResolvedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnResolvedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            foreach (var x in Configuration.Config.RoutingAgentConfig.OnResolvedMessage)
            {
                 try
                 {
                     x.Execute(emailItem);
                 }
                 catch (Exception ex)
                 {
                     Logger.Error(ex, @"Error Executing ""OnResolvedMessage""");
                 }
            }

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }

        private void OnRoutedMessageHandler(RoutedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnRoutedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            foreach (var x in Configuration.Config.RoutingAgentConfig.OnRoutedMessage)
            {
                try
                {
                    x.Execute(emailItem);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error Executing ""OnRoutedMessage""");
                }
            }

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }

        private void OnSubmittedMessageHandler(SubmittedMessageEventSource source, QueuedMessageEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] RoutingAgent - OnSubmittedMessage fired...");
            var emailItem = new EmailItem(e.MailItem);
            foreach (var x in Configuration.Config.RoutingAgentConfig.OnSubmittedMessage)
            {
                try
                {
                    x.Execute(emailItem);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error Executing ""OnSubmittedMessage""");
                }
            }

            if (emailItem.ShouldBeDeletedFromQueue)
            {
                source.Delete();
            }
        }
    }
}