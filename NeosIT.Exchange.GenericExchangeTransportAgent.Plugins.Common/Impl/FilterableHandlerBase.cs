namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract(Namespace = "")]
    public abstract class FilterableHandlerBase : HandlerBase, IFilterable
    {
        private IList<IFilterable> _filters = new List<IFilterable>();

        [DataMember]
        public virtual IList<IFilterable> Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }

        public virtual bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Fatal("[GenericTransportAgent] FilterableHandlerBase - No MailItem available...");
                return false;
            }

            if (null == Filters || 0 == Filters.Count)
            {
                Logger.Warn("[GenericTransportAgent] [MessageID {0}] FilterableHandlerBase - No filters defined, applying...", emailItem.Message.MessageId);
                return true;
            }

            Logger.Info("[GenericTransportAgent] [MessageID {0}] FilterableHandlerBase - Applying filters...", emailItem.Message.MessageId);
            return Filters.Aggregate(false, (current, filter) => current || filter.AppliesTo(emailItem, lastExitCode));
        }
    }
}
