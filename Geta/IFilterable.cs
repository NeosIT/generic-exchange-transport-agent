using System.Collections.Generic;

namespace NeosIT.Exchange.GenericExchangeTransportAgent
{
    public interface IFilterable
    {
        IList<IFilterable> Filters { get; set; }
        bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null);
    }
}
