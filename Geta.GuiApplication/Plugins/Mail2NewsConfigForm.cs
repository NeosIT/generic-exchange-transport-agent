using System;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Mail2NewsHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class Mail2NewsConfigForm : Form, IGenericConfigForm<Mail2NewsHandler>
    {
        public Mail2NewsHandler Handler { get; private set; }

        public void Init(Mail2NewsHandler handler)
        {
            Handler = handler;
        }

        public Mail2NewsConfigForm()
        {
            InitializeComponent();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            Handler.ToSmtpAddress = TextBoxToSmtpAddress.Text;
            Handler.HeaderKey = TextBoxHeaderKey.Text;
            Close();
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            TextBoxToSmtpAddress.Text = Handler.ToSmtpAddress;
            TextBoxHeaderKey.Text = Handler.HeaderKey;
        }
    }
}