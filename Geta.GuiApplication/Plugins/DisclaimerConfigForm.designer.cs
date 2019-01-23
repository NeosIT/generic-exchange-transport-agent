using System.Windows.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class DisclaimerConfigForm
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
            this.ApplyDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.DisclaimerTabControl = new System.Windows.Forms.TabControl();
            this.DisclaimerTextTabPage = new System.Windows.Forms.TabPage();
            this.DisclaimerTextTextBox = new System.Windows.Forms.TextBox();
            this.DisclaimerRtfTabPage = new System.Windows.Forms.TabPage();
            this.DisclaimerHtmlTabPage = new System.Windows.Forms.TabPage();
            this.DisclaimerHtmlHtmlEditor = new MSDN.Html.Editor.HtmlEditorControl();
            this.DisclaimerRtfRichTextBox = new System.Windows.Forms.RichTextBox();
            this.DisclaimerTabControl.SuspendLayout();
            this.DisclaimerTextTabPage.SuspendLayout();
            this.DisclaimerRtfTabPage.SuspendLayout();
            this.DisclaimerHtmlTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplyDialogButton
            // 
            this.ApplyDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyDialogButton.Location = new System.Drawing.Point(508, 533);
            this.ApplyDialogButton.Name = "ApplyDialogButton";
            this.ApplyDialogButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyDialogButton.TabIndex = 4;
            this.ApplyDialogButton.Text = "Apply";
            this.ApplyDialogButton.UseVisualStyleBackColor = true;
            this.ApplyDialogButton.Click += new System.EventHandler(this.ApplyDialogButtonClick);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDialogButton.Location = new System.Drawing.Point(589, 533);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 5;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // DisclaimerTabControl
            // 
            this.DisclaimerTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisclaimerTabControl.Controls.Add(this.DisclaimerTextTabPage);
            this.DisclaimerTabControl.Controls.Add(this.DisclaimerRtfTabPage);
            this.DisclaimerTabControl.Controls.Add(this.DisclaimerHtmlTabPage);
            this.DisclaimerTabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DisclaimerTabControl.Location = new System.Drawing.Point(12, 12);
            this.DisclaimerTabControl.Name = "DisclaimerTabControl";
            this.DisclaimerTabControl.SelectedIndex = 0;
            this.DisclaimerTabControl.Size = new System.Drawing.Size(652, 515);
            this.DisclaimerTabControl.TabIndex = 6;
            // 
            // DisclaimerTextTabPage
            // 
            this.DisclaimerTextTabPage.Controls.Add(this.DisclaimerTextTextBox);
            this.DisclaimerTextTabPage.Location = new System.Drawing.Point(4, 22);
            this.DisclaimerTextTabPage.Name = "DisclaimerTextTabPage";
            this.DisclaimerTextTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DisclaimerTextTabPage.Size = new System.Drawing.Size(644, 489);
            this.DisclaimerTextTabPage.TabIndex = 0;
            this.DisclaimerTextTabPage.Text = "Text";
            this.DisclaimerTextTabPage.UseVisualStyleBackColor = true;
            // 
            // DisclaimerTextTextBox
            // 
            this.DisclaimerTextTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisclaimerTextTextBox.Location = new System.Drawing.Point(6, 6);
            this.DisclaimerTextTextBox.Multiline = true;
            this.DisclaimerTextTextBox.Name = "DisclaimerTextTextBox";
            this.DisclaimerTextTextBox.Size = new System.Drawing.Size(632, 477);
            this.DisclaimerTextTextBox.TabIndex = 0;
            // 
            // DisclaimerRtfTabPage
            // 
            this.DisclaimerRtfTabPage.Controls.Add(this.DisclaimerRtfRichTextBox);
            this.DisclaimerRtfTabPage.Location = new System.Drawing.Point(4, 22);
            this.DisclaimerRtfTabPage.Name = "DisclaimerRtfTabPage";
            this.DisclaimerRtfTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DisclaimerRtfTabPage.Size = new System.Drawing.Size(644, 489);
            this.DisclaimerRtfTabPage.TabIndex = 1;
            this.DisclaimerRtfTabPage.Text = "Rtf";
            this.DisclaimerRtfTabPage.UseVisualStyleBackColor = true;
            // 
            // DisclaimerHtmlTabPage
            // 
            this.DisclaimerHtmlTabPage.Controls.Add(this.DisclaimerHtmlHtmlEditor);
            this.DisclaimerHtmlTabPage.Location = new System.Drawing.Point(4, 22);
            this.DisclaimerHtmlTabPage.Name = "DisclaimerHtmlTabPage";
            this.DisclaimerHtmlTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DisclaimerHtmlTabPage.Size = new System.Drawing.Size(644, 489);
            this.DisclaimerHtmlTabPage.TabIndex = 2;
            this.DisclaimerHtmlTabPage.Text = "Html";
            this.DisclaimerHtmlTabPage.UseVisualStyleBackColor = true;
            // 
            // DisclaimerHtmlHtmlEditor
            // 
            this.DisclaimerHtmlHtmlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisclaimerHtmlHtmlEditor.InnerText = null;
            this.DisclaimerHtmlHtmlEditor.Location = new System.Drawing.Point(6, 3);
            this.DisclaimerHtmlHtmlEditor.Name = "DisclaimerHtmlHtmlEditor";
            this.DisclaimerHtmlHtmlEditor.Size = new System.Drawing.Size(632, 480);
            this.DisclaimerHtmlHtmlEditor.TabIndex = 0;
            this.DisclaimerHtmlHtmlEditor.ToolbarDock = System.Windows.Forms.DockStyle.Top;
            // 
            // DisclaimerRtfRichTextBox
            // 
            this.DisclaimerRtfRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisclaimerRtfRichTextBox.Location = new System.Drawing.Point(6, 6);
            this.DisclaimerRtfRichTextBox.Name = "DisclaimerRtfRichTextBox";
            this.DisclaimerRtfRichTextBox.Size = new System.Drawing.Size(632, 477);
            this.DisclaimerRtfRichTextBox.TabIndex = 0;
            this.DisclaimerRtfRichTextBox.Text = "";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 568);
            this.Controls.Add(this.DisclaimerTabControl);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.ApplyDialogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisclaimerConfigForm";
            this.Text = "DisclaimerHandler configuration";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            this.DisclaimerTabControl.ResumeLayout(false);
            this.DisclaimerTextTabPage.ResumeLayout(false);
            this.DisclaimerTextTabPage.PerformLayout();
            this.DisclaimerRtfTabPage.ResumeLayout(false);
            this.DisclaimerHtmlTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplyDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.TabControl DisclaimerTabControl;
        private System.Windows.Forms.TabPage DisclaimerTextTabPage;
        private System.Windows.Forms.TabPage DisclaimerRtfTabPage;
        private System.Windows.Forms.TabPage DisclaimerHtmlTabPage;
        private System.Windows.Forms.TextBox DisclaimerTextTextBox;
        private MSDN.Html.Editor.HtmlEditorControl DisclaimerHtmlHtmlEditor;
        private System.Windows.Forms.RichTextBox DisclaimerRtfRichTextBox;
    }
}