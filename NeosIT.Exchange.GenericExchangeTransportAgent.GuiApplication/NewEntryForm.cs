using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class NewEntryForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly IEnumerable<IAgentConfig> _agentConfigs;
        private readonly Entry _initialEntry;
        private IEnumerable<Type> _handlerTypes;

        public NewEntryForm(MainForm mainForm, IEnumerable<IAgentConfig> agentConfigs, Entry entry = null)
        {
            _mainForm = mainForm;
            _agentConfigs = agentConfigs;

            InitializeComponent();

            _handlerTypes = AppDomain.CurrentDomain.GetAssemblies().GetHandlerTypes();
            _initialEntry = entry;
        }

        private void NewEntryForm_Load(object sender, System.EventArgs e)
        {
            LoadEvents();
            
            if (_initialEntry != null)
            {
                var selectedEvent = comboBoxEvent.Items.Cast<string>()
                    .SingleOrDefault(x => x == $"{_initialEntry.EventName} ({_initialEntry.AgentConfig.GetType().Name})");
                comboBoxEvent.SelectedItem = selectedEvent;
                
                LoadHandlers();
                
                var selectedHandler = comboBoxHandler.Items.Cast<string>()
                    .SingleOrDefault(x => x == _initialEntry.Handler?.GetType().Name);
                comboBoxHandler.SelectedItem = selectedHandler;
            }
            else
            {
                comboBoxEvent.SelectedItem = comboBoxEvent.Items[0];
                
                LoadHandlers();
                comboBoxHandler.SelectedItem = comboBoxEvent.Items[0];
            }
        }

        private void LoadHandlers()
        {
            comboBoxHandler.BeginUpdate();

            var handlers = new List<string>();
            
            foreach (var handler in _handlerTypes)
            {
                if (CurrentAgent?.GetHandler(CurrentEventName, handler.Name) != null && _initialEntry == null)
                {
                    continue;
                }
                handlers.Add(handler.Name);
            }


            var handlerObjects = handlers.OrderBy(x => x).Cast<object>().ToArray();
            comboBoxHandler.Items.Clear();
            comboBoxHandler.Items.AddRange(handlerObjects);
            comboBoxHandler.EndUpdate();
        }

        private void LoadEvents()
        {
            comboBoxEvent.BeginUpdate();

            // get all agent config types in all assemblies
            var agentConfigTypes = AppDomain.CurrentDomain.GetAssemblies().GetAgentConfigTypes();
            var events = agentConfigTypes
                .SelectMany(x => x.GetPropertyInfosFromAgentConfigType().Select(p => $"{p.Name} ({p.DeclaringType.Name})"));

            var eventObjects = events.OrderBy(x => x).Cast<object>().ToArray();
            comboBoxEvent.Items.Clear();
            comboBoxEvent.Items.AddRange(eventObjects);
            comboBoxEvent.EndUpdate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var handler = CurrentAgent?.GetHandler(CurrentEventName, CurrentHandlerName);
            
            // TODO show dialog
            if(handler == null) throw new ArgumentException("Handler must not be null");
            
            var eventProperty = CurrentAgent?.GetType().GetProperty(CurrentEventName);
            var instance = (IHandler)Activator.CreateInstance(handler.GetType());
            _mainForm.AddEntry(eventProperty, instance);
            Hide();
        }

        private void comboBoxEvent_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadHandlers();
        }
        
        [CanBeNull]
        private IAgentConfig CurrentAgent
        {
            get
            {
                var eventParts = (string) comboBoxEvent?.SelectedItem;
                return _agentConfigs?.SingleOrDefault(x =>
                    x.GetType().Name == eventParts?.Split(' ')[1].TrimStart('(').TrimEnd(')'));
            }
        }
        
        private string CurrentEventName
        {
            get
            {
                var eventParts = (string) comboBoxEvent?.SelectedItem;

                return eventParts?.Split(' ')[0];
            }
        }
        
        [CanBeNull]
        private string CurrentHandlerName => (string) comboBoxHandler?.SelectedItem;
    }
}