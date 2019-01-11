namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.TwitterNotificationHandler.Impl.Forms
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
            this.AccessTokenLabel = new System.Windows.Forms.Label();
            this.AccessTokenTextBox = new System.Windows.Forms.TextBox();
            this.AccessTokenSecretLabel = new System.Windows.Forms.Label();
            this.AccessTokenSecretTextBox = new System.Windows.Forms.TextBox();
            this.ConsumerKeyLabel = new System.Windows.Forms.Label();
            this.ConsumerKeyTextBox = new System.Windows.Forms.TextBox();
            this.ConsumerSecretLabel = new System.Windows.Forms.Label();
            this.ConsumerSecretTextBox = new System.Windows.Forms.TextBox();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.ApplyDialogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccessTokenLabel
            // 
            this.AccessTokenLabel.AutoSize = true;
            this.AccessTokenLabel.Location = new System.Drawing.Point(13, 13);
            this.AccessTokenLabel.Name = "AccessTokenLabel";
            this.AccessTokenLabel.Size = new System.Drawing.Size(76, 13);
            this.AccessTokenLabel.TabIndex = 0;
            this.AccessTokenLabel.Text = "AccessToken:";
            // 
            // AccessTokenTextBox
            // 
            this.AccessTokenTextBox.Location = new System.Drawing.Point(16, 30);
            this.AccessTokenTextBox.Name = "AccessTokenTextBox";
            this.AccessTokenTextBox.Size = new System.Drawing.Size(177, 20);
            this.AccessTokenTextBox.TabIndex = 1;
            // 
            // AccessTokenSecretLabel
            // 
            this.AccessTokenSecretLabel.AutoSize = true;
            this.AccessTokenSecretLabel.Location = new System.Drawing.Point(196, 13);
            this.AccessTokenSecretLabel.Name = "AccessTokenSecretLabel";
            this.AccessTokenSecretLabel.Size = new System.Drawing.Size(107, 13);
            this.AccessTokenSecretLabel.TabIndex = 2;
            this.AccessTokenSecretLabel.Text = "AccessTokenSecret:";
            // 
            // AccessTokenSecretTextBox
            // 
            this.AccessTokenSecretTextBox.Location = new System.Drawing.Point(199, 30);
            this.AccessTokenSecretTextBox.Name = "AccessTokenSecretTextBox";
            this.AccessTokenSecretTextBox.Size = new System.Drawing.Size(177, 20);
            this.AccessTokenSecretTextBox.TabIndex = 3;
            // 
            // ConsumerKeyLabel
            // 
            this.ConsumerKeyLabel.AutoSize = true;
            this.ConsumerKeyLabel.Location = new System.Drawing.Point(13, 53);
            this.ConsumerKeyLabel.Name = "ConsumerKeyLabel";
            this.ConsumerKeyLabel.Size = new System.Drawing.Size(75, 13);
            this.ConsumerKeyLabel.TabIndex = 4;
            this.ConsumerKeyLabel.Text = "ConsumerKey:";
            // 
            // ConsumerKeyTextBox
            // 
            this.ConsumerKeyTextBox.Location = new System.Drawing.Point(16, 69);
            this.ConsumerKeyTextBox.Name = "ConsumerKeyTextBox";
            this.ConsumerKeyTextBox.Size = new System.Drawing.Size(177, 20);
            this.ConsumerKeyTextBox.TabIndex = 5;
            // 
            // ConsumerSecretLabel
            // 
            this.ConsumerSecretLabel.AutoSize = true;
            this.ConsumerSecretLabel.Location = new System.Drawing.Point(196, 53);
            this.ConsumerSecretLabel.Name = "ConsumerSecretLabel";
            this.ConsumerSecretLabel.Size = new System.Drawing.Size(88, 13);
            this.ConsumerSecretLabel.TabIndex = 6;
            this.ConsumerSecretLabel.Text = "ConsumerSecret:";
            // 
            // ConsumerSecretTextBox
            // 
            this.ConsumerSecretTextBox.Location = new System.Drawing.Point(199, 69);
            this.ConsumerSecretTextBox.Name = "ConsumerSecretTextBox";
            this.ConsumerSecretTextBox.Size = new System.Drawing.Size(177, 20);
            this.ConsumerSecretTextBox.TabIndex = 7;
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Location = new System.Drawing.Point(303, 120);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 8;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // ApplyDialogButton
            // 
            this.ApplyDialogButton.Location = new System.Drawing.Point(222, 120);
            this.ApplyDialogButton.Name = "ApplyDialogButton";
            this.ApplyDialogButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyDialogButton.TabIndex = 9;
            this.ApplyDialogButton.Text = "Apply";
            this.ApplyDialogButton.UseVisualStyleBackColor = true;
            this.ApplyDialogButton.Click += new System.EventHandler(this.ApplyDialogButtonClick);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 155);
            this.Controls.Add(this.ApplyDialogButton);
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
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
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
        private System.Windows.Forms.Button ApplyDialogButton;
    }
}