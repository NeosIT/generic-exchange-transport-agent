namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class ExtractAttachmentConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtractAttachmentConfigForm));
            this.SettingsDataGridView = new System.Windows.Forms.DataGridView();
            this.SaveDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.SettingsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsDataGridView
            // 
            this.SettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.SettingsDataGridView, "SettingsDataGridView");
            this.SettingsDataGridView.Name = "SettingsDataGridView";
            // 
            // SaveDialogButton
            // 
            resources.ApplyResources(this.SaveDialogButton, "SaveDialogButton");
            this.SaveDialogButton.Name = "SaveDialogButton";
            this.SaveDialogButton.UseVisualStyleBackColor = true;
            this.SaveDialogButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // CancelDialogButton
            // 
            resources.ApplyResources(this.CancelDialogButton, "CancelDialogButton");
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // SettingsLabel
            // 
            resources.ApplyResources(this.SettingsLabel, "SettingsLabel");
            this.SettingsLabel.Name = "SettingsLabel";
            // 
            // ExtractAttachmentConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.SaveDialogButton);
            this.Controls.Add(this.SettingsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExtractAttachmentConfigForm";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SettingsDataGridView;
        private System.Windows.Forms.Button SaveDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Label SettingsLabel;
    }
}