using System;
using System.Windows.Forms;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.MailEndpointHandler.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    public partial class MailEndpointConfigForm : Form, IGenericConfigForm<MailEndpointHandler>
    {
        public MailEndpointHandler Handler { get; private set; }

        public void Init(MailEndpointHandler handler)
        {
            Handler = handler;
        }

        public MailEndpointConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            ComboBoxHttpMethod.DataSource = Enum.GetValues(typeof(HttpMethod));
            ComboBoxHttpMethod.SelectedItem = Handler.HttpMethod;
            ComboBoxDataContent.DataSource = Enum.GetValues(typeof(MailContent));
            ComboBoxDataContent.SelectedItem = Handler.MailContent;
            TextBoxEndpointAddress.Text = Handler.Endpoint;
            TextBoxServiceMail.Text = Handler.ServiceMail;
            TextBoxAttachmentFileExtensions.Text = Handler.AttachmentFileExtensions;
            TextBoxRecipientsHeader.Text = Handler.RecipientsHeader;
            CheckBoxDropMailAfterProcessing.Checked = Handler.DropMailAfterProcessing;
            TextBoxUploadFieldName.Text = Handler.UploadFieldName;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            Handler.Endpoint = TextBoxEndpointAddress.Text;
            Handler.ServiceMail = TextBoxServiceMail.Text;
            Handler.AttachmentFileExtensions = TextBoxAttachmentFileExtensions.Text;
            Handler.RecipientsHeader = TextBoxRecipientsHeader.Text;
            Handler.HttpMethod = (HttpMethod) ComboBoxHttpMethod.SelectedItem;
            Handler.MailContent = (MailContent) ComboBoxDataContent.SelectedItem;
            Handler.DropMailAfterProcessing = CheckBoxDropMailAfterProcessing.Checked;
            Handler.UploadFieldName = TextBoxUploadFieldName.Text;
            Close();
        }
    }
}