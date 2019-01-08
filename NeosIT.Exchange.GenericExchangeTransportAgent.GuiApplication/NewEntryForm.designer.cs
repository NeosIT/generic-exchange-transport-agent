﻿using System;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    partial class NewEntryForm
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
            this.comboBoxParent = new System.Windows.Forms.ComboBox();
            this.comboBoxHandler = new System.Windows.Forms.ComboBox();
            this.buttonConditions = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTxt = new System.Windows.Forms.TabPage();
            this.tabPageRtf = new System.Windows.Forms.TabPage();
            this.tabPageHtml = new System.Windows.Forms.TabPage();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelEvent = new System.Windows.Forms.Label();
            this.labelParentNode = new System.Windows.Forms.Label();
            this.labelHandler = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
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
            this.comboBoxEvent.Size = new System.Drawing.Size(505, 21);
            this.comboBoxEvent.TabIndex = 0;
            // 
            // comboBoxParent
            // 
            this.comboBoxParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParent.FormattingEnabled = true;
            this.comboBoxParent.Location = new System.Drawing.Point(86, 39);
            this.comboBoxParent.Name = "comboBoxParent";
            this.comboBoxParent.Size = new System.Drawing.Size(505, 21);
            this.comboBoxParent.TabIndex = 1;
            // 
            // comboBoxHandler
            // 
            this.comboBoxHandler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHandler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHandler.FormattingEnabled = true;
            this.comboBoxHandler.Location = new System.Drawing.Point(86, 66);
            this.comboBoxHandler.Name = "comboBoxHandler";
            this.comboBoxHandler.Size = new System.Drawing.Size(505, 21);
            this.comboBoxHandler.TabIndex = 2;
            // 
            // buttonConditions
            // 
            this.buttonConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConditions.Location = new System.Drawing.Point(460, 93);
            this.buttonConditions.Name = "buttonConditions";
            this.buttonConditions.Size = new System.Drawing.Size(131, 23);
            this.buttonConditions.TabIndex = 3;
            this.buttonConditions.Text = "Conditions";
            this.buttonConditions.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageTxt);
            this.tabControl1.Controls.Add(this.tabPageRtf);
            this.tabControl1.Controls.Add(this.tabPageHtml);
            this.tabControl1.Location = new System.Drawing.Point(12, 122);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 401);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageTxt
            // 
            this.tabPageTxt.Location = new System.Drawing.Point(4, 22);
            this.tabPageTxt.Name = "tabPageTxt";
            this.tabPageTxt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTxt.Size = new System.Drawing.Size(568, 277);
            this.tabPageTxt.TabIndex = 0;
            this.tabPageTxt.Text = "Text";
            this.tabPageTxt.UseVisualStyleBackColor = true;
            // 
            // tabPageRtf
            // 
            this.tabPageRtf.Location = new System.Drawing.Point(4, 22);
            this.tabPageRtf.Name = "tabPageRtf";
            this.tabPageRtf.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRtf.Size = new System.Drawing.Size(568, 277);
            this.tabPageRtf.TabIndex = 1;
            this.tabPageRtf.Text = "RTF";
            this.tabPageRtf.UseVisualStyleBackColor = true;
            // 
            // tabPageHtml
            // 
            this.tabPageHtml.Location = new System.Drawing.Point(4, 22);
            this.tabPageHtml.Name = "tabPageHtml";
            this.tabPageHtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHtml.Size = new System.Drawing.Size(571, 375);
            this.tabPageHtml.TabIndex = 2;
            this.tabPageHtml.Text = "HTML";
            this.tabPageHtml.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(460, 529);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(131, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
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
            // labelParentNode
            // 
            this.labelParentNode.AutoSize = true;
            this.labelParentNode.Location = new System.Drawing.Point(13, 42);
            this.labelParentNode.Name = "labelParentNode";
            this.labelParentNode.Size = new System.Drawing.Size(67, 13);
            this.labelParentNode.TabIndex = 6;
            this.labelParentNode.Text = "Parent Node";
            // 
            // labelHandler
            // 
            this.labelHandler.AutoSize = true;
            this.labelHandler.Location = new System.Drawing.Point(13, 69);
            this.labelHandler.Name = "labelHandler";
            this.labelHandler.Size = new System.Drawing.Size(44, 13);
            this.labelHandler.TabIndex = 7;
            this.labelHandler.Text = "Handler";
            // 
            // NewEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 564);
            this.Controls.Add(this.labelHandler);
            this.Controls.Add(this.labelParentNode);
            this.Controls.Add(this.labelEvent);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonConditions);
            this.Controls.Add(this.comboBoxHandler);
            this.Controls.Add(this.comboBoxParent);
            this.Controls.Add(this.comboBoxEvent);
            this.Name = "NewEntryForm";
            this.Text = "GETA - New Entry";
            this.Load += new System.EventHandler(this.NewEntryForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.ComboBox comboBoxParent;
        private System.Windows.Forms.ComboBox comboBoxHandler;
        private System.Windows.Forms.Button buttonConditions;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTxt;
        private System.Windows.Forms.TabPage tabPageRtf;
        private System.Windows.Forms.TabPage tabPageHtml;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelEvent;
        private System.Windows.Forms.Label labelParentNode;
        private System.Windows.Forms.Label labelHandler;
    }
}

