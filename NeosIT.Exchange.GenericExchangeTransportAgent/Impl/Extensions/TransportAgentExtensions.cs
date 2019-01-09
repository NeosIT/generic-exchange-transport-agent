using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions
{
    public static class TransportAgentExtensions
    {
        [Pure]
        public static string GetTranslatedNameOrDefault(this Type type)
        {
            return type.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;
        }

        public static bool IsValidHandlerPropertyType(this PropertyInfo propertyInfo)
        {
            var genericArguments = propertyInfo.PropertyType.GetGenericArguments();
            var propertyIsIList = propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>);
            var argumentIsIHandler = typeof(IHandler).IsAssignableFrom(genericArguments[0]);
            return propertyIsIList &&
                   genericArguments.Length == 1 &&
                   argumentIsIHandler;
        }
    }
}