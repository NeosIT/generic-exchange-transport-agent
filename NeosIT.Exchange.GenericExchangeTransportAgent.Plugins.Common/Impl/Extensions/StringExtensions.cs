using System;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string value, StringComparison comp)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            return source.IndexOf(value, comp) >= 0;
        }
    }
}
