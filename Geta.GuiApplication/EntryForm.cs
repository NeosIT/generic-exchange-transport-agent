using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class EntryForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly List<IAgentConfig> _agentConfigs;
        private readonly Entry _initialEntry;
        private readonly IEnumerable<Type> _handlerTypes;
        private Type _currentHandlerFormType;

        public EntryForm(MainForm mainForm, List<IAgentConfig> agentConfigs, Entry entry = null)
        {
            _mainForm = mainForm;
            _agentConfigs = agentConfigs;

            InitializeComponent();

            _handlerTypes = AppDomain.CurrentDomain.GetAssemblies().GetHandlerTypes();
            _initialEntry = entry;
        }

        #region EventHandlers

        private void NewEntryForm_Load(object sender, EventArgs e) => Initialize();

        private void comboBoxEvent_SelectedValueChanged(object sender, EventArgs e) => LoadHandlers();

        private void buttonSave_Click(object sender, EventArgs e) => SaveAndHide();

        private void buttonConfigure_Click(object sender, EventArgs e) => ConfigureHandler();

        private void comboBoxHandler_SelectedIndexChanged(object sender, EventArgs e) => RefreshCanConfigure();

        #endregion

        #region Private Methods

        private void Initialize()
        {
            Text += _initialEntry == null ? "New Entry" : "Editing Entry";

            LoadEvents();

            if (_initialEntry != null)
            {
                var selectedEvent = comboBoxEvent.Items.Cast<string>()
                    .SingleOrDefault(
                        x => x == _initialEntry.EventNameFormatted);
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
            
            RefreshCanConfigure();
        }

        private void LoadHandlers()
        {
            comboBoxHandler.BeginUpdate();

            var handlers = new List<string>();

            foreach (var handler in _handlerTypes)
            {
                var existingHandle = CurrentAgentConfig?.GetHandler(CurrentEventName, handler.Name);
                if (existingHandle != null &&
                    _initialEntry?.Handler?.GetType().FullName != existingHandle.GetType().FullName)
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
                .SelectMany(x =>
                    x.GetPropertyInfosFromAgentConfigType()
                        .Select(p =>
                        {
                            Debug.Assert(p.DeclaringType != null, "p.DeclaringType != null");
                            return Entry.FormatEventName(p.Name, p.DeclaringType.Name);
                        }));

            var eventObjects = events.OrderBy(x => x).Cast<object>().ToArray();
            comboBoxEvent.Items.Clear();
            comboBoxEvent.Items.AddRange(eventObjects);
            comboBoxEvent.EndUpdate();
        }

        private void SaveAndHide()
        {
            // check for errors
            var errors = new[] {comboBoxEvent, comboBoxHandler}.Where(x => x.SelectedItem == null);

            if (errors.Any())
            {
                MessageBox.Show(null, "Form is invalid.", "Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (_initialEntry == null && _agentConfigs.All(x => x.GetType().Name != CurrentAgentConfigName))
            {
                // add a new agent config to the agent config list if
                // no config agent yet or
                // config agent has changed and the new target agent config type does not exist yet

                var agentType = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .GetAgentConfigTypes()
                    .Single(x => x.Name == CurrentAgentConfigName);
                _agentConfigs.Add((IAgentConfig) Activator.CreateInstance(agentType));
            }

            Debug.Assert(CurrentAgentConfig != null, "CurrentAgent != null");

            var existingEventProperty = _initialEntry?.AgentConfig.GetType().GetProperty(_initialEntry.EventName);
            var existingHandler =
                _initialEntry?.AgentConfig.GetHandler(_initialEntry.EventName, _initialEntry.Handler?.GetType().Name);
            var newEventProperty = CurrentAgentConfig.GetType().GetProperty(CurrentEventName);
            var newHandlerType = AppDomain.CurrentDomain.GetAssemblies().GetHandlerTypes()
                .Single(x => x.Name == CurrentHandlerName);
            var newHandler = (IHandler) Activator.CreateInstance(newHandlerType);

            Debug.Assert(newEventProperty != null, "eventProperty != null");

            if (_initialEntry != null && _initialEntry.AgentConfig != CurrentAgentConfig)
            {
                // when agent config changed
                _mainForm.RemoveEntry(existingEventProperty, _initialEntry.Handler?.GetType());
                _mainForm.AddEntry(newEventProperty, newHandler);
            }
            else if (_initialEntry != null && _initialEntry.EventName == CurrentEventName &&
                     _initialEntry.Handler?.GetType().Name == CurrentHandlerName)
            {
                // equal - do nothing
            }
            else
            {
                if (_initialEntry != null && _initialEntry.Handler?.GetType() != newHandlerType &&
                    _initialEntry.AgentConfig.GetType() == CurrentAgentConfig.GetType())
                {
                    // replace existing handler with new one
                    _mainForm.ReplaceEntry(CurrentAgentConfig.GetType().GetProperty(_initialEntry.EventName),
                        existingHandler, newHandler);
                }
                else
                {
                    // add new entry
                    _mainForm.AddEntry(newEventProperty, newHandler);
                }
            }


            Hide();
        }

        private void RefreshCanConfigure()
        {
            if (CurrentHandlerType == null)
            {
                buttonConfigure.Enabled = false;
                return;
            }
            
            _currentHandlerFormType = AppDomain.CurrentDomain.GetAssemblies().GetGenericForm(CurrentHandlerType);

            buttonConfigure.Enabled = _currentHandlerFormType != null;
        }
        
        private void ConfigureHandler()
        {
            if (_currentHandlerFormType == null) return;
            Debug.Assert(CurrentHandlerType != null, nameof(CurrentHandlerType) + " != null");
            
            var currentHandler = _initialEntry?.Handler ?? (IHandler)Activator.CreateInstance(CurrentHandlerType);
            
            var form = Activator.CreateInstance(_currentHandlerFormType);
            var initMethod = form.GetType().GetMethod(nameof(IGenericConfigForm<IHandler>.Init));
            var showMethod = form.GetType().GetMethod(nameof(IGenericConfigForm<IHandler>.Show), new Type[0]);

            Debug.Assert(initMethod != null, nameof(initMethod) + " != null");
            Debug.Assert(showMethod != null, nameof(showMethod) + " != null");
            
            initMethod.Invoke(form, new object[] {currentHandler});
            showMethod.Invoke(form, new object[] {});
        }

        #endregion

        #region Private Calculated Properties

        [CanBeNull]
        private IAgentConfig CurrentAgentConfig =>
            _agentConfigs?.SingleOrDefault(x => x.GetType().Name == CurrentAgentConfigName);

        private string CurrentAgentConfigName
        {
            get
            {
                var eventParts = (string) comboBoxEvent?.SelectedItem;
                return eventParts?.Split(' ')[1].TrimStart('(').TrimEnd(')');
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

        [CanBeNull] private string CurrentHandlerName => (string) comboBoxHandler?.SelectedItem;

        [CanBeNull]
        private Type CurrentHandlerType => _handlerTypes?.SingleOrDefault(x => x.Name == CurrentHandlerName);

        #endregion
    }
}