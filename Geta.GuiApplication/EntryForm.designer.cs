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
			this.filters = new NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls.TaggedTree();
			this.query = new System.Windows.Forms.TextBox();
			this.buttonAnd = new System.Windows.Forms.Button();
			this.buttonOr = new System.Windows.Forms.Button();
			this.keySelector = new System.Windows.Forms.ComboBox();
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
			resources.ApplyResources(this.filters, "filters");
			this.filters.BackColor = System.Drawing.Color.White;
			this.filters.Name = "filters";
			// 
			// query
			// 
			resources.ApplyResources(this.query, "query");
			this.query.BackColor = System.Drawing.Color.White;
			this.query.Name = "query";
			// 
			// buttonAnd
			// 
			resources.ApplyResources(this.buttonAnd, "buttonAnd");
			this.buttonAnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
			this.buttonAnd.FlatAppearance.BorderSize = 0;
			this.buttonAnd.ForeColor = System.Drawing.Color.White;
			this.buttonAnd.Name = "buttonAnd";
			this.buttonAnd.UseVisualStyleBackColor = false;
			this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
			// 
			// buttonOr
			// 
			resources.ApplyResources(this.buttonOr, "buttonOr");
			this.buttonOr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(154)))), ((int)(((byte)(193)))));
			this.buttonOr.FlatAppearance.BorderSize = 0;
			this.buttonOr.ForeColor = System.Drawing.Color.White;
			this.buttonOr.Name = "buttonOr";
			this.buttonOr.UseVisualStyleBackColor = false;
			this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
			// 
			// keySelector
			// 
			resources.ApplyResources(this.keySelector, "keySelector");
			this.keySelector.BackColor = System.Drawing.SystemColors.Window;
			this.keySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.keySelector.FormattingEnabled = true;
			this.keySelector.Name = "keySelector";
			// 
			// EntryForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.keySelector);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.filters);
			this.Controls.Add(this.buttonAnd);
			this.Controls.Add(this.buttonOr);
			this.Controls.Add(this.query);
			this.Controls.Add(this.buttonConfigure);
			this.Controls.Add(this.labelHandler);
			this.Controls.Add(this.labelEvent);
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
        private System.Windows.Forms.TextBox query;
        private System.Windows.Forms.Button buttonAnd;
        private System.Windows.Forms.Button buttonOr;
        private System.Windows.Forms.ComboBox keySelector;
    }
}

