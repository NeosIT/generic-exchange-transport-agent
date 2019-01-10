using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions
{
    /// <summary>
    /// Extensions for dealing with agent configs via reflection. This is done via reflection to allow maximum
    /// flexibility (user created handlers).
    /// </summary>
    public static class AgentConfigExtensions
    {
        /// <summary>
        /// Adds a handler to the given agent configs list of events.
        /// </summary>
        /// <param name="agentConfig">Agent config instance on which the property (<see cref="eventPropertyInfo"/>) is declared.</param>
        /// <param name="eventPropertyInfo">PropertyInfo to get the list from the agent config.</param>
        /// <param name="handler">The actual handler instance to add.</param>
        public static void AddHandler([NotNull] this IAgentConfig agentConfig, [NotNull] PropertyInfo eventPropertyInfo,
            [NotNull] IHandler handler)
        {
            // now try to insert the handler into our collection
            // this needs to be done via reflection as users may use their own handlers
            var list = (IList) eventPropertyInfo.GetValue(agentConfig, new object[0]);
            // use .Insert instead of .Add to support IList
            var insertMethod = list.GetType().GetMethods().Single(x => x.Name == nameof(IList<IHandler>.Insert));

            insertMethod.Invoke(list, new object[] {list.Count, handler});
        }

        /// <summary>
        /// Checks the agent configs property (via <see cref="eventPropertyInfo"/>) whether it contains the given handler type.
        /// </summary>
        /// <param name="agentConfig">AgentConfig on where the event list is declared as property.</param>
        /// <param name="eventPropertyInfo">PropertyInfo to get the list from the agent config.</param>
        /// <param name="handlerType">Type of the handler.</param>
        /// <returns></returns>
        [Pure]
        public static bool HasHandler(this IAgentConfig agentConfig, PropertyInfo eventPropertyInfo,
            [NotNull] Type handlerType)
        {
            // if no eventProperty exists the handler does not exist yet (probably).
            if (agentConfig == null || eventPropertyInfo == null) return false;


            var list = (IList) eventPropertyInfo.GetValue(agentConfig, new object[0]);

            // get LINQ .Any method and make it generic
            var anyMethod = typeof(Enumerable).GetMethods()
                .Single(x => x.Name == nameof(Enumerable.Any) && x.GetParameters().Length == 2);
            anyMethod = anyMethod.MakeGenericMethod(typeof(IHandler));

            // run something like list.Any(x => x.GetType() == handler.GetType()) to check whether the type has been added yet.
            return (bool) anyMethod.Invoke(null,
                new object[] {list, new Func<IHandler, bool>(x => x.GetType() == handlerType)});
        }

        /// <summary>
        /// Gets all <see cref="IHandler"/> from all given assemblies. If you use
        /// <code>AppDomain.CurrentDomain.GetAssemblies()</code> be sure to ensure that all necessary assemblies are
        /// loaded like referenced and dynamic assemblies from MEF.
        /// </summary>
        /// <param name="assemblies">A collection of assemblies which to search.</param>
        /// <returns>All non abstract classes that inherit from <see cref="IAgentConfig"/></returns>
        /// <exception cref="ArgumentNullException">When <see cref="assemblies"/> is null.</exception>
        [Pure]
        public static IEnumerable<Type> GetAgentConfigTypes([NotNull] this IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null) throw new ArgumentNullException(nameof(assemblies));

            return assemblies.SelectMany(assembly =>
            {
                return assembly.GetTypes()
                    .Where(x =>
                        typeof(IAgentConfig).IsAssignableFrom(x) &&
                        x.IsClass &&
                        !x.IsAbstract
                    );
            });
        }

        /// <summary>
        /// Gets all <see cref="IHandler"/>s from all given assemblies. If you use
        /// <code>AppDomain.CurrentDomain.GetAssemblies()</code> be sure to ensure that all necessary assemblies are
        /// loaded like referenced and dynamic assemblies from MEF.
        /// </summary>
        /// <param name="assemblies">A collection of assemblies which to search.</param>
        /// <returns>All non abstract classes that inherit from <see cref="IHandler"/></returns>
        /// <exception cref="ArgumentNullException">When <see cref="assemblies"/> is null.</exception>
        [Pure]
        public static IEnumerable<Type> GetHandlerTypes([NotNull] this IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null) throw new ArgumentNullException(nameof(assemblies));

            return assemblies.SelectMany(assembly =>
            {
                return assembly.GetTypes()
                    .Where(x =>
                        typeof(IHandler).IsAssignableFrom(x) &&
                        x.IsClass &&
                        !x.IsAbstract
                    );
            });
        }

        /// <summary>
        /// Gets all properties from the given type which match the required format of an agent config event property.
        /// Must match the following requirements:
        /// * MemberType: Property
        /// * PropertyType: IList &lt;&gt;
        /// * GenericType: Inheritance of IHandler
        /// </summary>
        /// <param name="agentConfigType">Type in which to search for properties.</param>
        /// <returns>All found property infos.</returns>
        /// <exception cref="ArgumentNullException">If <see cref="agentConfigType"/> is null.</exception>
        [Pure]
        public static IEnumerable<PropertyInfo> GetPropertyInfosFromAgentConfigType([NotNull] this Type agentConfigType)
        {
            if (agentConfigType == null) throw new ArgumentNullException(nameof(agentConfigType));
            if (!typeof(IAgentConfig).IsAssignableFrom(agentConfigType)) return Enumerable.Empty<PropertyInfo>();

            return agentConfigType.GetProperties()
                .Where(x => x.IsValidHandlerPropertyType())
                .ToArray();
        }

        /// <summary>
        /// Checks whether the given property is a valid handler property.
        /// </summary>
        /// <param name="propertyInfo">The property you want to check</param>
        /// <returns>Whether the property is a valid handler property.</returns>
        [Pure]
        public static bool IsValidHandlerPropertyType(this PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsGenericType &&
                   propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) &&
                   typeof(IHandler).IsAssignableFrom(propertyInfo.PropertyType.GetGenericArguments()[0]);
        }

        /// <summary>
        /// Gets all handlers from an agent configs property. This is useful if you don't know the agent configs type or
        /// the IHandler type of the property.
        /// </summary>
        /// <param name="agentConfig">The object for the property info. On this object the property must exist.</param>
        /// <param name="propertyInfo">Property on which to look for handlers. Must be declared on the type of agent config.</param>
        /// <returns>A collection of all handlers in the property.</returns>
        /// <exception cref="ArgumentNullException">When agent config or property info is null.</exception>
        /// <exception cref="ArgumentException">When the property info does not match the agent configs type.</exception>
        [Pure]
        public static IEnumerable<IHandler> GetHandlers([NotNull] this IAgentConfig agentConfig,
            [NotNull] PropertyInfo propertyInfo)
        {
            if (agentConfig == null) throw new ArgumentNullException(nameof(agentConfig));
            if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));

            if (!agentConfig.GetType().IsAssignableFrom(propertyInfo.DeclaringType))
            {
                throw new ArgumentException("PropertyInfo is not declared on the type of agent config.", nameof(propertyInfo));
            }
            
            var list = (IList) propertyInfo.GetValue(agentConfig, new object[0]);
            return list.Cast<IHandler>();
        }

        /// <summary>
        /// Gets the handler and all its sub handlers in one flat collection. 
        /// </summary>
        /// <param name="handler">The handler in which to search for sub handlers.</param>
        /// <returns>A flat collection of the handler itself and all sub handlers.</returns>
        /// <exception cref="Exception">
        ///     If there is a circular reference in the handlers.
        ///     Can not happen after serialization. Can only happen if the object is built manually.
        /// </exception>
        /// <exception cref="ArgumentNullException">If <see cref="handler"/> is null.</exception>
        [Pure]
        public static IEnumerable<IHandler> GetAndAllSubHandlers([NotNull] this IHandler handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            var returnList = new List<IHandler>();
            var currentHandlers = new List<IHandler> {handler};
            var depth = 0;
            while (currentHandlers.Any())
            {
                foreach (var x in currentHandlers)
                {
                    if (returnList.Contains(x))
                    {
                        // item already existing -> circular reference
                        throw new Exception(
                            "Circular reference detected in handlers and its sub handlers: " +
                            $"Handler: {handler.Name} | SubHandler: {x.Name} | Depth: {depth}");
                    }
                }

                depth++;

                returnList.AddRange(currentHandlers);

                currentHandlers = currentHandlers.SelectMany(x => x.Handlers).ToList();
            }

            return returnList;
        }

        [Pure, CanBeNull]
        public static IHandler GetHandler([NotNull]this IAgentConfig agentConfig, [CanBeNull]string eventName, [CanBeNull]string handlerName)
        {
            if (eventName == null || handlerName == null) return null;
            
            var prop = agentConfig.GetType().GetProperty(eventName);
            if (prop == null) return null;

            return agentConfig.GetHandlers(prop).SingleOrDefault(x => x.GetType().Name == handlerName);
        }
    }
}