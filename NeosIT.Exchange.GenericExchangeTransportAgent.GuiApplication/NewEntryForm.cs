using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class NewEntryForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly IEnumerable<IAgentConfig> _agentConfigs;

        public NewEntryForm(MainForm mainForm, IEnumerable<IAgentConfig> agentConfigs)
        {
            _mainForm = mainForm;
            _agentConfigs = agentConfigs;


            InitializeComponent();
        }

        private void NewEntryForm_Load(object sender, System.EventArgs e)
        {
            LoadEvents();
            LoadHandlers();
        }

        private void LoadHandlers()
        {
            comboBoxHandler.BeginUpdate();
            comboBoxHandler.Items.Clear();
            // get all agent config types in all assemblies
            var handlers = AppDomain.CurrentDomain.GetAssemblies().GetHandlerTypes();

            // format combo box values
            var pairs = new List<KeyValuePair<string, Type>>();
            
            // get infos from event combo box
            var propInfo = ((KeyValuePair<string, PropertyInfo>?) comboBoxEvent.SelectedItem)?.Value;
            var agentConfigType = _agentConfigs.SingleOrDefault(x => x.GetType() == propInfo?.DeclaringType);
            
            foreach (var handler in handlers)
            {
                if (agentConfigType.HasHandler(propInfo, handler.DeclaringType))
                {
                    continue;
                }
                var pair = new KeyValuePair<string, Type>(handler.GetTranslatedNameOrDefault(), handler);
                pairs.Add(pair);
            }


            var handlerObjects = pairs.OrderBy(x => x.Key).Cast<object>().ToArray();
            comboBoxHandler.Items.AddRange(handlerObjects);
            comboBoxHandler.EndUpdate();

            comboBoxHandler.ValueMember = nameof(KeyValuePair<string, PropertyInfo>.Value);
            comboBoxHandler.DisplayMember = nameof(KeyValuePair<string, PropertyInfo>.Key);
            comboBoxHandler.SelectedItem = comboBoxHandler.Items[0];

            comboBoxHandler.EndUpdate();
        }

        private void LoadEvents()
        {
            comboBoxEvent.BeginUpdate();

            var events = new List<KeyValuePair<string, PropertyInfo>>();

            // get all agent config types in all assemblies
            var agentConfigTypes = AppDomain.CurrentDomain.GetAssemblies().GetAgentConfigTypes();

            foreach (var agent in agentConfigTypes)
            {
                // filter all properties by type of IList<IHandler>
                var handlers = agent.GetPropertyInfosFromAgentConfigType();
                foreach (var handler in handlers)
                {
                    var agentName = agent.GetTranslatedNameOrDefault().Replace("AgentConfig", "");
                    var pair = new KeyValuePair<string, PropertyInfo>($"{handler.Name} ({agentName})", handler);
                    events.Add(pair);
                }
            }

            var eventObjects = events.OrderBy(x => x.Key).Cast<object>().ToArray();
            comboBoxEvent.Items.AddRange(eventObjects);
            comboBoxEvent.EndUpdate();

            comboBoxEvent.ValueMember = nameof(KeyValuePair<string, PropertyInfo>.Value);
            comboBoxEvent.DisplayMember = nameof(KeyValuePair<string, PropertyInfo>.Key);
            comboBoxEvent.SelectedItem = comboBoxEvent.Items[0];
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var propertyInfo = ((KeyValuePair<string, PropertyInfo>)comboBoxEvent.SelectedItem).Value;
            var handlerType = ((KeyValuePair<string, Type>)comboBoxHandler.SelectedItem).Value;
            var instance = (IHandler)Activator.CreateInstance(handlerType);
            _mainForm.AddEntry(propertyInfo, instance);
            Hide();
        }

        private void comboBoxEvent_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadHandlers();
        }
    }
}