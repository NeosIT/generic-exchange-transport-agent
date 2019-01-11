using System;
using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.MailEndpointHandler.Impl.Forms
{
    public partial class ConfigForm : Form
    {
        private readonly MailEndpointHandler _handler;

        public ConfigForm(MailEndpointHandler handler)
        {
            _handler = handler;
            InitializeComponent();
        }

        private void ConfigFormLoad(object sender, EventArgs e)
        {
            ComboBoxHttpMethod.DataSource = Enum.GetValues(typeof (HttpMethod));
            ComboBoxHttpMethod.SelectedItem = _handler.HttpMethod;
            ComboBoxDataContent.DataSource = Enum.GetValues(typeof (MailContent));
            ComboBoxDataContent.SelectedItem = _handler.MailContent;
            TextBoxEndpointAddress.Text = _handler.Endpoint;
            TextBoxServiceMail.Text = _handler.ServiceMail;
            TextBoxAttachmentFileExtensions.Text = _handler.AttachmentFileExtensions;
            TextBoxRecipientsHeader.Text = _handler.RecipientsHeader;
            CheckBoxDropMailAfterProcessing.Checked = _handler.DropMailAfterProcessing;
            TextBoxUploadFieldName.Text = _handler.UploadFieldName;
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            _handler.Endpoint = TextBoxEndpointAddress.Text;
            _handler.ServiceMail = TextBoxServiceMail.Text;
            _handler.AttachmentFileExtensions = TextBoxAttachmentFileExtensions.Text;
            _handler.RecipientsHeader = TextBoxRecipientsHeader.Text;
            _handler.HttpMethod = (HttpMethod) ComboBoxHttpMethod.SelectedItem;
            _handler.MailContent = (MailContent) ComboBoxDataContent.SelectedItem;
            _handler.DropMailAfterProcessing = CheckBoxDropMailAfterProcessing.Checked;
            _handler.UploadFieldName = TextBoxUploadFieldName.Text;
            Close();
        }
    }
}
