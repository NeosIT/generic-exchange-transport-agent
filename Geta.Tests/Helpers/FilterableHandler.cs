using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Helpers
{
    public class FilterableHandler : FilterableHandlerBase
    {
        public override string Name => "FilterableHandler";

        public override string ToString()
        {
            return Name;
        }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            var exitCode = lastExitCode;

            if (null == Handlers || Handlers.Count <= 0) return;

            foreach (var handler in Handlers)
            {
                handler.Execute(emailItem, exitCode);
            }
        }
    }
}
