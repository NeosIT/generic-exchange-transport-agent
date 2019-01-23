namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class MailEndpointConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailEndpointConfigForm));
            this.LabelEndpointAddress = new System.Windows.Forms.Label();
            this.TextBoxEndpointAddress = new System.Windows.Forms.TextBox();
            this.LabelServiceMail = new System.Windows.Forms.Label();
            this.TextBoxServiceMail = new System.Windows.Forms.TextBox();
            this.LabelHttpMethod = new System.Windows.Forms.Label();
            this.LabelDataContent = new System.Windows.Forms.Label();
            this.ComboBoxDataContent = new System.Windows.Forms.ComboBox();
            this.ComboBoxHttpMethod = new System.Windows.Forms.ComboBox();
            this.LabelAttachmentFileExtensions = new System.Windows.Forms.Label();
            this.LabelRecipientsHeader = new System.Windows.Forms.Label();
            this.TextBoxAttachmentFileExtensions = new System.Windows.Forms.TextBox();
            this.TextBoxRecipientsHeader = new System.Windows.Forms.TextBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.CheckBoxDropMailAfterProcessing = new System.Windows.Forms.CheckBox();
            this.LabelUploadFieldName = new System.Windows.Forms.Label();
            this.TextBoxUploadFieldName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelEndpointAddress
            // 
            resources.ApplyResources(this.LabelEndpointAddress, "LabelEndpointAddress");
            this.LabelEndpointAddress.Name = "LabelEndpointAddress";
            // 
            // TextBoxEndpointAddress
            // 
            resources.ApplyResources(this.TextBoxEndpointAddress, "TextBoxEndpointAddress");
            this.TextBoxEndpointAddress.Name = "TextBoxEndpointAddress";
            // 
            // LabelServiceMail
            // 
            resources.ApplyResources(this.LabelServiceMail, "LabelServiceMail");
            this.LabelServiceMail.Name = "LabelServiceMail";
            // 
            // TextBoxServiceMail
            // 
            resources.ApplyResources(this.TextBoxServiceMail, "TextBoxServiceMail");
            this.TextBoxServiceMail.Name = "TextBoxServiceMail";
            // 
            // LabelHttpMethod
            // 
            resources.ApplyResources(this.LabelHttpMethod, "LabelHttpMethod");
            this.LabelHttpMethod.Name = "LabelHttpMethod";
            // 
            // LabelDataContent
            // 
            resources.ApplyResources(this.LabelDataContent, "LabelDataContent");
            this.LabelDataContent.Name = "LabelDataContent";
            // 
            // ComboBoxDataContent
            // 
            resources.ApplyResources(this.ComboBoxDataContent, "ComboBoxDataContent");
            this.ComboBoxDataContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDataContent.FormattingEnabled = true;
            this.ComboBoxDataContent.Name = "ComboBoxDataContent";
            // 
            // ComboBoxHttpMethod
            // 
            resources.ApplyResources(this.ComboBoxHttpMethod, "ComboBoxHttpMethod");
            this.ComboBoxHttpMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHttpMethod.FormattingEnabled = true;
            this.ComboBoxHttpMethod.Name = "ComboBoxHttpMethod";
            // 
            // LabelAttachmentFileExtensions
            // 
            resources.ApplyResources(this.LabelAttachmentFileExtensions, "LabelAttachmentFileExtensions");
            this.LabelAttachmentFileExtensions.Name = "LabelAttachmentFileExtensions";
            // 
            // LabelRecipientsHeader
            // 
            resources.ApplyResources(this.LabelRecipientsHeader, "LabelRecipientsHeader");
            this.LabelRecipientsHeader.Name = "LabelRecipientsHeader";
            // 
            // TextBoxAttachmentFileExtensions
            // 
            resources.ApplyResources(this.TextBoxAttachmentFileExtensions, "TextBoxAttachmentFileExtensions");
            this.TextBoxAttachmentFileExtensions.Name = "TextBoxAttachmentFileExtensions";
            // 
            // TextBoxRecipientsHeader
            // 
            resources.ApplyResources(this.TextBoxRecipientsHeader, "TextBoxRecipientsHeader");
            this.TextBoxRecipientsHeader.Name = "TextBoxRecipientsHeader";
            // 
            // ButtonCancel
            // 
            resources.ApplyResources(this.ButtonCancel, "ButtonCancel");
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // ButtonSave
            // 
            resources.ApplyResources(this.ButtonSave, "ButtonSave");
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSaveClick);
            // 
            // CheckBoxDropMailAfterProcessing
            // 
            resources.ApplyResources(this.CheckBoxDropMailAfterProcessing, "CheckBoxDropMailAfterProcessing");
            this.CheckBoxDropMailAfterProcessing.Name = "CheckBoxDropMailAfterProcessing";
            this.CheckBoxDropMailAfterProcessing.UseVisualStyleBackColor = true;
            // 
            // LabelUploadFieldName
            // 
            resources.ApplyResources(this.LabelUploadFieldName, "LabelUploadFieldName");
            this.LabelUploadFieldName.Name = "LabelUploadFieldName";
            // 
            // TextBoxUploadFieldName
            // 
            resources.ApplyResources(this.TextBoxUploadFieldName, "TextBoxUploadFieldName");
            this.TextBoxUploadFieldName.Name = "TextBoxUploadFieldName";
            // 
            // MailEndpointConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxUploadFieldName);
            this.Controls.Add(this.LabelUploadFieldName);
            this.Controls.Add(this.CheckBoxDropMailAfterProcessing);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TextBoxRecipientsHeader);
            this.Controls.Add(this.TextBoxAttachmentFileExtensions);
            this.Controls.Add(this.LabelRecipientsHeader);
            this.Controls.Add(this.LabelAttachmentFileExtensions);
            this.Controls.Add(this.ComboBoxHttpMethod);
            this.Controls.Add(this.ComboBoxDataContent);
            this.Controls.Add(this.LabelDataContent);
            this.Controls.Add(this.LabelHttpMethod);
            this.Controls.Add(this.TextBoxServiceMail);
            this.Controls.Add(this.LabelServiceMail);
            this.Controls.Add(this.TextBoxEndpointAddress);
            this.Controls.Add(this.LabelEndpointAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MailEndpointConfigForm";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelEndpointAddress;
        private System.Windows.Forms.TextBox TextBoxEndpointAddress;
        private System.Windows.Forms.Label LabelServiceMail;
        private System.Windows.Forms.TextBox TextBoxServiceMail;
        private System.Windows.Forms.Label LabelHttpMethod;
        private System.Windows.Forms.Label LabelDataContent;
        private System.Windows.Forms.ComboBox ComboBoxDataContent;
        private System.Windows.Forms.ComboBox ComboBoxHttpMethod;
        private System.Windows.Forms.Label LabelAttachmentFileExtensions;
        private System.Windows.Forms.Label LabelRecipientsHeader;
        private System.Windows.Forms.TextBox TextBoxAttachmentFileExtensions;
        private System.Windows.Forms.TextBox TextBoxRecipientsHeader;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.CheckBox CheckBoxDropMailAfterProcessing;
        private System.Windows.Forms.Label LabelUploadFieldName;
        private System.Windows.Forms.TextBox TextBoxUploadFieldName;
    }
}