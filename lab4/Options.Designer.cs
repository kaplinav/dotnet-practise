namespace lab4
{
    partial class Options
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
            this.radioBinary = new System.Windows.Forms.RadioButton();
            this.radioXml = new System.Windows.Forms.RadioButton();
            this.groupSaveMode = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioByErrors = new System.Windows.Forms.RadioButton();
            this.groupSaveMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioBinary
            // 
            this.radioBinary.AutoSize = true;
            this.radioBinary.Location = new System.Drawing.Point(6, 19);
            this.radioBinary.Name = "radioBinary";
            this.radioBinary.Size = new System.Drawing.Size(54, 17);
            this.radioBinary.TabIndex = 0;
            this.radioBinary.TabStop = true;
            this.radioBinary.Text = "Binary";
            this.radioBinary.UseVisualStyleBackColor = true;
            // 
            // radioXml
            // 
            this.radioXml.AutoSize = true;
            this.radioXml.Location = new System.Drawing.Point(6, 43);
            this.radioXml.Name = "radioXml";
            this.radioXml.Size = new System.Drawing.Size(47, 17);
            this.radioXml.TabIndex = 1;
            this.radioXml.TabStop = true;
            this.radioXml.Text = "XML";
            this.radioXml.UseVisualStyleBackColor = true;
            // 
            // groupSaveMode
            // 
            this.groupSaveMode.Controls.Add(this.radioBinary);
            this.groupSaveMode.Controls.Add(this.radioXml);
            this.groupSaveMode.Location = new System.Drawing.Point(12, 12);
            this.groupSaveMode.Name = "groupSaveMode";
            this.groupSaveMode.Size = new System.Drawing.Size(108, 74);
            this.groupSaveMode.TabIndex = 2;
            this.groupSaveMode.TabStop = false;
            this.groupSaveMode.Text = "Save mode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioByErrors);
            this.groupBox1.Controls.Add(this.radioAll);
            this.groupBox1.Location = new System.Drawing.Point(127, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testing mode";
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(7, 18);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(36, 17);
            this.radioAll.TabIndex = 0;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioByErrors
            // 
            this.radioByErrors.AutoSize = true;
            this.radioByErrors.Enabled = false;
            this.radioByErrors.Location = new System.Drawing.Point(7, 42);
            this.radioByErrors.Name = "radioByErrors";
            this.radioByErrors.Size = new System.Drawing.Size(109, 17);
            this.radioByErrors.TabIndex = 1;
            this.radioByErrors.TabStop = true;
            this.radioByErrors.Text = "By previous errors";
            this.radioByErrors.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 117);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSaveMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupSaveMode.ResumeLayout(false);
            this.groupSaveMode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBinary;
        private System.Windows.Forms.RadioButton radioXml;
        private System.Windows.Forms.GroupBox groupSaveMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioByErrors;
        private System.Windows.Forms.RadioButton radioAll;
    }
}