namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Plugins
{
    partial class ExecutableConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecutableConfigForm));
            this.CommandLabel = new System.Windows.Forms.Label();
            this.CommandFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.CommandBrowseButton = new System.Windows.Forms.Button();
            this.ArgumentsLabel = new System.Windows.Forms.Label();
            this.TimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimeoutLabel = new System.Windows.Forms.Label();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.ExportFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ExportEmlFileLabel = new System.Windows.Forms.Label();
            this.ExportEmlFileCheckBox = new System.Windows.Forms.CheckBox();
            this.ExportEmlFilePathTextBox = new System.Windows.Forms.TextBox();
            this.SaveDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.ExportEmlFileFilenameTextBox = new System.Windows.Forms.TextBox();
            this.ExportEmlFileFilenameLabel = new System.Windows.Forms.Label();
            this.ExportEmlFilePathBrowseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CommandLabel
            // 
            resources.ApplyResources(this.CommandLabel, "CommandLabel");
            this.CommandLabel.Name = "CommandLabel";
            // 
            // CommandFileDialog
            // 
            resources.ApplyResources(this.CommandFileDialog, "CommandFileDialog");
            // 
            // CommandTextBox
            // 
            resources.ApplyResources(this.CommandTextBox, "CommandTextBox");
            this.CommandTextBox.Name = "CommandTextBox";
            // 
            // CommandBrowseButton
            // 
            resources.ApplyResources(this.CommandBrowseButton, "CommandBrowseButton");
            this.CommandBrowseButton.Name = "CommandBrowseButton";
            this.CommandBrowseButton.UseVisualStyleBackColor = true;
            this.CommandBrowseButton.Click += new System.EventHandler(this.CommandBrowseButtonClick);
            // 
            // ArgumentsLabel
            // 
            resources.ApplyResources(this.ArgumentsLabel, "ArgumentsLabel");
            this.ArgumentsLabel.Name = "ArgumentsLabel";
            // 
            // TimeoutNumericUpDown
            // 
            resources.ApplyResources(this.TimeoutNumericUpDown, "TimeoutNumericUpDown");
            this.TimeoutNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            // 
            // TimeoutLabel
            // 
            resources.ApplyResources(this.TimeoutLabel, "TimeoutLabel");
            this.TimeoutLabel.Name = "TimeoutLabel";
            // 
            // ArgumentsTextBox
            // 
            resources.ApplyResources(this.ArgumentsTextBox, "ArgumentsTextBox");
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            // 
            // ExportFolderBrowserDialog
            // 
            resources.ApplyResources(this.ExportFolderBrowserDialog, "ExportFolderBrowserDialog");
            // 
            // ExportEmlFileLabel
            // 
            resources.ApplyResources(this.ExportEmlFileLabel, "ExportEmlFileLabel");
            this.ExportEmlFileLabel.Name = "ExportEmlFileLabel";
            // 
            // ExportEmlFileCheckBox
            // 
            resources.ApplyResources(this.ExportEmlFileCheckBox, "ExportEmlFileCheckBox");
            this.ExportEmlFileCheckBox.Name = "ExportEmlFileCheckBox";
            this.ExportEmlFileCheckBox.UseVisualStyleBackColor = true;
            this.ExportEmlFileCheckBox.CheckedChanged += new System.EventHandler(this.ExportEmlFileCheckBoxCheckedChanged);
            // 
            // ExportEmlFilePathTextBox
            // 
            resources.ApplyResources(this.ExportEmlFilePathTextBox, "ExportEmlFilePathTextBox");
            this.ExportEmlFilePathTextBox.Name = "ExportEmlFilePathTextBox";
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
            // ExportEmlFileFilenameTextBox
            // 
            resources.ApplyResources(this.ExportEmlFileFilenameTextBox, "ExportEmlFileFilenameTextBox");
            this.ExportEmlFileFilenameTextBox.Name = "ExportEmlFileFilenameTextBox";
            // 
            // ExportEmlFileFilenameLabel
            // 
            resources.ApplyResources(this.ExportEmlFileFilenameLabel, "ExportEmlFileFilenameLabel");
            this.ExportEmlFileFilenameLabel.Name = "ExportEmlFileFilenameLabel";
            // 
            // ExportEmlFilePathBrowseButton
            // 
            resources.ApplyResources(this.ExportEmlFilePathBrowseButton, "ExportEmlFilePathBrowseButton");
            this.ExportEmlFilePathBrowseButton.Name = "ExportEmlFilePathBrowseButton";
            this.ExportEmlFilePathBrowseButton.UseVisualStyleBackColor = true;
            this.ExportEmlFilePathBrowseButton.Click += new System.EventHandler(this.ExportEmlFilePathBrowseButtonClick);
            // 
            // ExecutableConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExportEmlFilePathBrowseButton);
            this.Controls.Add(this.ExportEmlFileFilenameLabel);
            this.Controls.Add(this.ExportEmlFileFilenameTextBox);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.SaveDialogButton);
            this.Controls.Add(this.ExportEmlFilePathTextBox);
            this.Controls.Add(this.ExportEmlFileCheckBox);
            this.Controls.Add(this.ExportEmlFileLabel);
            this.Controls.Add(this.ArgumentsTextBox);
            this.Controls.Add(this.TimeoutLabel);
            this.Controls.Add(this.TimeoutNumericUpDown);
            this.Controls.Add(this.ArgumentsLabel);
            this.Controls.Add(this.CommandBrowseButton);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.CommandLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExecutableConfigForm";
            this.Load += new System.EventHandler(this.ConfigFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CommandLabel;
        private System.Windows.Forms.OpenFileDialog CommandFileDialog;
        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.Button CommandBrowseButton;
        private System.Windows.Forms.Label ArgumentsLabel;
        private System.Windows.Forms.NumericUpDown TimeoutNumericUpDown;
        private System.Windows.Forms.Label TimeoutLabel;
        private System.Windows.Forms.TextBox ArgumentsTextBox;
        private System.Windows.Forms.FolderBrowserDialog ExportFolderBrowserDialog;
        private System.Windows.Forms.Label ExportEmlFileLabel;
        private System.Windows.Forms.CheckBox ExportEmlFileCheckBox;
        private System.Windows.Forms.TextBox ExportEmlFilePathTextBox;
        private System.Windows.Forms.Button SaveDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.TextBox ExportEmlFileFilenameTextBox;
        private System.Windows.Forms.Label ExportEmlFileFilenameLabel;
        private System.Windows.Forms.Button ExportEmlFilePathBrowseButton;
    }
}