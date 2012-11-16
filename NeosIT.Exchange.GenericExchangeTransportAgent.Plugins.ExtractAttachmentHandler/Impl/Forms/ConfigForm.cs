namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl.Forms
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;

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
            var list = (BindingList<Setting>) SettingsDataGridView.DataSource;
            _handler.Settings = list.ToDictionary(x => x.Key, x => x.Value);
            Close();
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            var list = new BindingList<Setting> { AllowEdit = true, AllowNew = true, AllowRemove = true, RaiseListChangedEvents = true, };

            foreach (var kvp in _handler.Settings)
            {
                list.Add(new Setting { Key = kvp.Key, Value = kvp.Value, });
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
