using System.Reflection;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models
{
    public class Entry
    {
        public IAgentConfig AgentConfig { get; set; }
        public string EventName { get; set; }
        public IHandler Handler { get; set; }
    }
}