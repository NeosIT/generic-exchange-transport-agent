using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions
{
    /// <summary>
    /// Extension class to bring newer .NET functionality to old .NET 3.5
    /// </summary>
    public static class OldNetExtensions
    {
        [Pure, CanBeNull]
        public static T GetCustomAttribute<T>([NotNull]this Type type, bool inherit = false) where T : Attribute
        {
            return type.GetCustomAttributes<T>(inherit).FirstOrDefault();
        }
        
        [Pure]
        public static IEnumerable<T> GetCustomAttributes<T>([NotNull]this Type type, bool inherit = false) where T : Attribute
        {
            return type.GetCustomAttributes(typeof(T), inherit).Cast<T>();
        }
    }
}