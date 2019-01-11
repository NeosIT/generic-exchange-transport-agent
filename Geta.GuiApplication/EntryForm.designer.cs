using System;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    partial class EntryForm
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
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.comboBoxHandler = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelEvent = new System.Windows.Forms.Label();
            this.labelHandler = new System.Windows.Forms.Label();
            this.buttonConfigure = new System.Windows.Forms.Button();
            this.buttonPlaceholderFilters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Location = new System.Drawing.Point(86, 12);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(472, 21);
            this.comboBoxEvent.TabIndex = 0;
            this.comboBoxEvent.SelectedValueChanged += new System.EventHandler(this.comboBoxEvent_SelectedValueChanged);
            // 
            // comboBoxHandler
            // 
            this.comboBoxHandler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHandler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHandler.FormattingEnabled = true;
            this.comboBoxHandler.Location = new System.Drawing.Point(86, 39);
            this.comboBoxHandler.Name = "comboBoxHandler";
            this.comboBoxHandler.Size = new System.Drawing.Size(472, 21);
            this.comboBoxHandler.TabIndex = 2;
            this.comboBoxHandler.SelectedIndexChanged += new System.EventHandler(this.comboBoxHandler_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(463, 194);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(95, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelEvent
            // 
            this.labelEvent.AutoSize = true;
            this.labelEvent.Location = new System.Drawing.Point(13, 15);
            this.labelEvent.Name = "labelEvent";
            this.labelEvent.Size = new System.Drawing.Size(35, 13);
            this.labelEvent.TabIndex = 5;
            this.labelEvent.Text = "Event";
            // 
            // labelHandler
            // 
            this.labelHandler.AutoSize = true;
            this.labelHandler.Location = new System.Drawing.Point(13, 42);
            this.labelHandler.Name = "labelHandler";
            this.labelHandler.Size = new System.Drawing.Size(44, 13);
            this.labelHandler.TabIndex = 7;
            this.labelHandler.Text = "Handler";
            // 
            // buttonConfigure
            // 
            this.buttonConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConfigure.Location = new System.Drawing.Point(12, 194);
            this.buttonConfigure.Name = "buttonConfigure";
            this.buttonConfigure.Size = new System.Drawing.Size(94, 23);
            this.buttonConfigure.TabIndex = 8;
            this.buttonConfigure.Text = "Configure";
            this.buttonConfigure.UseVisualStyleBackColor = true;
            this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            // 
            // buttonPlaceholderFilters
            // 
            this.buttonPlaceholderFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlaceholderFilters.Location = new System.Drawing.Point(12, 66);
            this.buttonPlaceholderFilters.Name = "buttonPlaceholderFilters";
            this.buttonPlaceholderFilters.Size = new System.Drawing.Size(546, 122);
            this.buttonPlaceholderFilters.TabIndex = 9;
            this.buttonPlaceholderFilters.Text = "Placeholder Filter";
            this.buttonPlaceholderFilters.UseVisualStyleBackColor = true;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 228);
            this.Controls.Add(this.buttonPlaceholderFilters);
            this.Controls.Add(this.buttonConfigure);
            this.Controls.Add(this.labelHandler);
            this.Controls.Add(this.labelEvent);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxHandler);
            this.Controls.Add(this.comboBoxEvent);
            this.Name = "EntryForm";
            this.Text = "GETA - ";
            this.Load += new System.EventHandler(this.NewEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.ComboBox comboBoxHandler;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelEvent;
        private System.Windows.Forms.Label labelHandler;
        private System.Windows.Forms.Button buttonConfigure;
        private System.Windows.Forms.Button buttonPlaceholderFilters;
    }
}

