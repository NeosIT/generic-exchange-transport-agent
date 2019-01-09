using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Xml;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config
{
    public static class ConfigFactory
    {
        private static readonly string ConfigFileName =
            Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof (TransportAgentConfig)).Location),
                         "config.xml");

        private static TransportAgentConfig _config;

        private static long _configFileSize;
        private static byte[] _configFileHash;

        public static TransportAgentConfig GetConfig()
        {
            var fileInfo = new FileInfo(ConfigFileName);
            if (fileInfo.Length != _configFileSize)
            {
                LoadConfiguration();
            }
            else
            {
                var computedHash = ComputeConfigHash();
                if (computedHash != _configFileHash)
                {
                    LoadConfiguration();
                }
            }

            return _config;
        }

        private static byte[] ComputeConfigHash()
        {
            var hash = HashAlgorithm.Create();
            using (var fileStream = new FileStream(ConfigFileName, FileMode.Open, FileAccess.Read))
            {
                return hash.ComputeHash(fileStream);
            }
        }

        private static void LoadConfiguration()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IPluginHost pluginHost = new PluginHost(path);
            var fileInfo = new FileInfo(ConfigFileName);
            _configFileSize = fileInfo.Length;
            _configFileHash = ComputeConfigHash();
            var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Auto,};
            var serializer = new DataContractSerializer(typeof (TransportAgentConfig), pluginHost.KnownTypes);
            using (var reader = XmlReader.Create(ConfigFileName, settings))
            {
                _config = (TransportAgentConfig) serializer.ReadObject(reader, true);
            }
        }
    }
}