using System;
using System.Reflection;
using System.Windows.Forms;

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
            foreach (var referencedAssembly in Assembly.GetAssembly(typeof(NewEntryForm)).GetReferencedAssemblies())
            {
                AppDomain.CurrentDomain.Load(referencedAssembly);
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
