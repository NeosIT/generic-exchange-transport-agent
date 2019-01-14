﻿using System.Linq;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NUnit.Framework;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests.Plugins.Common
{
    [TestFixture]
    public class PluginHostTests
    {
        [Test]
        public void LoadPlugins()
        {
            var pluginHost = new PluginHost();

            Assert.NotNull(pluginHost);
            Assert.NotNull(pluginHost.KnownTypes);
            Assert.NotNull(pluginHost.Handlers);
            Assert.NotNull(pluginHost.Filters);

            Assert.AreEqual(10, pluginHost.KnownTypes.Count());
            Assert.AreEqual(8, pluginHost.Handlers.Count());
            Assert.AreEqual(2, pluginHost.Filters.Count());
        }
    }
}
