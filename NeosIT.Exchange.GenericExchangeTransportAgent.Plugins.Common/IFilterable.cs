namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common
{
    using System.Collections.Generic;

    public interface IFilterable
    {
        IList<IFilterable> Filters { get; set; }
        bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null);
    }
}
