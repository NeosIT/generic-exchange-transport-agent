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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
			this.comboBoxEvent = new System.Windows.Forms.ComboBox();
			this.comboBoxHandler = new System.Windows.Forms.ComboBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelEvent = new System.Windows.Forms.Label();
			this.labelHandler = new System.Windows.Forms.Label();
			this.buttonConfigure = new System.Windows.Forms.Button();
            this.filters = new Controls.TaggedTree();
			this.SuspendLayout();
			// 
			// comboBoxEvent
			// 
			resources.ApplyResources(this.comboBoxEvent, "comboBoxEvent");
			this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEvent.FormattingEnabled = true;
			this.comboBoxEvent.Name = "comboBoxEvent";
			this.comboBoxEvent.SelectedIndexChanged += new System.EventHandler(this.comboBoxEvent_SelectedIndexChanged);
			// 
			// comboBoxHandler
			// 
			resources.ApplyResources(this.comboBoxHandler, "comboBoxHandler");
			this.comboBoxHandler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxHandler.FormattingEnabled = true;
			this.comboBoxHandler.Name = "comboBoxHandler";
			this.comboBoxHandler.SelectedIndexChanged += new System.EventHandler(this.comboBoxHandler_SelectedIndexChanged);
			// 
			// buttonSave
			// 
			resources.ApplyResources(this.buttonSave, "buttonSave");
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// labelEvent
			// 
			resources.ApplyResources(this.labelEvent, "labelEvent");
			this.labelEvent.Name = "labelEvent";
			// 
			// labelHandler
			// 
			resources.ApplyResources(this.labelHandler, "labelHandler");
			this.labelHandler.Name = "labelHandler";
			// 
			// buttonConfigure
			// 
			resources.ApplyResources(this.buttonConfigure, "buttonConfigure");
			this.buttonConfigure.Name = "buttonConfigure";
			this.buttonConfigure.UseVisualStyleBackColor = true;
			this.buttonConfigure.Click += new System.EventHandler(this.buttonConfigure_Click);
            //
            // filters
            //
            this.filters.Location = new System.Drawing.Point(12, 66);
            this.filters.Size = new System.Drawing.Size(546, 122);
            this.filters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			// 
			// EntryForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filters);
            this.Controls.Add(this.buttonConfigure);
			this.Controls.Add(this.labelHandler);
			this.Controls.Add(this.labelEvent);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.comboBoxHandler);
			this.Controls.Add(this.comboBoxEvent);
			this.Icon = global::NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Properties.Resources.Icon;
			this.Name = "EntryForm";
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
        private Controls.TaggedTree filters;
    }
}

