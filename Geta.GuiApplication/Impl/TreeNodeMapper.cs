using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl
{
    public class TreeNodeMapper
    {
        public static TreeNode MapTransportAgentConfig(TransportAgentConfig config)
        {
            var node = new TreeNode();

            if (null == config) return node;

            const string configText = "Config";
            node.Name = configText;
            node.Text = configText;
            node.Tag = config;

            node.Nodes.Add(MapDeliveryAgentConfig(config.DeliveryAgentConfig));
            node.Nodes.Add(MapRoutingAgentConfig(config.RoutingAgentConfig));
            node.Nodes.Add(MapSmtpReceiveAgentConfig(config.SmtpReceiveAgentConfig));

            return node;
        }

        public static TreeNode MapDeliveryAgentConfig(DeliveryAgentConfig agentConfig)
        {
            var node = new TreeNode();

            if (null == agentConfig) return node;

            const string deliveryAgentText = "DeliveryAgent";
            node.Name = deliveryAgentText;
            node.Text = deliveryAgentText;
            node.Tag = agentConfig;

            node.Nodes.Add(MapAgentEvent("OnCloseConnection", agentConfig.OnCloseConnection));
            node.Nodes.Add(MapAgentEvent("OnDeliverMailItem", agentConfig.OnDeliverMailItem));
            node.Nodes.Add(MapAgentEvent("OnOpenConnection", agentConfig.OnOpenConnection));

            return node;
        }

        public static TreeNode MapRoutingAgentConfig(RoutingAgentConfig agentConfig)
        {
            var node = new TreeNode();

            if (null == agentConfig) return node;

            const string routingAgentText = "RoutingAgent";
            node.Name = routingAgentText;
            node.Text = routingAgentText;
            node.Tag = agentConfig;

            node.Nodes.Add(MapAgentEvent("OnCategorizedMessage", agentConfig.OnCategorizedMessage));
            node.Nodes.Add(MapAgentEvent("OnResolvedMessage", agentConfig.OnResolvedMessage));
            node.Nodes.Add(MapAgentEvent("OnRoutedMessage", agentConfig.OnRoutedMessage));
            node.Nodes.Add(MapAgentEvent("OnSubmittedMessage", agentConfig.OnSubmittedMessage));

            return node;
        }

        public static TreeNode MapSmtpReceiveAgentConfig(SmtpReceiveAgentConfig agentConfig)
        {
            var node = new TreeNode();

            if (null == agentConfig) return node;

            const string smtpReceiveAgentText = "SmtpReceiveAgent";
            node.Name = smtpReceiveAgentText;
            node.Text = smtpReceiveAgentText;
            node.Tag = agentConfig;

            node.Nodes.Add(MapAgentEvent("OnAuthCommand", agentConfig.OnAuthCommand));
            node.Nodes.Add(MapAgentEvent("OnConnect", agentConfig.OnConnect));
            node.Nodes.Add(MapAgentEvent("OnDataCommand", agentConfig.OnDataCommand));
            node.Nodes.Add(MapAgentEvent("OnDisconnect", agentConfig.OnDisconnect));
            node.Nodes.Add(MapAgentEvent("OnEhloCommand", agentConfig.OnEhloCommand));
            node.Nodes.Add(MapAgentEvent("OnEndOfAuthentication", agentConfig.OnEndOfAuthentication));
            node.Nodes.Add(MapAgentEvent("OnEndOfData", agentConfig.OnEndOfData));
            node.Nodes.Add(MapAgentEvent("OnEndOfHeaders", agentConfig.OnEndOfHeaders));
            node.Nodes.Add(MapAgentEvent("OnHeloCommand", agentConfig.OnHeloCommand));
            node.Nodes.Add(MapAgentEvent("OnHelpCommand", agentConfig.OnHelpCommand));
            node.Nodes.Add(MapAgentEvent("OnMailCommand", agentConfig.OnMailCommand));
            node.Nodes.Add(MapAgentEvent("OnNoopCommand", agentConfig.OnNoopCommand));
            node.Nodes.Add(MapAgentEvent("OnRcptCommand", agentConfig.OnRcptCommand));
            node.Nodes.Add(MapAgentEvent("OnReject", agentConfig.OnReject));
            node.Nodes.Add(MapAgentEvent("OnRsetCommand", agentConfig.OnRsetCommand));

            return node;
        }

        public static TreeNode MapAgentEvent(string eventName, IEnumerable<IAgentEventHandler> agentEventHandlers)
        {
            var node = new TreeNode {Name = eventName, Text = eventName};

            if (null == agentEventHandlers) return node;

            node.Nodes.AddRange(MapAgentEventHandlers(agentEventHandlers));
            node.Tag = agentEventHandlers;

            return node;
        }

        public static TreeNode[] MapAgentEventHandlers(IEnumerable<IAgentEventHandler> agentEventHandlers)
        {
            var nodes = new List<TreeNode>();

            if (null != agentEventHandlers)
            {
                nodes.AddRange(agentEventHandlers.Select(MapAgentEventHandler));
            }

            return nodes.ToArray();
        }

        public static TreeNode MapAgentEventHandler(IAgentEventHandler agentEventHandler)
        {
            var node = new TreeNode();

            if (null == agentEventHandler) return node;

            node.Name = agentEventHandler.ToString();
            node.Text = agentEventHandler.ToString();
            node.Tag = agentEventHandler;

            node.Nodes.AddRange(MapHandlers(agentEventHandler.Handlers));

            return node;
        }


        public static TreeNode[] MapHandlers(IEnumerable<IHandler> handlers)
        {
            var nodes = new List<TreeNode>();

            if (null != handlers)
            {
                nodes.AddRange(handlers.Select(MapHandler));
            }

            return nodes.ToArray();
        }

        public static TreeNode MapHandler(IHandler handler)
        {
            var node = new TreeNode();

            if (null == handler) return node;

            node.Name = handler.ToString();
            node.Text = handler.ToString();
            node.Tag = handler;

            node.Nodes.AddRange(MapHandlers(handler.Handlers));

            return node;
        }

        public static TreeNode[] MapFilters(IEnumerable<IFilterable> filters)
        {
            var nodes = new List<TreeNode>();

            if (null != filters)
            {
                nodes.AddRange(filters.Select(MapFilter));
            }

            return nodes.ToArray();
        }

        public static TreeNode MapFilter(IFilterable filterable)
        {
            var node = new TreeNode();

            if (!(filterable is Filter filter)) return node;

            string filterText = $"{filter.On} {filter.Operator} {filter.Value}";
            node.Name = filterText;
            node.Text = filterText;
            node.Tag = filterable;

            node.Nodes.AddRange(MapFilters(filter.Filters));

            return node;
        }
    }
}
