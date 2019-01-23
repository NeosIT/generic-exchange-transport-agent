using System;
using System.Linq;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models
{
    /// <summary>
    /// Holds require data for all interactions in the GUI.
    /// Creates a shallow copy of the handler. It is not reference equal!
    /// </summary>
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

        public string EventNameFormatted => FormatEventName(EventName, AgentConfig.GetType().Name);

        public static string FormatEventName(string eventName, string agentName)
        {
            return $"{eventName} ({agentName})";
        }
    }
}