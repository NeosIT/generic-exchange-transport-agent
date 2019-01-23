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
            this.LabelToSmtpAddress = new System.Windows.Forms.Label();
            this.TextBoxToSmtpAddress = new System.Windows.Forms.TextBox();
            this.LabelHeaderKey = new System.Windows.Forms.Label();
            this.TextBoxHeaderKey = new System.Windows.Forms.TextBox();
            this.ButtonApply = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelToSmtpAddress
            // 
            this.LabelToSmtpAddress.AutoSize = true;
            this.LabelToSmtpAddress.Location = new System.Drawing.Point(12, 9);
            this.LabelToSmtpAddress.Name = "LabelToSmtpAddress";
            this.LabelToSmtpAddress.Size = new System.Drawing.Size(85, 13);
            this.LabelToSmtpAddress.TabIndex = 0;
            this.LabelToSmtpAddress.Text = "ToSmtpAddress:";
            // 
            // TextBoxToSmtpAddress
            // 
            this.TextBoxToSmtpAddress.Location = new System.Drawing.Point(15, 26);
            this.TextBoxToSmtpAddress.Name = "TextBoxToSmtpAddress";
            this.TextBoxToSmtpAddress.Size = new System.Drawing.Size(214, 20);
            this.TextBoxToSmtpAddress.TabIndex = 1;
            // 
            // LabelHeaderKey
            // 
            this.LabelHeaderKey.AutoSize = true;
            this.LabelHeaderKey.Location = new System.Drawing.Point(13, 53);
            this.LabelHeaderKey.Name = "LabelHeaderKey";
            this.LabelHeaderKey.Size = new System.Drawing.Size(65, 13);
            this.LabelHeaderKey.TabIndex = 2;
            this.LabelHeaderKey.Text = "Header key:";
            // 
            // TextBoxHeaderKey
            // 
            this.TextBoxHeaderKey.Location = new System.Drawing.Point(13, 70);
            this.TextBoxHeaderKey.Name = "TextBoxHeaderKey";
            this.TextBoxHeaderKey.Size = new System.Drawing.Size(216, 20);
            this.TextBoxHeaderKey.TabIndex = 3;
            // 
            // ButtonApply
            // 
            this.ButtonApply.Location = new System.Drawing.Point(73, 118);
            this.ButtonApply.Name = "ButtonApply";
            this.ButtonApply.Size = new System.Drawing.Size(75, 23);
            this.ButtonApply.TabIndex = 4;
            this.ButtonApply.Text = "Apply";
            this.ButtonApply.UseVisualStyleBackColor = true;
            this.ButtonApply.Click += new System.EventHandler(this.ButtonApplyClick);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(154, 118);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 157);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonApply);
            this.Controls.Add(this.TextBoxHeaderKey);
            this.Controls.Add(this.LabelHeaderKey);
            this.Controls.Add(this.TextBoxToSmtpAddress);
            this.Controls.Add(this.LabelToSmtpAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Mail2NewsConfigForm";
            this.Text = "Mail2NewsHandler configuration";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelToSmtpAddress;
        private System.Windows.Forms.TextBox TextBoxToSmtpAddress;
        private System.Windows.Forms.Label LabelHeaderKey;
        private System.Windows.Forms.TextBox TextBoxHeaderKey;
        private System.Windows.Forms.Button ButtonApply;
        private System.Windows.Forms.Button ButtonCancel;
    }
}