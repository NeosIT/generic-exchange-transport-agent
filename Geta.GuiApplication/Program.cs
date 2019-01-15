using System;
using System.Windows.Forms;
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
            Configuration.HotReloadEnabled = false;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
