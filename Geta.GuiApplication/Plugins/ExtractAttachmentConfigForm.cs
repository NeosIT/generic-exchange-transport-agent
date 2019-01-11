using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class ExtractAttachmentConfigForm : Form, IGenericConfigForm<ExtractAttachmentHandler>
    {
        public ExtractAttachmentHandler Handler { get; private set; }

        public void Init(ExtractAttachmentHandler handler)
        {
            Handler = handler;
        }

        public ExtractAttachmentConfigForm()
        {
            InitializeComponent();
        }

        private void ApplyButtonClick(object sender, EventArgs e)
        {
            var list = (BindingList<KeyValuePair<string, string>>) SettingsDataGridView.DataSource;
            Handler.Settings = list.ToDictionary(x => x.Key, x => x.Value);
            Close();
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            var list = new BindingList<KeyValuePair<string, string>> { AllowEdit = true, AllowNew = true, AllowRemove = true, RaiseListChangedEvents = true, };

            foreach (var kvp in Handler.Settings)
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
