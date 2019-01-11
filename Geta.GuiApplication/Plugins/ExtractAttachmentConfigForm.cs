using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class ConfigForm : Form
    {
        private readonly ExtractAttachmentHandler _handler;

        public ConfigForm(ExtractAttachmentHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            var list = (BindingList<KeyValuePair<string, string>>) SettingsDataGridView.DataSource;
            _handler.Settings = list.ToDictionary(x => x.Key, x => x.Value);
            Close();
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            var list = new BindingList<KeyValuePair<string, string>> { AllowEdit = true, AllowNew = true, AllowRemove = true, RaiseListChangedEvents = true, };

            foreach (var kvp in _handler.Settings)
            {
                list.Add(kvp);
            }

            SettingsDataGridView.DataSource = list;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Keys.Escape == keyData)
            {
                Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
