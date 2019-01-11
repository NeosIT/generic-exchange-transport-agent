using System.Collections.Generic;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common
{
    public interface IHandler
    {
        string Name { get; }
        IList<IHandler> Handlers { get; set; }
        void Execute(IEmailItem emailItem = null, int? lastExitCode = null);
    }
}
