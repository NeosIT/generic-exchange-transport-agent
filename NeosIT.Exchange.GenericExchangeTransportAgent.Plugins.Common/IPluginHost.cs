using System;
using System.Collections.Generic;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common
{
    public interface IPluginHost : IDisposable
    {
        IEnumerable<Type> KnownTypes { get; }
        IEnumerable<IHandler> Handlers { get; set; }
        IEnumerable<IFilterable> Filters { get; set; } 
    }
}
