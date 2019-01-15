using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Xml;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config
{
    public static class ConfigFactory
    {
        public const string ConfigFileName = "config.xml";

        public static string ConfigPath =>
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetAssembly(typeof(TransportAgentConfig)).Location) ?? "",
                ConfigFileName
            );

        private static TransportAgentConfig _config;
        
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private static readonly FileSystemWatcher FileSystemWatcher;

        static ConfigFactory()
        {
            FileSystemWatcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(ConfigPath),
                Filter = ConfigFileName,
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };
            FileSystemWatcher.Changed += FileSystemWatcherOnChanged;
        }

        private static void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            _config = LoadConfiguration();
        }

        public static TransportAgentConfig GetConfig()
        {
            return _config ?? (_config = LoadConfiguration());
        }

        private static TransportAgentConfig LoadConfiguration()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IPluginHost pluginHost = new PluginHost(path);
            var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Auto,};
            var serializer = new DataContractSerializer(typeof(TransportAgentConfig), pluginHost.KnownTypes);
            using (var reader = XmlReader.Create(ConfigPath, settings))
            {
                return (TransportAgentConfig) serializer.ReadObject(reader, true);
            }
        }
    }
}