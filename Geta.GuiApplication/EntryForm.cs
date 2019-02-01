using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Extensions;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Models;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Extensions;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public partial class EntryForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly List<IAgentConfig> _agentConfigs;
        private readonly Entry _initialEntry;
        private readonly IEnumerable<Type> _handlerTypes;
        private Type _currentHandlerFormType;
        private IHandler _currentHandler;

        private readonly ColorTag _andTag;
        private readonly ColorTag _orTag;

        public EntryForm(MainForm mainForm, List<IAgentConfig> agentConfigs, Entry entry = null)
        {
            _mainForm = mainForm;
            _agentConfigs = agentConfigs;

            InitializeComponent();

            _handlerTypes = AppDomain.CurrentDomain.GetAssemblies().GetHandlerTypes();
            _initialEntry = entry;

            _andTag = new ColorTag("AND", 0x90b763/*E56262*/);
            _orTag = new ColorTag("OR", 0x6E9AC1);
            //_xorTag = new Controls.ColorTag("XOR", 0x8EBA48);//B360C1
            buttonAnd.BackColor = _andTag.Color;
            buttonOr.BackColor = _orTag.Color;
        }

        #region EventHandlers

        private void NewEntryForm_Load(object sender, EventArgs e) => Initialize();


        private void comboBoxEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHandlers();
            
            buttonSave.Enabled = comboBoxHandler.SelectedItem != null;
        }

        private void comboBoxHandler_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCanConfigure();

            Debug.Assert(CurrentHandlerType != null, nameof(CurrentHandlerType) + " != null");
            _currentHandler = (IHandler) Activator.CreateInstance(CurrentHandlerType);
        }

        private void buttonSave_Click(object sender, EventArgs e) => SaveAndHide();

        private void buttonConfigure_Click(object sender, EventArgs e) => ConfigureHandler();

        private void buttonAnd_Click(object sender, EventArgs e) => AddFilter(_andTag);

        private void buttonOr_Click(object sender, EventArgs e) => AddFilter(_orTag);

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
                    .SingleOrDefault(x => x == _initialEntry.Handler.GetType().Name);
                comboBoxHandler.SelectedItem = selectedHandler;
            
                _currentHandler = _initialEntry.Handler;
            }
            else
            {
                comboBoxEvent.SelectedItem = comboBoxEvent.Items[0];

                LoadHandlers();
            }
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

            if (comboBoxHandler.Items.Count > 0)
            {
                comboBoxHandler.SelectedIndex = 0;
            }
            else
            {
                RefreshCanConfigure();
            }
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

            Debug.Assert(newEventProperty != null, "eventProperty != null");

            if (_initialEntry != null && _initialEntry.AgentConfig != CurrentAgentConfig)
            {
                // when agent config changed
                _mainForm.RemoveEntry(existingEventProperty, _initialEntry.Handler?.GetType());
                _mainForm.AddEntry(newEventProperty, _currentHandler);
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
                        existingHandler, _currentHandler);
                }
                else
                {
                    // add new entry
                    _mainForm.AddEntry(newEventProperty, _currentHandler);
                }
            }


            Hide();
        }
        
        private void ConfigureHandler()
        {
            if (_currentHandlerFormType == null) return;
            Debug.Assert(CurrentHandlerType != null, nameof(CurrentHandlerType) + " != null");
            
            var form = (Form)Activator.CreateInstance(_currentHandlerFormType);
            
            // now initialize the form using reflection
            // reflection is required as we cannot cast the object to IGenericConfigForm<IHandler>
            var initMethod = form.GetType().GetMethod(nameof(IGenericConfigForm<IHandler>.Init));

            Debug.Assert(initMethod != null, nameof(initMethod) + " != null");
            
            initMethod.Invoke(form, new object[] {_currentHandler});
            form.Show();
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

        private void AddFilter(ColorTag tag)
        {
            string text = query.Text;
            query.Text = string.Empty;
            filters.AddAtSelection(new FilterCondition(text), tag);
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
