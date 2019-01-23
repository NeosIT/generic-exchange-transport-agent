using System;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DisclaimerHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class DisclaimerConfigForm : Form, IGenericConfigForm<DisclaimerHandler>
    {
        public DisclaimerHandler Handler { get; private set; }
        
        public void Init(DisclaimerHandler handler)
        {
            Handler = handler;
        }

        public DisclaimerConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            DisclaimerTextTextBox.Text = Handler.Text ?? string.Empty;
            //DisclaimerRtfRichTextEditor.Rtf = _handler.Rtf ?? string.Empty;
            DisclaimerHtmlHtmlEditor.BodyHtml = Handler.Html ?? string.Empty;
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveDialogButtonClick(object sender, EventArgs e)
        {
            Handler.Text = DisclaimerTextTextBox.Text ?? string.Empty;
            //_handler.Rtf = DisclaimerRtfRichTextEditor.Rtf ?? string.Empty;
            Handler.Html = DisclaimerHtmlHtmlEditor.BodyHtml ?? string.Empty;
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
