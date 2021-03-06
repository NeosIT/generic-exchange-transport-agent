﻿using System.IO;
using System.Reflection;
using log4net.Config;
using Ninject;
using Ninject.Extensions.Logging.Log4net;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl
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
