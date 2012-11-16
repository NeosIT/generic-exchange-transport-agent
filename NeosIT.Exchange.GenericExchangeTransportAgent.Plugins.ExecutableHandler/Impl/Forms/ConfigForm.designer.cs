namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.ExecutableHandler.Impl.Forms
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
            this.ApplyDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.ExportEmlFileFilenameTextBox = new System.Windows.Forms.TextBox();
            this.ExportEmlFileFilenameLabel = new System.Windows.Forms.Label();
            this.ExportEmlFilePathBrowseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CommandLabel
            // 
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.Location = new System.Drawing.Point(12, 9);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new System.Drawing.Size(57, 13);
            this.CommandLabel.TabIndex = 0;
            this.CommandLabel.Text = "Command:";
            // 
            // CommandFileDialog
            // 
            this.CommandFileDialog.Filter = "Alle Dateien|*.*";
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandTextBox.Location = new System.Drawing.Point(13, 26);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(278, 20);
            this.CommandTextBox.TabIndex = 1;
            // 
            // CommandBrowseButton
            // 
            this.CommandBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandBrowseButton.Location = new System.Drawing.Point(297, 23);
            this.CommandBrowseButton.Name = "CommandBrowseButton";
            this.CommandBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.CommandBrowseButton.TabIndex = 2;
            this.CommandBrowseButton.Text = "Browse...";
            this.CommandBrowseButton.UseVisualStyleBackColor = true;
            this.CommandBrowseButton.Click += new System.EventHandler(this.CommandBrowseButtonClick);
            // 
            // ArgumentsLabel
            // 
            this.ArgumentsLabel.AutoSize = true;
            this.ArgumentsLabel.Location = new System.Drawing.Point(13, 53);
            this.ArgumentsLabel.Name = "ArgumentsLabel";
            this.ArgumentsLabel.Size = new System.Drawing.Size(60, 13);
            this.ArgumentsLabel.TabIndex = 3;
            this.ArgumentsLabel.Text = "Arguments:";
            // 
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeoutNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(297, 69);
            this.TimeoutNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.TimeoutNumericUpDown.TabIndex = 4;
            // 
            // TimeoutLabel
            // 
            this.TimeoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeoutLabel.AutoSize = true;
            this.TimeoutLabel.Location = new System.Drawing.Point(294, 53);
            this.TimeoutLabel.Name = "TimeoutLabel";
            this.TimeoutLabel.Size = new System.Drawing.Size(48, 13);
            this.TimeoutLabel.TabIndex = 5;
            this.TimeoutLabel.Text = "Timeout:";
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsTextBox.Location = new System.Drawing.Point(13, 70);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(278, 20);
            this.ArgumentsTextBox.TabIndex = 6;
            // 
            // ExportEmlFileLabel
            // 
            this.ExportEmlFileLabel.AutoSize = true;
            this.ExportEmlFileLabel.Location = new System.Drawing.Point(13, 97);
            this.ExportEmlFileLabel.Name = "ExportEmlFileLabel";
            this.ExportEmlFileLabel.Size = new System.Drawing.Size(81, 13);
            this.ExportEmlFileLabel.TabIndex = 7;
            this.ExportEmlFileLabel.Text = "Export EML file:";
            // 
            // ExportEmlFileCheckBox
            // 
            this.ExportEmlFileCheckBox.AutoSize = true;
            this.ExportEmlFileCheckBox.Location = new System.Drawing.Point(13, 114);
            this.ExportEmlFileCheckBox.Name = "ExportEmlFileCheckBox";
            this.ExportEmlFileCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ExportEmlFileCheckBox.TabIndex = 8;
            this.ExportEmlFileCheckBox.UseVisualStyleBackColor = true;
            this.ExportEmlFileCheckBox.CheckedChanged += new System.EventHandler(this.ExportEmlFileCheckBoxCheckedChanged);
            // 
            // ExportEmlFilePathTextBox
            // 
            this.ExportEmlFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportEmlFilePathTextBox.Location = new System.Drawing.Point(34, 114);
            this.ExportEmlFilePathTextBox.Name = "ExportEmlFilePathTextBox";
            this.ExportEmlFilePathTextBox.Size = new System.Drawing.Size(257, 20);
            this.ExportEmlFilePathTextBox.TabIndex = 9;
            // 
            // ApplyDialogButton
            // 
            this.ApplyDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyDialogButton.Location = new System.Drawing.Point(216, 231);
            this.ApplyDialogButton.Name = "ApplyDialogButton";
            this.ApplyDialogButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyDialogButton.TabIndex = 10;
            this.ApplyDialogButton.Text = "Apply";
            this.ApplyDialogButton.UseVisualStyleBackColor = true;
            this.ApplyDialogButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDialogButton.Location = new System.Drawing.Point(297, 231);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 11;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // ExportEmlFileFilenameTextBox
            // 
            this.ExportEmlFileFilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportEmlFileFilenameTextBox.Location = new System.Drawing.Point(13, 153);
            this.ExportEmlFileFilenameTextBox.Name = "ExportEmlFileFilenameTextBox";
            this.ExportEmlFileFilenameTextBox.Size = new System.Drawing.Size(359, 20);
            this.ExportEmlFileFilenameTextBox.TabIndex = 12;
            // 
            // ExportEmlFileFilenameLabel
            // 
            this.ExportEmlFileFilenameLabel.AutoSize = true;
            this.ExportEmlFileFilenameLabel.Location = new System.Drawing.Point(10, 137);
            this.ExportEmlFileFilenameLabel.Name = "ExportEmlFileFilenameLabel";
            this.ExportEmlFileFilenameLabel.Size = new System.Drawing.Size(52, 13);
            this.ExportEmlFileFilenameLabel.TabIndex = 13;
            this.ExportEmlFileFilenameLabel.Text = "Filename:";
            // 
            // ExportEmlFilePathBrowseButton
            // 
            this.ExportEmlFilePathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportEmlFilePathBrowseButton.Location = new System.Drawing.Point(297, 112);
            this.ExportEmlFilePathBrowseButton.Name = "ExportEmlFilePathBrowseButton";
            this.ExportEmlFilePathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.ExportEmlFilePathBrowseButton.TabIndex = 14;
            this.ExportEmlFilePathBrowseButton.Text = "Browse...";
            this.ExportEmlFilePathBrowseButton.UseVisualStyleBackColor = true;
            this.ExportEmlFilePathBrowseButton.Click += new System.EventHandler(this.ExportEmlFilePathBrowseButtonClick);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.ExportEmlFilePathBrowseButton);
            this.Controls.Add(this.ExportEmlFileFilenameLabel);
            this.Controls.Add(this.ExportEmlFileFilenameTextBox);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.ApplyDialogButton);
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
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "ConfigForm";
            this.Text = "ExecutableHandler configuration";
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
        private System.Windows.Forms.Button ApplyDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.TextBox ExportEmlFileFilenameTextBox;
        private System.Windows.Forms.Label ExportEmlFileFilenameLabel;
        private System.Windows.Forms.Button ExportEmlFilePathBrowseButton;
    }
}