using System;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class NoopConfigForm : Form
    {
        public NoopConfigForm()
        {
            InitializeComponent();
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
