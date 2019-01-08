using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class NewEntryForm : Form
    {
        private readonly TreeNodeCollection _treeNodeCollection;

        public NewEntryForm(TreeNodeCollection treeNodeCollection)
        {
            _treeNodeCollection = treeNodeCollection;
            InitializeComponent();
        }

        private void NewEntryForm_Load(object sender, System.EventArgs e)
        {
            comboBoxEvent.BeginUpdate();
            // get all agent types in all assemblies
            var agentTypes = new List<Type>();
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                agentTypes.AddRange(assembly.GetTypes().Where(x => typeof(IAgentConfig).IsAssignableFrom(x)).ToArray());
            }

            var agentConfigs = new List<KeyValuePair<string, PropertyInfo>>();
            
            foreach (var agent in agentTypes)
            {
                // filter all properties by type of IList<IAgentEventHandler>
                var handlers = agent.GetProperties()
                    .Where(x => 
                        x.PropertyType.IsGenericType &&
                        typeof(IList<>).IsAssignableFrom(x.PropertyType.GetGenericTypeDefinition()) &&
                        typeof(IAgentEventHandler).IsAssignableFrom(x.PropertyType.GetGenericArguments()[0]))
                    .ToArray();
                foreach (var handler in handlers)
                {
                    var agentName = agent.Name.Replace("AgentConfig", "");
                    var pair = new KeyValuePair<string, PropertyInfo>($"{handler.Name} ({agentName})", handler);
                    agentConfigs.Add(pair);
                }
            }

            var objects = agentConfigs.OrderBy(x => x.Key).Cast<object>().ToArray();
            comboBoxEvent.Items.AddRange(objects);
            comboBoxEvent.EndUpdate();

            comboBoxEvent.ValueMember = "Value";
            comboBoxEvent.DisplayMember = "Key";
            comboBoxEvent.SelectedItem = comboBoxEvent.Items[0];
        }
    }
}