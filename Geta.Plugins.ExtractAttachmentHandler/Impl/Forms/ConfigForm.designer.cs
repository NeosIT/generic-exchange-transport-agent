namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExtractAttachmentHandler.Impl.Forms
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
            this.SettingsDataGridView = new System.Windows.Forms.DataGridView();
            this.ApplyDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.SettingsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsDataGridView
            // 
            this.SettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SettingsDataGridView.Location = new System.Drawing.Point(13, 29);
            this.SettingsDataGridView.Name = "SettingsDataGridView";
            this.SettingsDataGridView.Size = new System.Drawing.Size(360, 154);
            this.SettingsDataGridView.TabIndex = 0;
            // 
            // ApplyDialogButton
            // 
            this.ApplyDialogButton.Location = new System.Drawing.Point(216, 227);
            this.ApplyDialogButton.Name = "ApplyDialogButton";
            this.ApplyDialogButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyDialogButton.TabIndex = 1;
            this.ApplyDialogButton.Text = "Apply";
            this.ApplyDialogButton.UseVisualStyleBackColor = true;
            this.ApplyDialogButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Location = new System.Drawing.Point(297, 227);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 2;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Location = new System.Drawing.Point(13, 13);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(48, 13);
            this.SettingsLabel.TabIndex = 3;
            this.SettingsLabel.Text = "Settings:";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.ApplyDialogButton);
            this.Controls.Add(this.SettingsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "ConfigForm";
            this.Text = "ExtractAttachmentHandler configuration";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SettingsDataGridView;
        private System.Windows.Forms.Button ApplyDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Label SettingsLabel;
    }
}