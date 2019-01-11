using System;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Mail2NewsHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class Mail2NewsConfigForm : Form
    {
        private readonly Mail2NewsHandler _handler;

        public Mail2NewsConfigForm(Mail2NewsHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            _handler.ToSmtpAddress = TextBoxToSmtpAddress.Text;
            _handler.HeaderKey = TextBoxHeaderKey.Text;
            Close();
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            TextBoxToSmtpAddress.Text = _handler.ToSmtpAddress;
            TextBoxHeaderKey.Text = _handler.HeaderKey;
        }
    }
}
