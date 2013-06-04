using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Mail2NewsHandler
{
    public interface IMail2NewsHandler : IHandler, IViewOptions, IFilterable
    {
    }
}
