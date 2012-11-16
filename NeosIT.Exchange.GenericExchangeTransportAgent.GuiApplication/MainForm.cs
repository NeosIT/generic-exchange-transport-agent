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
            PluginHost pluginHost = new PluginHost();
            _handlers = pluginHost.Handlers;
            AvailableHandlersTreeView.Nodes.AddRange(TreeNodeMapper.MapHandlers(_handlers));
            AvailableHandlersTreeView.SelectedNode = AvailableHandlersTreeView.Nodes[0];

            _knownTypes = pluginHost.KnownTypes;

            _config = new TransportAgentConfig();

            ConfigurationTreeView.Nodes.Add(TreeNodeMapper.MapTransportAgentConfig(_config));
        }

        private void ConfigurationTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            ConfigHandlerButton.Enabled = false;
            ConfigFiltersButton.Enabled = false;
            AddHandlerButton.Enabled = false;
            RemoveHandlerButton.Enabled = false;
            
            if (null != ConfigurationTreeView.SelectedNode)
            {
                if (null != ConfigurationTreeView.SelectedNode.Tag)
                {
                    if (ConfigurationTreeView.SelectedNode.Tag is IHandler)
                    {
                        AddHandlerButton.Enabled = true;
                        RemoveHandlerButton.Enabled = true;
                    }
                    
                    if (ConfigurationTreeView.SelectedNode.Tag is IViewOptions)
                    {
                        ConfigHandlerButton.Enabled = true;
                    }
                    
                    if (ConfigurationTreeView.SelectedNode.Tag is IFilterable)
                    {
                        ConfigFiltersButton.Enabled = true;
                    }
                    
                    if (ConfigurationTreeView.SelectedNode.Tag is IEnumerable<IAgentEventHandler>)
                    {
                        AddHandlerButton.Enabled = true;
                    }
                }
            }
        }
        
        private void ConfigButtonClick(object sender, EventArgs e)
        {
            ((IViewOptions)ConfigurationTreeView.SelectedNode.Tag).ShowConfigDialog();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == OpenConfigFileDialog.ShowDialog())
            {
                _configFilename = OpenConfigFileDialog.FileName;

                var serializer = new DataContractSerializer(typeof(TransportAgentConfig), _knownTypes);
                var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Auto, };

                using (var reader = XmlReader.Create(_configFilename, settings))
                {
                    _config = (TransportAgentConfig)serializer.ReadObject(reader, true);
                }

                ConfigurationTreeView.Nodes.Clear();
                ConfigurationTreeView.Nodes.Add(TreeNodeMapper.MapTransportAgentConfig(_config));
            }
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
            var settings = new XmlWriterSettings { Indent = true, ConformanceLevel = ConformanceLevel.Auto, };
            settings.NewLineHandling = NewLineHandling.Entitize;

            using (var writer = XmlWriter.Create(filename, settings))
            {
                serializer.WriteObject(writer, _config);
            }

            _configFilename = filename;
        }

        private void ConfigFiltersButtonClick(object sender, EventArgs e)
        {
            IFilterable filterable = (IFilterable) ConfigurationTreeView.SelectedNode.Tag;
            Form form = new FilterForm(filterable, _knownTypes);
            form.ShowDialog();
        }

        private void AddHandlerButtonClick(object sender, EventArgs e)
        {
            if (null != ConfigurationTreeView.SelectedNode)
            {
                if (null != ConfigurationTreeView.SelectedNode.Tag)
                {
                    IHandler handler = (IHandler)
                            Activator.CreateInstance(AvailableHandlersTreeView.SelectedNode.Tag.GetType());

                    if (ConfigurationTreeView.SelectedNode.Tag is IAgentEventHandler)
                    {
                        IAgentEventHandler eventHandler = (IAgentEventHandler) ConfigurationTreeView.SelectedNode.Tag;
                        
                        if (eventHandler.Handlers.IsReadOnly)
                        {
                            eventHandler.Handlers = new List<IHandler>(eventHandler.Handlers);
                        }

                        eventHandler.Handlers.Add(handler);
                        ConfigurationTreeView.SelectedNode.Nodes.Add(TreeNodeMapper.MapHandler(handler));
                    }
                    else if (ConfigurationTreeView.SelectedNode.Tag is IList<IAgentEventHandler>) 
                    {
                        IList<IAgentEventHandler> eventHandlers =
                            (IList<IAgentEventHandler>) ConfigurationTreeView.SelectedNode.Tag;

                        if (eventHandlers.IsReadOnly)
                        {
                            eventHandlers = new List<IAgentEventHandler>(eventHandlers);
                            ConfigurationTreeView.SelectedNode.Tag = eventHandlers;
                        }

                        IAgentEventHandler eventHandler = new AgentEventHandler();
                        eventHandler.Handlers.Add(handler);

                        eventHandlers.Add(eventHandler);
                        ConfigurationTreeView.SelectedNode.Nodes.Add(TreeNodeMapper.MapAgentEventHandler(eventHandler));
                    } 
                    else if (ConfigurationTreeView.SelectedNode.Tag is IHandler) 
                    {
                        IHandler parentHandler = (IHandler) ConfigurationTreeView.SelectedNode.Tag;
                        
                        if (parentHandler.Handlers.IsReadOnly)
                        {
                            parentHandler.Handlers = new List<IHandler>(parentHandler.Handlers);
                        }

                        parentHandler.Handlers.Add(handler);
                        ConfigurationTreeView.SelectedNode.Nodes.Add(TreeNodeMapper.MapHandler(handler));
                    }
                }
            }
        }

        private void RemoveHandlerButtonClick(object sender, EventArgs e)
        {
            if (null != ConfigurationTreeView.SelectedNode)
            {
                if (null != ConfigurationTreeView.SelectedNode.Tag)
                {
                    if (ConfigurationTreeView.SelectedNode.Tag is IAgentEventHandler)
                    {
                        IList<IAgentEventHandler> eventHandlers =
                            (IList<IAgentEventHandler>) ConfigurationTreeView.SelectedNode.Parent.Tag;

                        IAgentEventHandler eventHandler = (IAgentEventHandler) ConfigurationTreeView.SelectedNode.Tag;

                        if (eventHandlers.IsReadOnly)
                        {
                            eventHandlers = new List<IAgentEventHandler>(eventHandlers);
                            ConfigurationTreeView.SelectedNode.Parent.Tag = eventHandlers;
                        }

                        eventHandlers.Remove(eventHandler);
                        ConfigurationTreeView.SelectedNode.Remove();
                    }
                    else if (ConfigurationTreeView.SelectedNode.Tag is IHandler)
                    {
                        IHandler handler = (IHandler) ConfigurationTreeView.SelectedNode.Tag;

                        if (ConfigurationTreeView.SelectedNode.Parent.Tag is IAgentEventHandler)
                        {
                            IAgentEventHandler eventHandler =
                                (IAgentEventHandler)ConfigurationTreeView.SelectedNode.Parent.Tag;

                            if (eventHandler.Handlers.IsReadOnly)
                            {
                                eventHandler.Handlers = new List<IHandler>(eventHandler.Handlers);
                            }

                            eventHandler.Handlers.Remove(handler);
                            ConfigurationTreeView.SelectedNode.Remove();
                        }
                        else if (ConfigurationTreeView.SelectedNode.Parent.Tag is IHandler)
                        {
                            IHandler parentHandler = (IHandler) ConfigurationTreeView.SelectedNode.Parent.Tag;

                            if (parentHandler.Handlers.IsReadOnly)
                            {
                                parentHandler.Handlers = new List<IHandler>(parentHandler.Handlers);
                            }

                            parentHandler.Handlers.Remove(handler);
                            ConfigurationTreeView.SelectedNode.Remove();
                        }
                    }
                }
            }
        }
    }
}
