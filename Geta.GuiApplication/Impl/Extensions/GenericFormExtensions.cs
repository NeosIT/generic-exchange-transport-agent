using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Extensions
{
    public static class GenericFormExtensions
    {
        [CanBeNull, Pure]
        public static Type GetGenericForm(this IEnumerable<Assembly> assemblies, Type genericType)
        {
            // TODO warn when multiple fitting types
            return assemblies.SelectMany(x => x.GetTypes()).FirstOrDefault(x => x.GetInterfaces().Any(i =>
                i.IsGenericType && 
                i.GetGenericTypeDefinition() == typeof(IGenericConfigForm<>) &&
                i.GenericTypeArguments.Length == 1 && 
                i.GenericTypeArguments[0] == genericType
            ));
        }
    }
}