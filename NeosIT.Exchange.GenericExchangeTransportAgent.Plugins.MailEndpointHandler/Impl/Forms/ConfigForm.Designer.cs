namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.MailEndpointHandler.Impl.Forms
{
    partial class ConfigForm
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
            this.ButtonApply = new System.Windows.Forms.Button();
            this.CheckBoxDropMailAfterProcessing = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LabelEndpointAddress
            // 
            this.LabelEndpointAddress.AutoSize = true;
            this.LabelEndpointAddress.Location = new System.Drawing.Point(12, 9);
            this.LabelEndpointAddress.Name = "LabelEndpointAddress";
            this.LabelEndpointAddress.Size = new System.Drawing.Size(92, 13);
            this.LabelEndpointAddress.TabIndex = 0;
            this.LabelEndpointAddress.Text = "Endpoint address:";
            // 
            // TextBoxEndpointAddress
            // 
            this.TextBoxEndpointAddress.Location = new System.Drawing.Point(15, 26);
            this.TextBoxEndpointAddress.Name = "TextBoxEndpointAddress";
            this.TextBoxEndpointAddress.Size = new System.Drawing.Size(413, 20);
            this.TextBoxEndpointAddress.TabIndex = 1;
            // 
            // LabelServiceMail
            // 
            this.LabelServiceMail.AutoSize = true;
            this.LabelServiceMail.Location = new System.Drawing.Point(13, 53);
            this.LabelServiceMail.Name = "LabelServiceMail";
            this.LabelServiceMail.Size = new System.Drawing.Size(67, 13);
            this.LabelServiceMail.TabIndex = 2;
            this.LabelServiceMail.Text = "Service mail:";
            // 
            // TextBoxServiceMail
            // 
            this.TextBoxServiceMail.Location = new System.Drawing.Point(13, 70);
            this.TextBoxServiceMail.Name = "TextBoxServiceMail";
            this.TextBoxServiceMail.Size = new System.Drawing.Size(415, 20);
            this.TextBoxServiceMail.TabIndex = 3;
            // 
            // LabelHttpMethod
            // 
            this.LabelHttpMethod.AutoSize = true;
            this.LabelHttpMethod.Location = new System.Drawing.Point(13, 97);
            this.LabelHttpMethod.Name = "LabelHttpMethod";
            this.LabelHttpMethod.Size = new System.Drawing.Size(68, 13);
            this.LabelHttpMethod.TabIndex = 4;
            this.LabelHttpMethod.Text = "Http method:";
            // 
            // LabelDataContent
            // 
            this.LabelDataContent.AutoSize = true;
            this.LabelDataContent.Location = new System.Drawing.Point(233, 97);
            this.LabelDataContent.Name = "LabelDataContent";
            this.LabelDataContent.Size = new System.Drawing.Size(72, 13);
            this.LabelDataContent.TabIndex = 5;
            this.LabelDataContent.Text = "Data content:";
            // 
            // ComboBoxDataContent
            // 
            this.ComboBoxDataContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDataContent.FormattingEnabled = true;
            this.ComboBoxDataContent.Location = new System.Drawing.Point(236, 113);
            this.ComboBoxDataContent.Name = "ComboBoxDataContent";
            this.ComboBoxDataContent.Size = new System.Drawing.Size(192, 21);
            this.ComboBoxDataContent.TabIndex = 7;
            // 
            // ComboBoxHttpMethod
            // 
            this.ComboBoxHttpMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHttpMethod.FormattingEnabled = true;
            this.ComboBoxHttpMethod.Location = new System.Drawing.Point(16, 113);
            this.ComboBoxHttpMethod.Name = "ComboBoxHttpMethod";
            this.ComboBoxHttpMethod.Size = new System.Drawing.Size(192, 21);
            this.ComboBoxHttpMethod.TabIndex = 8;
            // 
            // LabelAttachmentFileExtensions
            // 
            this.LabelAttachmentFileExtensions.AutoSize = true;
            this.LabelAttachmentFileExtensions.Location = new System.Drawing.Point(16, 141);
            this.LabelAttachmentFileExtensions.Name = "LabelAttachmentFileExtensions";
            this.LabelAttachmentFileExtensions.Size = new System.Drawing.Size(179, 13);
            this.LabelAttachmentFileExtensions.TabIndex = 9;
            this.LabelAttachmentFileExtensions.Text = "Attachment file extensions (optional):";
            // 
            // LabelRecipientsHeader
            // 
            this.LabelRecipientsHeader.AutoSize = true;
            this.LabelRecipientsHeader.Location = new System.Drawing.Point(236, 141);
            this.LabelRecipientsHeader.Name = "LabelRecipientsHeader";
            this.LabelRecipientsHeader.Size = new System.Drawing.Size(142, 13);
            this.LabelRecipientsHeader.TabIndex = 10;
            this.LabelRecipientsHeader.Text = "Recipients header (optional):";
            // 
            // TextBoxAttachmentFileExtensions
            // 
            this.TextBoxAttachmentFileExtensions.Location = new System.Drawing.Point(15, 157);
            this.TextBoxAttachmentFileExtensions.Name = "TextBoxAttachmentFileExtensions";
            this.TextBoxAttachmentFileExtensions.Size = new System.Drawing.Size(193, 20);
            this.TextBoxAttachmentFileExtensions.TabIndex = 11;
            // 
            // TextBoxRecipientsHeader
            // 
            this.TextBoxRecipientsHeader.Location = new System.Drawing.Point(236, 157);
            this.TextBoxRecipientsHeader.Name = "TextBoxRecipientsHeader";
            this.TextBoxRecipientsHeader.Size = new System.Drawing.Size(192, 20);
            this.TextBoxRecipientsHeader.TabIndex = 12;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(353, 227);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 13;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(272, 227);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 23);
            this.ButtonApply.TabIndex = 14;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApplyClick);
            // 
            // CheckBoxDropMailAfterProcessing
            // 
            this.CheckBoxDropMailAfterProcessing.AutoSize = true;
            this.CheckBoxDropMailAfterProcessing.Location = new System.Drawing.Point(15, 183);
            this.CheckBoxDropMailAfterProcessing.Name = "CheckBoxDropMailAfterProcessing";
            this.CheckBoxDropMailAfterProcessing.Size = new System.Drawing.Size(148, 17);
            this.CheckBoxDropMailAfterProcessing.TabIndex = 16;
            this.CheckBoxDropMailAfterProcessing.Text = "Drop mail after processing";
            this.CheckBoxDropMailAfterProcessing.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 262);
            this.Controls.Add(this.CheckBoxDropMailAfterProcessing);
            this.Controls.Add(this.ButtonApply);
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
            this.Name = "ConfigForm";
            this.Text = "MailEndpointHandler configuration";
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
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.CheckBox CheckBoxDropMailAfterProcessing;
    }
}