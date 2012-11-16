using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    public class FilterableHandler : FilterableHandlerBase
    {
        public override string Name
        {
            get { return "FilterableHandler"; }
        }

        public override string ToString()
        {
            return Name;
        }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            int? exitCode = lastExitCode;

            if (null != Handlers && Handlers.Count > 0)
            {
                foreach (IHandler handler in Handlers)
                {
                    handler.Execute(emailItem, exitCode);
                }
            }
        }
    }
}
