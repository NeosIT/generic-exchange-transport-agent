using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            _agentConfigs = new List<IAgentConfig>();
            
            var pluginHost = new PluginHost();
            _knownTypes = pluginHost.KnownTypes;
            
            InitializeComponent();
        }

        private readonly IEnumerable<Type> _knownTypes;
        private string _configFilename;
        private TransportAgentConfig _config;

        private readonly List<IAgentConfig> _agentConfigs;
        private TreeNode _selectedNode;


        private void MainFormLoad(object sender, EventArgs e)
        {
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
            var settings = new XmlReaderSettings {ConformanceLevel = ConformanceLevel.Auto,};

            try
            {
                using (var reader = XmlReader.Create(_configFilename, settings))
                {
                    _config = (TransportAgentConfig) serializer.ReadObject(reader, true);
                }

                // TODO make list flat
                treeViewEntries.Nodes.Clear();
                var agents = new IAgentConfig[]
                    {_config.RoutingAgentConfig, _config.DeliveryAgentConfig, _config.SmtpReceiveAgentConfig};
                foreach (var agent in agents)
                {
                    var props = agent.GetType().GetProperties();
                    foreach (var prop in props)
                    {
                        var handlers = agent.GetHandlers(prop);
                        foreach (var handler in handlers)
                        {
                            var andAllSubHandlers = handler.GetAndAllSubHandlers();
                            foreach (var andAllSubHandler in andAllSubHandlers)
                            {
                                AddEntry(prop, andAllSubHandler);
                            }
                        }
                    }
                }
            }
            catch (SerializationException ex)
            {
                // TODO Logger
                Console.WriteLine(ex.Message);
                MessageBox.Show(null, "The file could not be read.", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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
            var form = new NewEntryForm(this, _agentConfigs);
            form.Show(this);
        }

        /// <summary>
        /// Adds an entry to the tree view. Also adds it to the internal collection.
        /// </summary>
        /// <param name="agentProperty">Identifier for the event. Using the <see cref="PropertyInfo" /> we can review the type on which it's declared and the given property name for the event name.</param>
        /// <param name="handler">The actual handler for this tree node.</param>
        /// <exception cref="ArgumentException">When a handler already exist for the given event.</exception>
        public void AddEntry([NotNull] PropertyInfo agentProperty, [NotNull] IHandler handler)
        {
            Debug.Assert(agentProperty.DeclaringType != null, "Declaring type must never be null");
            Debug.Assert(agentProperty.IsValidHandlerPropertyType(), $"Parameter {nameof(agentProperty)} must be of type IList<IAgentConfig>.");

            IAgentConfig agentConfig = null;
            TreeNode groupNode = null;
            TreeNode eventNode = null;
            TreeNode handlerNode = null;

            // do group search / create
            // TODO Replace is dirty
            var groupName = agentProperty.DeclaringType.Name.Replace("AgentConfig", "");
            foreach (TreeNode node in treeViewEntries.Nodes)
            {
                if (node.Name == groupName)
                {
                    groupNode = node;
                    agentConfig = _agentConfigs.Single(x => x.GetType() == agentProperty.DeclaringType);
                    break;
                }
            }

            if (groupNode == null)
            {
                groupNode = new TreeNode(groupName)
                {
                    Name = groupName
                };
                treeViewEntries.Nodes.Add(groupNode);
                agentConfig = (IAgentConfig) Activator.CreateInstance(agentProperty.DeclaringType);
                _agentConfigs.Add(agentConfig);
            }

            // do event search / create
            var eventName = agentProperty.Name;
            if (groupNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in groupNode.Nodes)
                {
                    if (node.Name == eventName)
                    {
                        eventNode = node;
                        break;
                    }
                }
            }

            if (eventNode == null)
            {
                eventNode = new TreeNode(eventName)
                {
                    Name = eventName
                };

                groupNode.Nodes.Add(eventNode);
            }


            // do handler search / create
            if (groupNode.Nodes.Count > 0)
            {
                foreach (TreeNode subNode in eventNode.Nodes)
                {
                    if (subNode.Name == handler.Name)
                    {
                        // as for now the GUI limits the usage of multiple handlers of the same type for an event.
                        throw new ArgumentException(
                            $"Handler {handler.Name} is not allowed here. It's already been added.");
                    }
                }
            }

            // add new handler node if the type does not exist already
            handlerNode = new TreeNode(handler.GetType().Name)
            {
                Name = handler.GetType().Name
            };
            eventNode.Nodes.Add(handlerNode);

            agentConfig.AddHandler(agentProperty, handler);
        }

        private void treeViewEntries_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewEntries.SelectedNode = e.Node;
            
            // only right mouse button allowed
            if (e.Button != MouseButtons.Right) return;
            // skip parents - no action
            if (!IsHandlerNode(e.Node)) return;
            
            treeViewNodeContextMenu.Show(treeViewEntries, e.Location);
        }

        private void treeViewEntries_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!IsHandlerNode(e.Node)) return;
            EditNode(e.Node);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNode(treeViewEntries.SelectedNode);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveNode(treeViewEntries.SelectedNode);
        }

        private void EditNode(TreeNode eNode)
        {
            var agentConfig = _agentConfigs.Single(x => x.GetType().Name.Replace("AgentConfig", "") == eNode.Parent.Parent.Name);
            var eventName = eNode.Parent.Name;
            var entry = new Entry
            {
                AgentConfig = agentConfig,
                EventName = eventName, 
                Handler = agentConfig.GetHandler(eventName, eNode.Name)
            };
            var form = new NewEntryForm(this, _agentConfigs, entry);
            form.Show();
        }

        [Pure]
        private IHandler GetHandlerFromNode([NotNull] TreeNode eNode)
        {
            if (!IsHandlerNode(eNode)) return null;
            foreach (var agentConfig in _agentConfigs)
            {
                var prop = agentConfig.GetType()
                    .GetProperties()
                    .SingleOrDefault(p => p.Name == eNode.Parent.Name);
                if(prop == null) continue;
                
                var handler = agentConfig.GetHandlers(prop).SingleOrDefault(h => h.Name == eNode.Name);
                if(handler != null) return handler;
            }

            return null;
        }

        private void RemoveNode(TreeNode selectedNode)
        {
            throw new NotImplementedException();
        }

        private static bool IsHandlerNode(TreeNode node)
        {
            return node.Nodes.Count == 0 && node.Parent != null;
        }
    }
}