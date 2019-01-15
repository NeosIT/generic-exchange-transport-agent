using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.MailEndpointHandler.Impl;
using NUnit.Framework;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests
{
    [TestFixture]
    public class ConfigTests
    {
        private string _configFileContents;

        [SetUp]
        public void Setup()
        {
            _configFileContents = File.ReadAllText(Configuration.FullPath);
        }

        [TearDown]
        public void Teardown()
        {
            // relies on the file watcher to reload / reset the config. 
            File.WriteAllText(Configuration.FullPath, _configFileContents);
        }
        
        [Test]
        public async Task TestHotReload()
        {
            var config = Configuration.Config;
            
            Assert.IsEmpty(config.RoutingAgentConfig.OnRoutedMessage);
            
            File.WriteAllText(Configuration.FullPath, @"
<GenericTransportAgent xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
  <RoutingAgent>
    <OnRoutedMessage xmlns:d3p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
      <d3p1:anyType xmlns="""" i:type=""MailEndpointHandler"">
      </d3p1:anyType>
    </OnRoutedMessage>
  </RoutingAgent>
</GenericTransportAgent>");
            
            await Task.Delay(1000); // wait for filesystem watcher to catch up

            var config2 = Configuration.Config;
            
            Assert.AreSame(config, config2);
            
            Assert.IsNotEmpty(config.RoutingAgentConfig.OnRoutedMessage);
            Assert.IsInstanceOf<MailEndpointHandler>(config.RoutingAgentConfig.OnRoutedMessage.First());
        }

        [Test]
        public async Task TestHotReloadSwitch()
        {
            Configuration.HotReloadEnabled = false;
            
            var config = Configuration.Config;
            
            Assert.IsEmpty(config.RoutingAgentConfig.OnRoutedMessage);

            File.WriteAllText(Configuration.FullPath, "");
            
            await Task.Delay(1000); // be sure to wait. When the watcher is still enabled it may not be fast enough.
            
            Assert.IsEmpty(config.RoutingAgentConfig.OnRoutedMessage);
        }

        [Test]
        public async Task TestHotReloadIsFailSafe()
        {            
            var config = Configuration.Config;

            File.WriteAllText(Configuration.FullPath, @"
<GenericTransportAgent xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
  <RoutingAgent>
    <OnRoutedMessage xmlns:d3p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
      <d3p1:anyType xmlns="""" i:type=""MailEndpointHandler"">
      </d3p1:anyType>
    </OnRoutedMessage>
  </RoutingAgent>
</GenericTransportAgent>");
            
            await Task.Delay(1000); // wait for filesystem watcher to catch up

            Assert.IsNotEmpty(config.RoutingAgentConfig.OnRoutedMessage);

            File.WriteAllText(Configuration.FullPath, @"");
            
            await Task.Delay(1000); // wait for filesystem watcher to catch up

            Assert.IsNotEmpty(config.RoutingAgentConfig.OnRoutedMessage);
        }
    }
}