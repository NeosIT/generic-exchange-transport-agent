namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class Mail2NewsConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mail2NewsConfigForm));
            this.LabelToSmtpAddress = new System.Windows.Forms.Label();
            this.TextBoxToSmtpAddress = new System.Windows.Forms.TextBox();
            this.LabelHeaderKey = new System.Windows.Forms.Label();
            this.TextBoxHeaderKey = new System.Windows.Forms.TextBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelToSmtpAddress
            // 
            resources.ApplyResources(this.LabelToSmtpAddress, "LabelToSmtpAddress");
            this.LabelToSmtpAddress.Name = "LabelToSmtpAddress";
            // 
            // TextBoxToSmtpAddress
            // 
            resources.ApplyResources(this.TextBoxToSmtpAddress, "TextBoxToSmtpAddress");
            this.TextBoxToSmtpAddress.Name = "TextBoxToSmtpAddress";
            // 
            // LabelHeaderKey
            // 
            resources.ApplyResources(this.LabelHeaderKey, "LabelHeaderKey");
            this.LabelHeaderKey.Name = "LabelHeaderKey";
            // 
            // TextBoxHeaderKey
            // 
            resources.ApplyResources(this.TextBoxHeaderKey, "TextBoxHeaderKey");
            this.TextBoxHeaderKey.Name = "TextBoxHeaderKey";
            // 
            // ButtonSave
            // 
            resources.ApplyResources(this.ButtonSave, "ButtonSave");
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSaveClick);
            // 
            // ButtonCancel
            // 
            resources.ApplyResources(this.ButtonCancel, "ButtonCancel");
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // Mail2NewsConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.TextBoxHeaderKey);
            this.Controls.Add(this.LabelHeaderKey);
            this.Controls.Add(this.TextBoxToSmtpAddress);
            this.Controls.Add(this.LabelToSmtpAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Mail2NewsConfigForm";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelToSmtpAddress;
        private System.Windows.Forms.TextBox TextBoxToSmtpAddress;
        private System.Windows.Forms.Label LabelHeaderKey;
        private System.Windows.Forms.TextBox TextBoxHeaderKey;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
    }
}