namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "")]
    public abstract class FilterableHandlerBase : HandlerBase, IFilterable
    {
        [DataMember]
        public virtual IList<IFilterable> Filters { get; set; } = new List<IFilterable>();

        public virtual bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Debug("[GenericTransportAgent] FilterableHandlerBase - No MailItem available...");
                return false;
            }

            if (null == Filters || 0 == Filters.Count)
            {
                Logger.Debug("[GenericTransportAgent] FilterableHandlerBase - No filters defined, applying...");
                return true;
            }

            Logger.Debug("[GenericTransportAgent] FilterableHandlerBase - Applying filters...");
            return Filters.Aggregate(false, (current, filter) => current || filter.AppliesTo(emailItem, lastExitCode));
        }
    }
}
