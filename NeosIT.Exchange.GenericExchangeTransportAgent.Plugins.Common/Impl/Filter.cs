namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Enums;
    using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions;

    [Export(typeof(IFilterable))]
    [DataContract(Name = "Filter", Namespace = "")]
    public class Filter : LoggingBase, IFilterable
    {
        private IList<IFilterable> _filters = new List<IFilterable>();

        [DataMember]
        public virtual IList<IFilterable> Filters
        {
            get { return _filters; }
            set { _filters = value; }
        }

        [DataMember]
        public virtual FilterKeyEnum On { get; internal set; }

        [DataMember]
        public virtual FilterOperatorEnum Operator { get; internal set; }

        [DataMember]
        public virtual string Value { get; internal set; }

        #region IFilterable Members

        public virtual bool AppliesTo(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (null == emailItem)
            {
                Logger.Debug("[GenericTransportAgent] Filter - No MailItem available...");
                return false;
            }

            Logger.Debug(@"[GenericTransportAgent] Filter - MailItem Subject: ""{0}""; From: ""{1}""...", emailItem.Message.Subject, emailItem.FromAddress.ToString());
            Logger.Debug("[GenericTransportAgent] Filter - Applying filter {0} {1} {2}...", On, Operator, Value);

            bool appliesTo = false;

            switch (On)
            {
                case FilterKeyEnum.From:
                    appliesTo = CheckForValue(emailItem.FromAddress.ToString(), Operator, Value);
                    break;
                case FilterKeyEnum.To:
                    appliesTo = (null != emailItem.Message.To && 0 != emailItem.Message.To.Count &&
                                 emailItem.Message.To.Any(rcpt => CheckForValue(rcpt.SmtpAddress, Operator, Value)));
                    break;
                case FilterKeyEnum.Subject:
                    appliesTo = CheckForValue(emailItem.Message.Subject, Operator, Value);
                    break;
                case FilterKeyEnum.LastExitCode:
                    appliesTo = !lastExitCode.HasValue ||
                                (CheckForValue(lastExitCode.Value.ToString(CultureInfo.InvariantCulture), Operator,
                                               Value)/* ||
                                 CheckForValue(((int) ExitCodeEnum.CommandNotRun).ToString(CultureInfo.InvariantCulture), Operator, Value)*/);
                    break;
            }

            bool subFilterApplyTo = true;

            if (appliesTo && null != Filters && 0 != Filters.Count)
            {
                Logger.Debug("[GenericTransportAgent] Filter - Applying subfilters...");
                subFilterApplyTo = Filters.Aggregate(false,
                                                     (current, subFilter) => current || subFilter.AppliesTo(emailItem));
            }

            return appliesTo && subFilterApplyTo;
        }

        public void Dispose()
        {
        }

        #endregion

        protected virtual bool CheckForValue(string src, FilterOperatorEnum @operator, string value)
        {
            switch (@operator)
            {
                case FilterOperatorEnum.StartsWith:
                    return src.StartsWith(value, StringComparison.InvariantCultureIgnoreCase);
                case FilterOperatorEnum.Equals:
                    return src.Equals(value, StringComparison.InvariantCultureIgnoreCase);
                case FilterOperatorEnum.NotEquals:
                    return !src.Equals(value, StringComparison.InvariantCultureIgnoreCase);
                case FilterOperatorEnum.EndsWith:
                    return src.EndsWith(value, StringComparison.InvariantCultureIgnoreCase);
                case FilterOperatorEnum.Regex:
                    return Regex.IsMatch(src, value, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                case FilterOperatorEnum.Contains:
                    return src.Contains(value, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
    }
}