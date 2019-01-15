using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using JetBrains.Annotations;
using log4net;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config
{
    /// <summary>
    /// Handles everything related to the configuration of GETA. Hot reload is enabled by default and will overwrite
    /// <see cref="Config"/>s properties on change.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Only the file name of the configuration file.
        /// </summary>
        public const string FileName = "config.xml";

        /// <summary>
        /// Only the directory name where the configuration file must be in.
        /// </summary>
        public static string DirectoryName =>
            Path.GetDirectoryName(Assembly.GetAssembly(typeof(TransportAgentConfig)).Location);

        /// <summary>
        /// Stores the loaded add-on dll files. At the current time this property cannot be reloaded (refresh
        /// .dll files) without restart.
        /// </summary>
        public static IPluginHost PluginHost { get; }

        /// <summary>
        /// Complete path to the configuration file (directory + file name)
        /// </summary>
        public static string FullPath =>
            Path.Combine(
                DirectoryName,
                FileName
            );

        /// <summary>
        /// Gets or sets whether hot reload is enabled.
        /// </summary>
        public static bool HotReloadEnabled
        {
            get => FileSystemWatcher.EnableRaisingEvents;
            set => FileSystemWatcher.EnableRaisingEvents = value;
        }

        /// <summary>
        /// The global configuration. This property is changed on hot reload.
        /// </summary>
        public static TransportAgentConfig Config =>
            _config ?? (_config = LoadConfiguration() ?? new TransportAgentConfig());

        private static TransportAgentConfig _config;
        private static readonly FileSystemWatcher FileSystemWatcher;
        private static readonly ILog Logger;

        static Configuration()
        {
            Logger = LogManager.GetLogger(typeof(Configuration));
            FileSystemWatcher = new FileSystemWatcher
            {
                Path = DirectoryName,
                Filter = FileName,
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };
            FileSystemWatcher.Changed += FileSystemWatcherOnChanged;

            PluginHost = new PluginHost(DirectoryName);
        }

        private static void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            Logger.Info("Configuration hot-loading.");
            var newConfig = LoadConfiguration();

            if (newConfig == null)
            {
                Logger.Error("Hot reload failed.");
                return;
            }

            _config.RoutingAgentConfig = newConfig.RoutingAgentConfig;
            _config.DeliveryAgentConfig = newConfig.DeliveryAgentConfig;
            _config.SmtpReceiveAgentConfig = newConfig.SmtpReceiveAgentConfig;
        }

        /// <summary>
        /// Tries to load the configuration at the designed path. May be null if the configuration is invalid.
        /// </summary>
        /// <returns>The configuration or null when it's invalid.</returns>
        [CanBeNull]
        private static TransportAgentConfig LoadConfiguration()
        {
            var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Auto};
            var serializer = new DataContractSerializer(typeof(TransportAgentConfig), PluginHost.KnownTypes);
            using (var reader = XmlReader.Create(FullPath, settings))
            {
                try
                {
                    return (TransportAgentConfig) serializer.ReadObject(reader, true);
                }
                catch (InvalidCastException e)
                {
                    Logger.Debug("Failed to load configuration:\n" + File.ReadAllText(FullPath));
                    Logger.Error($"Failed to cast configuration into {nameof(TransportAgentConfig)}", e);
                }
                catch (IOException e)
                {
                    Logger.Error("IO Exception", e);
                }
                catch (Exception e)
                {
                    Logger.Error("Unexpected error.", e);
                }

                return null;
            }
        }
    }
}