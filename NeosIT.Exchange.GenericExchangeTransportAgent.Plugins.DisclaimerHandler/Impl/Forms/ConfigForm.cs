using System;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DisclaimerHandler.Impl.Forms
{
    public partial class ConfigForm : Form
    {
        private readonly DisclaimerHandler _handler;

        public ConfigForm(DisclaimerHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            DisclaimerTextTextBox.Text = _handler.Text ?? string.Empty;
            //DisclaimerRtfRichTextEditor.Rtf = _handler.Rtf ?? string.Empty;
            DisclaimerHtmlHtmlEditor.BodyHtml = _handler.Html ?? string.Empty;
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyDialogButtonClick(object sender, EventArgs e)
        {
            _handler.Text = DisclaimerTextTextBox.Text ?? string.Empty;
            //_handler.Rtf = DisclaimerRtfRichTextEditor.Rtf ?? string.Empty;
            _handler.Html = DisclaimerHtmlHtmlEditor.BodyHtml ?? string.Empty;
            Close();
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
