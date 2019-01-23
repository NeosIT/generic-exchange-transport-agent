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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisclaimerConfigForm));
            this.SaveDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.DisclaimerTabControl = new System.Windows.Forms.TabControl();
            this.DisclaimerTextTabPage = new System.Windows.Forms.TabPage();
            this.DisclaimerTextTextBox = new System.Windows.Forms.TextBox();
            this.DisclaimerRtfTabPage = new System.Windows.Forms.TabPage();
            this.DisclaimerRtfRichTextBox = new System.Windows.Forms.RichTextBox();
            this.DisclaimerHtmlTabPage = new System.Windows.Forms.TabPage();
            this.DisclaimerHtmlHtmlEditor = new MSDN.Html.Editor.HtmlEditorControl();
            this.DisclaimerTabControl.SuspendLayout();
            this.DisclaimerTextTabPage.SuspendLayout();
            this.DisclaimerRtfTabPage.SuspendLayout();
            this.DisclaimerHtmlTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveDialogButton
            // 
            resources.ApplyResources(this.SaveDialogButton, "SaveDialogButton");
            this.SaveDialogButton.Name = "SaveDialogButton";
            this.SaveDialogButton.UseVisualStyleBackColor = true;
            this.SaveDialogButton.Click += new System.EventHandler(this.SaveDialogButtonClick);
            // 
            // CancelDialogButton
            // 
            resources.ApplyResources(this.CancelDialogButton, "CancelDialogButton");
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // DisclaimerTabControl
            // 
            resources.ApplyResources(this.DisclaimerTabControl, "DisclaimerTabControl");
            this.DisclaimerTabControl.Controls.Add(this.DisclaimerTextTabPage);
            this.DisclaimerTabControl.Controls.Add(this.DisclaimerRtfTabPage);
            this.DisclaimerTabControl.Controls.Add(this.DisclaimerHtmlTabPage);
            this.DisclaimerTabControl.Name = "DisclaimerTabControl";
            this.DisclaimerTabControl.SelectedIndex = 0;
            // 
            // DisclaimerTextTabPage
            // 
            resources.ApplyResources(this.DisclaimerTextTabPage, "DisclaimerTextTabPage");
            this.DisclaimerTextTabPage.Controls.Add(this.DisclaimerTextTextBox);
            this.DisclaimerTextTabPage.Name = "DisclaimerTextTabPage";
            this.DisclaimerTextTabPage.UseVisualStyleBackColor = true;
            // 
            // DisclaimerTextTextBox
            // 
            resources.ApplyResources(this.DisclaimerTextTextBox, "DisclaimerTextTextBox");
            this.DisclaimerTextTextBox.Name = "DisclaimerTextTextBox";
            // 
            // DisclaimerRtfTabPage
            // 
            resources.ApplyResources(this.DisclaimerRtfTabPage, "DisclaimerRtfTabPage");
            this.DisclaimerRtfTabPage.Controls.Add(this.DisclaimerRtfRichTextBox);
            this.DisclaimerRtfTabPage.Name = "DisclaimerRtfTabPage";
            this.DisclaimerRtfTabPage.UseVisualStyleBackColor = true;
            // 
            // DisclaimerRtfRichTextBox
            // 
            resources.ApplyResources(this.DisclaimerRtfRichTextBox, "DisclaimerRtfRichTextBox");
            this.DisclaimerRtfRichTextBox.Name = "DisclaimerRtfRichTextBox";
            // 
            // DisclaimerHtmlTabPage
            // 
            resources.ApplyResources(this.DisclaimerHtmlTabPage, "DisclaimerHtmlTabPage");
            this.DisclaimerHtmlTabPage.Controls.Add(this.DisclaimerHtmlHtmlEditor);
            this.DisclaimerHtmlTabPage.Name = "DisclaimerHtmlTabPage";
            this.DisclaimerHtmlTabPage.UseVisualStyleBackColor = true;
            // 
            // DisclaimerHtmlHtmlEditor
            // 
            resources.ApplyResources(this.DisclaimerHtmlHtmlEditor, "DisclaimerHtmlHtmlEditor");
            this.DisclaimerHtmlHtmlEditor.InnerText = null;
            this.DisclaimerHtmlHtmlEditor.Name = "DisclaimerHtmlHtmlEditor";
            this.DisclaimerHtmlHtmlEditor.ToolbarDock = System.Windows.Forms.DockStyle.Top;
            // 
            // DisclaimerConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DisclaimerTabControl);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.SaveDialogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisclaimerConfigForm";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            this.DisclaimerTabControl.ResumeLayout(false);
            this.DisclaimerTextTabPage.ResumeLayout(false);
            this.DisclaimerTextTabPage.PerformLayout();
            this.DisclaimerRtfTabPage.ResumeLayout(false);
            this.DisclaimerHtmlTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveDialogButton;
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