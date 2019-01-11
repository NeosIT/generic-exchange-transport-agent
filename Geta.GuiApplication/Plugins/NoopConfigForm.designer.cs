namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class NoopConfigForm
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
            this.NoConfigurationAvailableLabel = new System.Windows.Forms.Label();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NoConfigurationAvailableLabel
            // 
            this.NoConfigurationAvailableLabel.AutoSize = true;
            this.NoConfigurationAvailableLabel.Location = new System.Drawing.Point(12, 9);
            this.NoConfigurationAvailableLabel.Name = "NoConfigurationAvailableLabel";
            this.NoConfigurationAvailableLabel.Size = new System.Drawing.Size(139, 13);
            this.NoConfigurationAvailableLabel.TabIndex = 0;
            this.NoConfigurationAvailableLabel.Text = "No configuration available...";
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Location = new System.Drawing.Point(197, 52);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 1;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 87);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.NoConfigurationAvailableLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(300, 125);
            this.MinimumSize = new System.Drawing.Size(300, 125);
            this.Name = "ConfigForm";
            this.Text = "NoopHandler configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NoConfigurationAvailableLabel;
        private System.Windows.Forms.Button CancelDialogButton;
    }
}