using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Mail2NewsHandler.Impl.Forms
{
    public partial class ConfigForm : Form
    {
        private readonly Mail2NewsHandler _handler;

        public ConfigForm(Mail2NewsHandler handler)
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
