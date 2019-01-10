using System;
using System.Linq;
using System.Reflection;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models
{
    public class Entry
    {
        public IAgentConfig AgentConfig { get; }
        public string EventName { get; }
        public IHandler Handler { get; }

        public Entry(IAgentConfig agentConfig, string eventName, IHandler handler)
        {
            AgentConfig = agentConfig;
            EventName = eventName;

            // don't use handler directly - use shallow copy instead to check whether it changed after editing in GUI
            var handlerType = handler.GetType();
            Handler = (IHandler) Activator.CreateInstance(handlerType);
            var props = handlerType.GetProperties().Where(x => x.CanWrite);
            foreach (var propertyInfo in props)
            {
                var parameters = propertyInfo.GetValue(handler, new object[0]);
                propertyInfo.SetValue(Handler, parameters, new object[0]);
            }
        }
    }
}