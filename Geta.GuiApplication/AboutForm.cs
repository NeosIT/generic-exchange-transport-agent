using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.ReflectionModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class AboutForm : Form
    {
        private readonly PluginHost _pluginHost;
        private readonly Version _version;
        private readonly string _build;
        private readonly string _revision;

        public AboutForm(PluginHost pluginHost)
        {
            InitializeComponent();

            _pluginHost = pluginHost;

            var assembly = typeof(IAgentConfig).Assembly;
            _version = assembly.GetName().Version; // AssemblyVersion
            _build = assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version; // AssemblyFileVersion
            _revision = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion; // AssemblyFileInformationVersion
        }

        private void AboutForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            labelTitle.Text = $"Generic Exchange Transport Agent {_version}";
            labelBuild.Text = $"Build {_build}";
            labelRevision.Text = $"Revision {_revision}";
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            var pluginNames = _pluginHost.Container.Catalog.Parts
                .Select(x => ReflectionModelServices.GetPartType(x).Value.Assembly)
                .Distinct()
                .Select(x => $"{x.GetName().Name} @ {x.GetName().Version}")
                .ToList();

            var txt = $@"Generic Exchange Transport Agent @ {_version}
Build: {_build}
Revision {_revision}

Loaded Plugins:
{string.Join("\n", pluginNames)}";
            Clipboard.SetText(txt, TextDataFormat.UnicodeText);

            buttonCopy.Text = "Copied!";
        }
    }
}