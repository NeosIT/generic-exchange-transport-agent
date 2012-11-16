using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    public class PluginHost : IPluginHost
    {
        private CompositionContainer _container;

        [ImportMany(typeof(IHandler), AllowRecomposition = true)]
        public IEnumerable<IHandler> Handlers { get; set; }

        [ImportMany(typeof(IFilterable), AllowRecomposition = true)]
        public IEnumerable<IFilterable> Filters { get; set; }

        public IEnumerable<Type> KnownTypes
        {
            get
            {
                if (null != Handlers)
                {
                    foreach (var handler in Handlers)
                    {
                        yield return handler.GetType();
                    }
                }

                if (null != Filters)
                {
                    foreach (var filter in Filters)
                    {
                        yield return filter.GetType();
                    }
                }
            }
        }

        public PluginHost()
        {
            var exePath = Assembly.GetExecutingAssembly().Location;

            if (!string.IsNullOrEmpty(exePath))
            {
                var path = Path.GetDirectoryName(exePath);

                if (!string.IsNullOrEmpty(path))
                {
                    Init(path);
                }
            }
        }

        public PluginHost(string path)
        {
            Init(path);
        }

        public void Init(string path)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(path, "*.dll"));

            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }

        public void Dispose()
        {
            if (null != _container)
            {
                _container.Dispose();
            }
        }
    }
}
