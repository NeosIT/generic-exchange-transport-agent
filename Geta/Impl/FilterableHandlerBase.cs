using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl
{
    [DataContract(Namespace = "")]
    public abstract class FilterableHandlerBase : HandlerBase, IFilterable
    {
        [DataMember]
        public virtual IList<IFilterable> Filters { get; set; } = new List<IFilterable>();

        public virtual bool AppliesTo(IEmailItem emailItem, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Fatal("[GenericTransportAgent] FilterableHandlerBase - No MailItem available...");
                return false;
            }

            if (null == Filters || 0 == Filters.Count)
            {
                Logger.Debug("[GenericTransportAgent] [MessageID {0}] FilterableHandlerBase - No filters defined, applying...", emailItem.Message.MessageId);
                return true;
            }

            Logger.Info("[GenericTransportAgent] [MessageID {0}] FilterableHandlerBase - Applying filters...", emailItem.Message.MessageId);
            return Filters.Aggregate(false, (current, filter) => current || filter.AppliesTo(emailItem, lastExitCode));
        }
    }
}
