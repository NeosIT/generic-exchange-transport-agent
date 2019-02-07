using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Extensions
{
    public static class Net35Extensions
    {
#if NET35
        public static T GetCustomAttribute<T>([NotNull] this Assembly assembly) where T : Attribute
        {
            return (T) assembly.GetCustomAttributes(typeof(T), true).FirstOrDefault(x => x is T);
        }
#endif

        public static bool IsNullOrWhiteSpace(this string str)
        {
#if NET35
            return str == null || str.Trim() == "";
#else
            return string.IsNullOrWhiteSpace(str);
#endif
        }
    }
}