namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common
{
    using System.Collections.Generic;

    public interface IHandler
    {
        string Name { get; }
        IList<IHandler> Handlers { get; set; }
        void Execute(IEmailItem emailItem = null, int? lastExitCode = null);
    }
}
