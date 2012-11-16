namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfigurationTreeView = new System.Windows.Forms.TreeView();
            this.ConfigurationLabel = new System.Windows.Forms.Label();
            this.AvailableHandlersLabel = new System.Windows.Forms.Label();
            this.AvailableHandlersTreeView = new System.Windows.Forms.TreeView();
            this.ConfigHandlerButton = new System.Windows.Forms.Button();
            this.ConfigFiltersButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OpenConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveConfigFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.AddHandlerButton = new System.Windows.Forms.Button();
            this.RemoveHandlerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConfigurationTreeView
            // 
            this.ConfigurationTreeView.AllowDrop = true;
            this.ConfigurationTreeView.HideSelection = false;
            this.ConfigurationTreeView.Location = new System.Drawing.Point(12, 25);
            this.ConfigurationTreeView.Name = "ConfigurationTreeView";
            this.ConfigurationTreeView.Size = new System.Drawing.Size(220, 434);
            this.ConfigurationTreeView.TabIndex = 0;
            this.ConfigurationTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ConfigurationTreeViewAfterSelect);
            // 
            // ConfigurationLabel
            // 
            this.ConfigurationLabel.AutoSize = true;
            this.ConfigurationLabel.Location = new System.Drawing.Point(12, 9);
            this.ConfigurationLabel.Name = "ConfigurationLabel";
            this.ConfigurationLabel.Size = new System.Drawing.Size(184, 13);
            this.ConfigurationLabel.TabIndex = 1;
            this.ConfigurationLabel.Text = "GenericTransportAgent configuration:";
            // 
            // AvailableHandlersLabel
            // 
            this.AvailableHandlersLabel.AutoSize = true;
            this.AvailableHandlersLabel.Location = new System.Drawing.Point(235, 9);
            this.AvailableHandlersLabel.Name = "AvailableHandlersLabel";
            this.AvailableHandlersLabel.Size = new System.Drawing.Size(96, 13);
            this.AvailableHandlersLabel.TabIndex = 2;
            this.AvailableHandlersLabel.Text = "Available handlers:";
            // 
            // AvailableHandlersTreeView
            // 
            this.AvailableHandlersTreeView.AllowDrop = true;
            this.AvailableHandlersTreeView.HideSelection = false;
            this.AvailableHandlersTreeView.Location = new System.Drawing.Point(238, 25);
            this.AvailableHandlersTreeView.Name = "AvailableHandlersTreeView";
            this.AvailableHandlersTreeView.Size = new System.Drawing.Size(220, 434);
            this.AvailableHandlersTreeView.TabIndex = 3;
            // 
            // ConfigHandlerButton
            // 
            this.ConfigHandlerButton.Location = new System.Drawing.Point(12, 494);
            this.ConfigHandlerButton.Name = "ConfigHandlerButton";
            this.ConfigHandlerButton.Size = new System.Drawing.Size(107, 23);
            this.ConfigHandlerButton.TabIndex = 4;
            this.ConfigHandlerButton.Text = "Config handler...";
            this.ConfigHandlerButton.UseVisualStyleBackColor = true;
            this.ConfigHandlerButton.Click += new System.EventHandler(this.ConfigButtonClick);
            // 
            // ConfigFiltersButton
            // 
            this.ConfigFiltersButton.Location = new System.Drawing.Point(125, 494);
            this.ConfigFiltersButton.Name = "ConfigFiltersButton";
            this.ConfigFiltersButton.Size = new System.Drawing.Size(107, 23);
            this.ConfigFiltersButton.TabIndex = 5;
            this.ConfigFiltersButton.Text = "Config filters...";
            this.ConfigFiltersButton.UseVisualStyleBackColor = true;
            this.ConfigFiltersButton.Click += new System.EventHandler(this.ConfigFiltersButtonClick);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(238, 465);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(107, 23);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load...";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButtonClick);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Location = new System.Drawing.Point(351, 465);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(107, 23);
            this.SaveAsButton.TabIndex = 7;
            this.SaveAsButton.Text = "Save as...";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButtonClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(238, 494);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(107, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(351, 494);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(107, 23);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // OpenConfigFileDialog
            // 
            this.OpenConfigFileDialog.Filter = "Xml-Dateien|*.xml|Alle Dateien|*.*";
            // 
            // SaveConfigFileDialog
            // 
            this.SaveConfigFileDialog.Filter = "Xml-Dateien|*.xml|Alle Dateien|*.*";
            // 
            // AddHandlerButton
            // 
            this.AddHandlerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHandlerButton.Location = new System.Drawing.Point(12, 465);
            this.AddHandlerButton.Name = "AddHandlerButton";
            this.AddHandlerButton.Size = new System.Drawing.Size(107, 23);
            this.AddHandlerButton.TabIndex = 10;
            this.AddHandlerButton.Text = "Add handler";
            this.AddHandlerButton.UseVisualStyleBackColor = true;
            this.AddHandlerButton.Click += new System.EventHandler(this.AddHandlerButtonClick);
            // 
            // RemoveHandlerButton
            // 
            this.RemoveHandlerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveHandlerButton.Location = new System.Drawing.Point(125, 465);
            this.RemoveHandlerButton.Name = "RemoveHandlerButton";
            this.RemoveHandlerButton.Size = new System.Drawing.Size(107, 23);
            this.RemoveHandlerButton.TabIndex = 11;
            this.RemoveHandlerButton.Text = "Remove handler";
            this.RemoveHandlerButton.UseVisualStyleBackColor = true;
            this.RemoveHandlerButton.Click += new System.EventHandler(this.RemoveHandlerButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 529);
            this.Controls.Add(this.RemoveHandlerButton);
            this.Controls.Add(this.AddHandlerButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SaveAsButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ConfigFiltersButton);
            this.Controls.Add(this.ConfigHandlerButton);
            this.Controls.Add(this.AvailableHandlersTreeView);
            this.Controls.Add(this.AvailableHandlersLabel);
            this.Controls.Add(this.ConfigurationLabel);
            this.Controls.Add(this.ConfigurationTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ConfigurationTreeView;
        private System.Windows.Forms.Label ConfigurationLabel;
        private System.Windows.Forms.Label AvailableHandlersLabel;
        private System.Windows.Forms.TreeView AvailableHandlersTreeView;
        private System.Windows.Forms.Button ConfigHandlerButton;
        private System.Windows.Forms.Button ConfigFiltersButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.OpenFileDialog OpenConfigFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveConfigFileDialog;
        private System.Windows.Forms.Button AddHandlerButton;
        private System.Windows.Forms.Button RemoveHandlerButton;

    }
}

