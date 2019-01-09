using System.IO;
using System.Reflection;
using Ninject;
using Ninject.Extensions.Logging.Log4net;
using log4net.Config;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl
{
    public class NInjectHelper
    {
        private static IKernel _kernel;

        public static IKernel GetKernel()
        {
            return _kernel ?? (_kernel = CreateKernel(Assembly.GetCallingAssembly()));
        }

        private static IKernel CreateKernel(Assembly assembly)
        {
            var settings = CreateSettings();
            IKernel kernel = new StandardKernel(settings, new Log4NetModule());

            string configFilename = $"{assembly.Location}.config";
            var fileInfo = new FileInfo(configFilename);

            XmlConfigurator.ConfigureAndWatch(fileInfo);
            return kernel;
        }

        private static INinjectSettings CreateSettings()
        {
            var settings = new NinjectSettings {LoadExtensions = false};
            return settings;
        }
    }
}
