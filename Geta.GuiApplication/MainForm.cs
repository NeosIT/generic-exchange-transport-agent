using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config.Agents;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class MainForm : Form
    {
        public static Color HighlightColor = Color.Yellow;
        public static Color NotHighlightedColor = Color.Transparent;

        private readonly IEnumerable<Type> _knownTypes;
        private string _configFilename;
        private TransportAgentConfig _config;
        private List<IAgentConfig> _agentConfigs;
        private readonly PluginHost _pluginHost;

        public MainForm()
        {
            _agentConfigs = new List<IAgentConfig>();
            _config = new TransportAgentConfig();

            _pluginHost = new PluginHost();
            _knownTypes = _pluginHost.KnownTypes;

            InitializeComponent();
        }


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
                        {_config.RoutingAgentConfig, _config.DeliveryAgentConfig, _config.SmtpReceiveAgentConfig}
                    .Where(x => x != null);
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
            } // TODO Logger
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(
                    null,
                    "The file seems to be corrupt or invalid.",
                    "The file could not be read.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly
                );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(
                    null,
                    "The file has duplicate handlers for some events. Please fix this manually.",
                    "The file could not be read.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly
                );
            }
        }

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            SaveConfigFileDialog.FileName = _configFilename.IsNullOrWhiteSpace() ? "config.xml" : _configFilename;
            if (DialogResult.OK == SaveConfigFileDialog.ShowDialog())
            {
                SaveConfig(SaveConfigFileDialog.FileName);
            }
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (_configFilename.IsNullOrWhiteSpace())
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
                NewLineHandling = NewLineHandling.Entitize,
                OmitXmlDeclaration = true
            };

            _config.RoutingAgentConfig =
                (RoutingAgentConfig) _agentConfigs.SingleOrDefault(x => x is RoutingAgentConfig);
            _config.DeliveryAgentConfig =
                (DeliveryAgentConfig) _agentConfigs.SingleOrDefault(x => x is DeliveryAgentConfig);
            _config.SmtpReceiveAgentConfig =
                (SmtpReceiveAgentConfig) _agentConfigs.SingleOrDefault(x => x is SmtpReceiveAgentConfig);

            using (var writer = XmlWriter.Create(filename, settings))
            {
                serializer.WriteObject(writer, _config);
            }

            _configFilename = filename;
        }

        private void buttonNewEntry_Click(object sender, EventArgs e)
        {
            var form = new EntryForm(this, _agentConfigs);
            form.Show(this);
        }

        /// <summary>
        /// Adds an entry to the tree view. Also adds it to the internal collection.
        /// </summary>
        /// <param name="eventProperty">Identifier for the event. Using the <see cref="PropertyInfo" /> we can review the type on which it's declared and the given property name for the event name.</param>
        /// <param name="handler">The actual handler for this tree node.</param>
        /// <exception cref="ArgumentException">When a handler already exist for the given event.</exception>
        public void AddEntry([NotNull] PropertyInfo eventProperty, [NotNull] IHandler handler)
        {
            Debug.Assert(eventProperty.DeclaringType != null, "Declaring type must never be null");
            Debug.Assert(eventProperty.IsValidHandlerPropertyType(),
                $"Parameter {nameof(eventProperty)} must be of type IList<IAgentConfig>.");

            IAgentConfig agentConfig = null;
            TreeNode groupNode = null;
            TreeNode eventNode = null;
            TreeNode handlerNode = null;

            // do group search / create
            // TODO Replace is dirty
            var groupName = eventProperty.DeclaringType.Name.Replace("AgentConfig", "");
            foreach (TreeNode node in treeViewEntries.Nodes)
            {
                if (node.Name == groupName)
                {
                    groupNode = node;
                    agentConfig = _agentConfigs.Single(x => x.GetType() == eventProperty.DeclaringType);
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
                agentConfig = _agentConfigs.SingleOrDefault(x => x.GetType() == eventProperty.DeclaringType);
                if (agentConfig == null)
                {
                    agentConfig = (IAgentConfig) Activator.CreateInstance(eventProperty.DeclaringType);
                    _agentConfigs.Add(agentConfig);
                }
            }

            // do event search / create
            var eventName = eventProperty.Name;
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

            agentConfig.AddHandler(eventProperty, handler);

            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        public void RemoveEntry(PropertyInfo eventProperty, Type handlerType)
        {
            var agentConfig = _agentConfigs.Single(x => x.GetType() == eventProperty.DeclaringType);
            var result = agentConfig.RemoveHandler(eventProperty, handlerType);

            if (result)
            {
                var removedAgentNode = RemoveNode(agentConfig.GetType().Name.Replace("AgentConfig", ""),
                    eventProperty.Name, handlerType.Name);

                if (removedAgentNode)
                {
                    _agentConfigs.Remove(agentConfig);

                    if (treeViewEntries.Nodes.Count == 0)
                    {
                        saveToolStripMenuItem.Enabled = false;
                        saveAsToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }

        public void ReplaceEntry(PropertyInfo eventProperty, IHandler oldHandler, IHandler newHandler)
        {
            var agentConfig = _agentConfigs.Single(x => x.GetType() == eventProperty.DeclaringType);
            var result = agentConfig.ReplaceHandler(eventProperty, oldHandler, newHandler);

            if (result)
            {
                var groupNode = treeViewEntries.Nodes.Find(agentConfig.GetType().Name.Replace("AgentConfig", ""), false)
                    .SingleOrDefault();
                var eventNode = groupNode?.Nodes.Find(eventProperty.Name, false).SingleOrDefault();
                var handlerNode = eventNode?.Nodes.Find(oldHandler.GetType().Name, false).SingleOrDefault();

                if (handlerNode != null)
                {
                    handlerNode.Text = newHandler.GetType().Name;
                    handlerNode.Name = newHandler.GetType().Name;
                }
            }
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
            var agentConfig = _agentConfigs.Single(x =>
                x.GetType().Name.Replace("AgentConfig", "") == treeViewEntries.SelectedNode.Parent.Parent.Name);
            var eventName = treeViewEntries.SelectedNode.Parent.Name;
            var handler = agentConfig.GetHandler(eventName, treeViewEntries.SelectedNode.Text);

            Debug.Assert(handler != null, "handler != null");

            RemoveEntry(agentConfig.GetType().GetProperty(eventName), handler.GetType());
        }

        private void EditNode(TreeNode selectedNode)
        {
            var agentConfig = _agentConfigs.Single(x =>
                x.GetType().Name.Replace("AgentConfig", "") == selectedNode.Parent.Parent.Name);
            var eventName = selectedNode.Parent.Name;
            var handler = agentConfig.GetHandler(eventName, selectedNode.Text);

            Debug.Assert(handler != null, "handler != null");

            var entry = new Entry(agentConfig, eventName, handler);
            var form = new EntryForm(this, _agentConfigs, entry);
            form.Show();
        }

        private bool RemoveNode(string agentConfigName, string eventName, string handlerName)
        {
            var groupNode = treeViewEntries.Nodes.Find(agentConfigName, false).SingleOrDefault();
            var eventNode = groupNode?.Nodes.Find(eventName, false).SingleOrDefault();
            var handlerNode = eventNode?.Nodes.Find(handlerName, false).SingleOrDefault();

            handlerNode?.Remove();

            // delete parents if necessary
            if (eventNode?.Nodes.Count == 0)
            {
                eventNode.Remove();

                if (groupNode.Nodes.Count == 0)
                {
                    groupNode.Remove();
                    return true;
                }
            }

            return false;
        }

        private static bool IsHandlerNode(TreeNode node)
        {
            return node.Nodes.Count == 0 && node.Parent != null;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewEntries.Nodes.Clear();

            _config = new TransportAgentConfig();
            _agentConfigs = new List<IAgentConfig>();

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var str = textBoxSearch.Text;

            foreach (TreeNode node in treeViewEntries.Nodes)
            {
                TryHighlightNode(node, str);
            }
        }

        private static void TryHighlightNode(TreeNode node, string text)
        {
            var color = default(Color);
            if (text.IsNullOrWhiteSpace())
            {
                color = NotHighlightedColor;
            }
            else if (node.Text.Contains(text))
            {
                color = HighlightColor;
                node.Expand();
                var parent = node;
                while ((parent = parent.Parent) != null)
                {
                    parent.Expand();
                }
            }

            node.BackColor = color;

            foreach (TreeNode child in node.Nodes)
            {
                TryHighlightNode(child, text);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm(_pluginHost);
            form.Show();
        }
    }
}