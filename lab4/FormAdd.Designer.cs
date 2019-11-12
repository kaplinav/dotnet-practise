namespace lab4
{
    partial class FormAdd
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textTranslate = new System.Windows.Forms.TextBox();
            this.textWord = new System.Windows.Forms.TextBox();
            this.comboPartsOfSpeech = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAdd.Location = new System.Drawing.Point(0, 36);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(197, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCancel.Location = new System.Drawing.Point(0, 36);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(191, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 314);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonAdd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer1.Size = new System.Drawing.Size(392, 59);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textTranslate);
            this.groupBox1.Controls.Add(this.textWord);
            this.groupBox1.Controls.Add(this.comboPartsOfSpeech);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 314);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Card";
            // 
            // textTranslate
            // 
            this.textTranslate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textTranslate.Location = new System.Drawing.Point(3, 45);
            this.textTranslate.Multiline = true;
            this.textTranslate.Name = "textTranslate";
            this.textTranslate.Size = new System.Drawing.Size(386, 245);
            this.textTranslate.TabIndex = 2;
            // 
            // textWord
            // 
            this.textWord.Dock = System.Windows.Forms.DockStyle.Top;
            this.textWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWord.Location = new System.Drawing.Point(3, 16);
            this.textWord.Name = "textWord";
            this.textWord.Size = new System.Drawing.Size(386, 29);
            this.textWord.TabIndex = 1;
            // 
            // comboPartsOfSpeech
            // 
            this.comboPartsOfSpeech.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboPartsOfSpeech.FormattingEnabled = true;
            this.comboPartsOfSpeech.Items.AddRange(new object[] {
            "NOUN - (Naming word)",
            "PRONOUN - (Replaces a Noun)",
            "ADJECTIVE - (Describing word)",
            "VERB - (Action Word)",
            "ADVERB - (Describes a verb)",
            "PREPOSITION - (Shows relationship)",
            "CONJUNCTION - (Joining word)",
            "INTERJECTION - (Expressive word)"});
            this.comboPartsOfSpeech.Location = new System.Drawing.Point(3, 290);
            this.comboPartsOfSpeech.Name = "comboPartsOfSpeech";
            this.comboPartsOfSpeech.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboPartsOfSpeech.Size = new System.Drawing.Size(386, 21);
            this.comboPartsOfSpeech.TabIndex = 0;
            this.comboPartsOfSpeech.Text = "Select part of speech";
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "FormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new card";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textTranslate;
        private System.Windows.Forms.TextBox textWord;
        private System.Windows.Forms.ComboBox comboPartsOfSpeech;
    }
}