using System;
using System.Linq;
using Microsoft.Exchange.Data.Transport.Delivery;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;
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
            Logger.Debug("[GenericExchangeTransportagent] [DeliveryAgent] OnClose fired...");
            _config.DeliveryAgentConfig.OnCloseConnection.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnCloseConnection"""); } });
        }

        private void OnDeliverMailItemHandler(DeliverMailItemEventSource source, DeliverMailItemEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [DeliveryAgent] OnDeliverMailItem fired...");
            _config.DeliveryAgentConfig.OnDeliverMailItem.ToList().ForEach(x => { try { x.Execute(new EmailItem(e.DeliverableMailItem)); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnDeliverMailItem"""); } });
        }

        private void OnOpenConnectionHandler(OpenConnectionEventSource source, OpenConnectionEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [DeliveryAgent] OpenConnection fired...");
            _config.DeliveryAgentConfig.OnOpenConnection.ToList().ForEach(x => { try { x.Execute(new EmailItem(e.DeliverableMailItem)); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnOpenConnection"""); } });
        }
    }
}