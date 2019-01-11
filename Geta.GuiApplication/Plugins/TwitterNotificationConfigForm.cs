using System;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class TwitterNotificationConfigForm : Form, IGenericConfigForm<TwitterNotificationHandler>
    {
        public TwitterNotificationHandler Handler { get; private set; }

        public void Init(TwitterNotificationHandler handler)
        {
            Handler = handler;
        }

        public TwitterNotificationConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            AccessTokenTextBox.Text = Handler.AccessToken;
            AccessTokenSecretTextBox.Text = Handler.AccessTokenSecret;
            ConsumerKeyTextBox.Text = Handler.ConsumerKey;
            ConsumerSecretTextBox.Text = Handler.ConsumerSecret;
        }

        private void ApplyDialogButtonClick(object sender, EventArgs e)
        {
            Handler.AccessToken = AccessTokenTextBox.Text;
            Handler.AccessTokenSecret = AccessTokenSecretTextBox.Text;
            Handler.ConsumerKey = ConsumerKeyTextBox.Text;
            Handler.ConsumerSecret = ConsumerSecretTextBox.Text;

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