namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class TwitterNotificationConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitterNotificationConfigForm));
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenSecretLabel = new System.Windows.Forms.Label();
            this.AccessTokenSecretTextBox = new System.Windows.Forms.TextBox();
            this.ConsumerKeyLabel = new System.Windows.Forms.Label();
            this.ConsumerKeyTextBox = new System.Windows.Forms.TextBox();
            this.ConsumerSecretLabel = new System.Windows.Forms.Label();
            this.ConsumerSecretTextBox = new System.Windows.Forms.TextBox();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.SaveDialogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccessTokenLabel
            // 
            resources.ApplyResources(this.AccessTokenLabel, "AccessTokenLabel");
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            // 
            // AccessTokenTextBox
            // 
            resources.ApplyResources(this.AccessTokenTextBox, "AccessTokenTextBox");
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            // 
            // AccessTokenSecretLabel
            // 
            resources.ApplyResources(this.AccessTokenSecretLabel, "AccessTokenSecretLabel");
            this.AccessTokenSecretLabel.Name = "AccessTokenSecretLabel";
            // 
            // AccessTokenSecretTextBox
            // 
            resources.ApplyResources(this.AccessTokenSecretTextBox, "AccessTokenSecretTextBox");
            this.AccessTokenSecretTextBox.Name = "AccessTokenSecretTextBox";
            // 
            // ConsumerKeyLabel
            // 
            resources.ApplyResources(this.ConsumerKeyLabel, "ConsumerKeyLabel");
            this.ConsumerKeyLabel.Name = "ConsumerKeyLabel";
            // 
            // ConsumerKeyTextBox
            // 
            resources.ApplyResources(this.ConsumerKeyTextBox, "ConsumerKeyTextBox");
            this.ConsumerKeyTextBox.Name = "ConsumerKeyTextBox";
            // 
            // ConsumerSecretLabel
            // 
            resources.ApplyResources(this.ConsumerSecretLabel, "ConsumerSecretLabel");
            this.ConsumerSecretLabel.Name = "ConsumerSecretLabel";
            // 
            // ConsumerSecretTextBox
            // 
            resources.ApplyResources(this.ConsumerSecretTextBox, "ConsumerSecretTextBox");
            this.ConsumerSecretTextBox.Name = "ConsumerSecretTextBox";
            // 
            // CancelDialogButton
            // 
            resources.ApplyResources(this.CancelDialogButton, "CancelDialogButton");
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // SaveDialogButton
            // 
            resources.ApplyResources(this.SaveDialogButton, "SaveDialogButton");
            this.SaveDialogButton.Name = "SaveDialogButton";
            this.SaveDialogButton.UseVisualStyleBackColor = true;
            this.SaveDialogButton.Click += new System.EventHandler(this.SaveDialogButtonClick);
            // 
            // TwitterNotificationConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveDialogButton);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.ConsumerSecretTextBox);
            this.Controls.Add(this.ConsumerSecretLabel);
            this.Controls.Add(this.ConsumerKeyTextBox);
            this.Controls.Add(this.ConsumerKeyLabel);
            this.Controls.Add(this.AccessTokenSecretTextBox);
            this.Controls.Add(this.AccessTokenSecretLabel);
            this.Controls.Add(this.AccessTokenTextBox);
            this.Controls.Add(this.AccessTokenLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TwitterNotificationConfigForm";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AccessTokenLabel;
        private System.Windows.Forms.TextBox AccessTokenTextBox;
        private System.Windows.Forms.Label AccessTokenSecretLabel;
        private System.Windows.Forms.TextBox AccessTokenSecretTextBox;
        private System.Windows.Forms.Label ConsumerKeyLabel;
        private System.Windows.Forms.TextBox ConsumerKeyTextBox;
        private System.Windows.Forms.Label ConsumerSecretLabel;
        private System.Windows.Forms.TextBox ConsumerSecretTextBox;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button SaveDialogButton;
    }
}