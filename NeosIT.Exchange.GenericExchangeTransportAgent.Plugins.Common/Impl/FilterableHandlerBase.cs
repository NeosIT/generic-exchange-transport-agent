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
                this.Fatal("No MailItem available...");
                return false;
            }

            if (null == Filters || 0 == Filters.Count)
            {
                this.Warn("[MessageID {0}] No filters defined, applying...", emailItem.Message.MessageId);
                return true;
            }

            this.Info("[MessageID {0}] Applying filters...", emailItem.Message.MessageId);
            return Filters.Aggregate(false, (current, filter) => current || filter.AppliesTo(emailItem, lastExitCode));
        }
    }
}
