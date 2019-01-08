using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private IEnumerable<IHandler> _handlers;
        private IEnumerable<Type> _knownTypes;
        private string _configFilename;
        private TransportAgentConfig _config;


        private void MainFormLoad(object sender, EventArgs e)
        {
            //var pluginHost = new PluginHost();
            //_handlers = pluginHost.Handlers;
            //AvailableHandlersTreeView.Nodes.AddRange(TreeNodeMapper.MapHandlers(_handlers));
            //AvailableHandlersTreeView.SelectedNode = AvailableHandlersTreeView.Nodes[0];

            //_knownTypes = pluginHost.KnownTypes;

            //_config = new TransportAgentConfig();

            //ConfigurationTreeView.Nodes.Add(TreeNodeMapper.MapTransportAgentConfig(_config));
        }

        private void ConfigurationTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            //ConfigHandlerButton.Enabled = false;
            //ConfigFiltersButton.Enabled = false;
            //AddHandlerButton.Enabled = false;
            //RemoveHandlerButton.Enabled = false;

            //if (ConfigurationTreeView.SelectedNode?.Tag == null) return;

            //if (ConfigurationTreeView.SelectedNode.Tag is IHandler)
            //{
            //    AddHandlerButton.Enabled = true;
            //    RemoveHandlerButton.Enabled = true;
            //}

            //if (ConfigurationTreeView.SelectedNode.Tag is IViewOptions)
            //{
            //    ConfigHandlerButton.Enabled = true;
            //}

            //if (ConfigurationTreeView.SelectedNode.Tag is IFilterable)
            //{
            //    ConfigFiltersButton.Enabled = true;
            //}

            //if (ConfigurationTreeView.SelectedNode.Tag is IEnumerable<IAgentEventHandler>)
            //{
            //    AddHandlerButton.Enabled = true;
            //}
        }

        private void ConfigButtonClick(object sender, EventArgs e)
        {
            ((IViewOptions)treeViewEntries.SelectedNode.Tag).ShowConfigDialog();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK != OpenConfigFileDialog.ShowDialog()) return;

            _configFilename = OpenConfigFileDialog.FileName;

            var serializer = new DataContractSerializer(typeof(TransportAgentConfig), _knownTypes);
            var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Auto, };

            using (var reader = XmlReader.Create(_configFilename, settings))
            {
                _config = (TransportAgentConfig)serializer.ReadObject(reader, true);
            }

            treeViewEntries.Nodes.Clear();
            treeViewEntries.Nodes.Add(TreeNodeMapper.MapTransportAgentConfig(_config));
        }

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            SaveConfigFileDialog.FileName = string.IsNullOrEmpty(_configFilename) ? "config.xml" : _configFilename;
            if (DialogResult.OK == SaveConfigFileDialog.ShowDialog())
            {
                SaveConfig(SaveConfigFileDialog.FileName);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_configFilename))
            {
                SaveAsButtonClick(sender, e);
            }
            else
            {
                SaveConfig(_configFilename);
            }
        }

        private void SaveConfig(string filename)
        {
            var serializer = new DataContractSerializer(typeof(TransportAgentConfig), _knownTypes);
            var settings = new XmlWriterSettings
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Auto,
                NewLineHandling = NewLineHandling.Entitize
            };

            using (var writer = XmlWriter.Create(filename, settings))
            {
                serializer.WriteObject(writer, _config);
            }

            _configFilename = filename;
        }

        private void ConfigFiltersButtonClick(object sender, EventArgs e)
        {
            var filterable = (IFilterable) treeViewEntries.SelectedNode.Tag;
            Form form = new FilterForm(filterable, _knownTypes);
            form.ShowDialog();
        }

        private void AddHandlerButtonClick(object sender, EventArgs e)
        {
            //if (ConfigurationTreeView.SelectedNode?.Tag == null) return;

            //var handler = (IHandler)
            //    Activator.CreateInstance(AvailableHandlersTreeView.SelectedNode.Tag.GetType());

            //switch (ConfigurationTreeView.SelectedNode.Tag)
            //{
            //    case IAgentEventHandler eventHandler:
            //    {
            //        if (eventHandler.Handlers.IsReadOnly)
            //        {
            //            eventHandler.Handlers = new List<IHandler>(eventHandler.Handlers);
            //        }

            //        eventHandler.Handlers.Add(handler);
            //        ConfigurationTreeView.SelectedNode.Nodes.Add(TreeNodeMapper.MapHandler(handler));
            //        break;
            //    }
            //    case IList<IAgentEventHandler> eventHandlers:
            //    {
            //        if (eventHandlers.IsReadOnly)
            //        {
            //            eventHandlers = new List<IAgentEventHandler>(eventHandlers);
            //            ConfigurationTreeView.SelectedNode.Tag = eventHandlers;
            //        }

            //        IAgentEventHandler eventHandler = new AgentEventHandler();
            //        eventHandler.Handlers.Add(handler);

            //        eventHandlers.Add(eventHandler);
            //        ConfigurationTreeView.SelectedNode.Nodes.Add(TreeNodeMapper.MapAgentEventHandler(eventHandler));
            //        break;
            //    }
            //    case IHandler parentHandler:
            //    {
            //        if (parentHandler.Handlers.IsReadOnly)
            //        {
            //            parentHandler.Handlers = new List<IHandler>(parentHandler.Handlers);
            //        }

            //        parentHandler.Handlers.Add(handler);
            //        ConfigurationTreeView.SelectedNode.Nodes.Add(TreeNodeMapper.MapHandler(handler));
            //        break;
            //    }
            //}
        }

        private void RemoveHandlerButtonClick(object sender, EventArgs e)
        {
            if (treeViewEntries.SelectedNode?.Tag == null) return;

            if (treeViewEntries.SelectedNode.Tag is IAgentEventHandler eventHandler1)
            {
                var eventHandlers =
                    (IList<IAgentEventHandler>) treeViewEntries.SelectedNode.Parent.Tag;

                if (eventHandlers.IsReadOnly)
                {
                    eventHandlers = new List<IAgentEventHandler>(eventHandlers);
                    treeViewEntries.SelectedNode.Parent.Tag = eventHandlers;
                }

                eventHandlers.Remove(eventHandler1);
                treeViewEntries.SelectedNode.Remove();
            }
            else if (treeViewEntries.SelectedNode.Tag is IHandler handler)
            {
                if (treeViewEntries.SelectedNode.Parent.Tag is IAgentEventHandler eventHandler)
                {
                    if (eventHandler.Handlers.IsReadOnly)
                    {
                        eventHandler.Handlers = new List<IHandler>(eventHandler.Handlers);
                    }

                    eventHandler.Handlers.Remove(handler);
                    treeViewEntries.SelectedNode.Remove();
                }
                else if (treeViewEntries.SelectedNode.Parent.Tag is IHandler parentHandler)
                {
                    if (parentHandler.Handlers.IsReadOnly)
                    {
                        parentHandler.Handlers = new List<IHandler>(parentHandler.Handlers);
                    }

                    parentHandler.Handlers.Remove(handler);
                    treeViewEntries.SelectedNode.Remove();
                }
            }
        }

        private void buttonNewEntry_Click(object sender, EventArgs e)
        {
            var form = new NewEntryForm(treeViewEntries.Nodes);
            form.Show(this);
        }
    }
}
