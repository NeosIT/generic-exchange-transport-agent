namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    partial class FilterForm
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
            this.FiltersTreeView = new System.Windows.Forms.TreeView();
            this.FiltersLabel = new System.Windows.Forms.Label();
            this.OnLabel = new System.Windows.Forms.Label();
            this.OnDropDownList = new System.Windows.Forms.ComboBox();
            this.OperatorLabel = new System.Windows.Forms.Label();
            this.OperatorDropDownList = new System.Windows.Forms.ComboBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.AndButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SaveDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.OrButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FiltersTreeView
            // 
            this.FiltersTreeView.HideSelection = false;
            this.FiltersTreeView.Location = new System.Drawing.Point(12, 25);
            this.FiltersTreeView.Name = "FiltersTreeView";
            this.FiltersTreeView.Size = new System.Drawing.Size(318, 197);
            this.FiltersTreeView.TabIndex = 0;
            this.FiltersTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FiltersTreeViewAfterSelect);
            // 
            // FiltersLabel
            // 
            this.FiltersLabel.AutoSize = true;
            this.FiltersLabel.Location = new System.Drawing.Point(12, 9);
            this.FiltersLabel.Name = "FiltersLabel";
            this.FiltersLabel.Size = new System.Drawing.Size(37, 13);
            this.FiltersLabel.TabIndex = 1;
            this.FiltersLabel.Text = "Filters:";
            // 
            // OnLabel
            // 
            this.OnLabel.AutoSize = true;
            this.OnLabel.Location = new System.Drawing.Point(13, 229);
            this.OnLabel.Name = "OnLabel";
            this.OnLabel.Size = new System.Drawing.Size(24, 13);
            this.OnLabel.TabIndex = 2;
            this.OnLabel.Text = "On:";
            // 
            // OnDropDownList
            // 
            this.OnDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OnDropDownList.FormattingEnabled = true;
            this.OnDropDownList.Location = new System.Drawing.Point(13, 246);
            this.OnDropDownList.Name = "OnDropDownList";
            this.OnDropDownList.Size = new System.Drawing.Size(317, 21);
            this.OnDropDownList.TabIndex = 3;
            // 
            // OperatorLabel
            // 
            this.OperatorLabel.AutoSize = true;
            this.OperatorLabel.Location = new System.Drawing.Point(13, 274);
            this.OperatorLabel.Name = "OperatorLabel";
            this.OperatorLabel.Size = new System.Drawing.Size(51, 13);
            this.OperatorLabel.TabIndex = 4;
            this.OperatorLabel.Text = "Operator:";
            // 
            // OperatorDropDownList
            // 
            this.OperatorDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OperatorDropDownList.FormattingEnabled = true;
            this.OperatorDropDownList.Location = new System.Drawing.Point(13, 291);
            this.OperatorDropDownList.Name = "OperatorDropDownList";
            this.OperatorDropDownList.Size = new System.Drawing.Size(317, 21);
            this.OperatorDropDownList.TabIndex = 5;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(13, 319);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(37, 13);
            this.ValueLabel.TabIndex = 6;
            this.ValueLabel.Text = "Value:";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(13, 336);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(317, 20);
            this.ValueTextBox.TabIndex = 7;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(12, 362);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 8;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // AndButton
            // 
            this.AndButton.Location = new System.Drawing.Point(93, 362);
            this.AndButton.Name = "AndButton";
            this.AndButton.Size = new System.Drawing.Size(75, 23);
            this.AndButton.TabIndex = 9;
            this.AndButton.Text = "And";
            this.AndButton.UseVisualStyleBackColor = true;
            this.AndButton.Click += new System.EventHandler(this.AndButtonClick);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(255, 362);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 10;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
            // 
            // SaveDialogButton
            // 
            this.SaveDialogButton.Location = new System.Drawing.Point(174, 440);
            this.SaveDialogButton.Name = "SaveDialogButton";
            this.SaveDialogButton.Size = new System.Drawing.Size(75, 23);
            this.SaveDialogButton.TabIndex = 11;
            this.SaveDialogButton.Text = "Save";
            this.SaveDialogButton.UseVisualStyleBackColor = true;
            this.SaveDialogButton.Click += new System.EventHandler(this.SaveDialogButtonClick);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Location = new System.Drawing.Point(255, 440);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 12;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButtonClick);
            // 
            // OrButton
            // 
            this.OrButton.Location = new System.Drawing.Point(174, 362);
            this.OrButton.Name = "OrButton";
            this.OrButton.Size = new System.Drawing.Size(75, 23);
            this.OrButton.TabIndex = 13;
            this.OrButton.Text = "Or";
            this.OrButton.UseVisualStyleBackColor = true;
            this.OrButton.Click += new System.EventHandler(this.OrButtonClick);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 475);
            this.Controls.Add(this.OrButton);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.SaveDialogButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AndButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.OperatorDropDownList);
            this.Controls.Add(this.OperatorLabel);
            this.Controls.Add(this.OnDropDownList);
            this.Controls.Add(this.OnLabel);
            this.Controls.Add(this.FiltersLabel);
            this.Controls.Add(this.FiltersTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FilterForm";
            this.Text = "FilterForm";
            this.Load += new System.EventHandler(this.FilterFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FiltersTreeView;
        private System.Windows.Forms.Label FiltersLabel;
        private System.Windows.Forms.Label OnLabel;
        private System.Windows.Forms.ComboBox OnDropDownList;
        private System.Windows.Forms.Label OperatorLabel;
        private System.Windows.Forms.ComboBox OperatorDropDownList;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button AndButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button SaveDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button OrButton;
    }
}