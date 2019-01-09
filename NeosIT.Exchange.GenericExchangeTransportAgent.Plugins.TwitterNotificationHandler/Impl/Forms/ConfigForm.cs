using System;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl.Forms
{
    public partial class ConfigForm : Form
    {
        private readonly TwitterNotificationHandler _handler;

        public ConfigForm(TwitterNotificationHandler handler)
        {
            InitializeComponent();
            _handler = handler;
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            AccessTokenTextBox.Text = _handler.AccessToken;
            AccessTokenSecretTextBox.Text = _handler.AccessTokenSecret;
            ConsumerKeyTextBox.Text = _handler.ConsumerKey;
            ConsumerSecretTextBox.Text = _handler.ConsumerSecret;
        }

        private void ApplyDialogButtonClick(object sender, EventArgs e)
        {
            _handler.AccessToken = AccessTokenTextBox.Text;
            _handler.AccessTokenSecret = AccessTokenSecretTextBox.Text;
            _handler.ConsumerKey = ConsumerKeyTextBox.Text;
            _handler.ConsumerSecret = ConsumerSecretTextBox.Text;

            Close();
        }

        private void CancelDialogButtonClick(object sender, EventArgs e)
        {
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
