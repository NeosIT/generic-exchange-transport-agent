using System;
using System.ComponentModel;
using JetBrains.Annotations;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions
{
    public static class TransportAgentExtensions
    {
        [Pure]
        public static string GetTranslatedNameOrDefault(this Type type)
        {
            return type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;
        }
    }
}