using System;
using Microsoft.Exchange.Data.Transport.Delivery;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents
{
    public class GenericDeliveryAgent : DeliveryAgent
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        private readonly TransportAgentConfig _config;

        public GenericDeliveryAgent()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();

            _config = ConfigFactory.GetConfig();

            OnCloseConnection += OnCloseConnectionHandler;
            OnDeliverMailItem += OnDeliverMailItemHandler;
            OnOpenConnection += OnOpenConnectionHandler;
        }

        private void OnCloseConnectionHandler(CloseConnectionEventSource source, CloseConnectionEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] DeliveryAgent - OnClose fired...");
            foreach (var x in _config.DeliveryAgentConfig.OnCloseConnection)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnCloseConnection""");
                }
            }
        }

        private void OnDeliverMailItemHandler(DeliverMailItemEventSource source, DeliverMailItemEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] DeliveryAgent - OnDeliverMailItem fired...");
            foreach (var x in _config.DeliveryAgentConfig.OnDeliverMailItem)
            {
                try
                {
                    x.Execute(new EmailItem(e.DeliverableMailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnDeliverMailItem""");
                }
            }
        }

        private void OnOpenConnectionHandler(OpenConnectionEventSource source, OpenConnectionEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] DeliveryAgent - OpenConnection fired...");
            foreach (var x in _config.DeliveryAgentConfig.OnOpenConnection)
            {
                try
                {
                    x.Execute(new EmailItem(e.DeliverableMailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnOpenConnection""");
                }
            }
        }
    }
}