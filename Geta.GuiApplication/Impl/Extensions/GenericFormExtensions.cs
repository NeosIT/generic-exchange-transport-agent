using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Extensions
{
    public static class GenericFormExtensions
    {
        [CanBeNull, Pure]
        public static Type GetGenericForm(this IEnumerable<Assembly> assemblies, Type genericType)
        {
            // TODO warn when multiple fitting types
            return assemblies.SelectMany(x => x.GetTypes()).FirstOrDefault(x =>
                typeof(Form).IsAssignableFrom(x) && x.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IGenericConfigForm<>) &&
                    i.GetGenericArguments().Length == 1 &&
                    i.GetGenericArguments()[0] == genericType
                )
            );
        }
    }
}