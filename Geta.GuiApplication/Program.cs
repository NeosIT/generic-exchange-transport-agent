using System;
using System.Reflection;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // enforce all referenced assemblies to be loaded
            foreach (var referencedAssembly in Assembly.GetAssembly(typeof(EntryForm)).GetReferencedAssemblies())
            {
                AppDomain.CurrentDomain.Load(referencedAssembly);
            }
            var pluginHost = new PluginHost();
            pluginHost.Init(".");
            Configuration.HotReloadEnabled = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
