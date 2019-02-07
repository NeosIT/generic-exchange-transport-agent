namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    partial class AboutForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.labelRevision = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(9, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(403, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Generic Exchange Transport Agent";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBuild
            // 
            this.labelBuild.Location = new System.Drawing.Point(9, 33);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(403, 20);
            this.labelBuild.TabIndex = 2;
            this.labelBuild.Text = "##Build";
            this.labelBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRevision
            // 
            this.labelRevision.Location = new System.Drawing.Point(9, 53);
            this.labelRevision.Name = "labelRevision";
            this.labelRevision.Size = new System.Drawing.Size(403, 20);
            this.labelRevision.TabIndex = 3;
            this.labelRevision.Text = "##Revision";
            this.labelRevision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(12, 76);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(400, 23);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 115);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.labelRevision);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            this.Deactivate += new System.EventHandler(this.AboutForm_Deactivate);
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label labelRevision;
        private System.Windows.Forms.Button buttonCopy;
    }
}