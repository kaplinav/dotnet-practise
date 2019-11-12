namespace lab4
{
    partial class Statistics
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCardCount = new System.Windows.Forms.Label();
            this.labelNounsCount = new System.Windows.Forms.Label();
            this.labelAdjectivesCount = new System.Windows.Forms.Label();
            this.labelAVGLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Count of cards";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Average words length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nouns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Adjectives";
            // 
            // labelCardCount
            // 
            this.labelCardCount.AutoSize = true;
            this.labelCardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCardCount.Location = new System.Drawing.Point(199, 13);
            this.labelCardCount.Name = "labelCardCount";
            this.labelCardCount.Size = new System.Drawing.Size(18, 20);
            this.labelCardCount.TabIndex = 4;
            this.labelCardCount.Text = "0";
            // 
            // labelNounsCount
            // 
            this.labelNounsCount.AutoSize = true;
            this.labelNounsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNounsCount.Location = new System.Drawing.Point(199, 43);
            this.labelNounsCount.Name = "labelNounsCount";
            this.labelNounsCount.Size = new System.Drawing.Size(18, 20);
            this.labelNounsCount.TabIndex = 5;
            this.labelNounsCount.Text = "0";
            // 
            // labelAdjectivesCount
            // 
            this.labelAdjectivesCount.AutoSize = true;
            this.labelAdjectivesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdjectivesCount.Location = new System.Drawing.Point(199, 72);
            this.labelAdjectivesCount.Name = "labelAdjectivesCount";
            this.labelAdjectivesCount.Size = new System.Drawing.Size(18, 20);
            this.labelAdjectivesCount.TabIndex = 6;
            this.labelAdjectivesCount.Text = "0";
            // 
            // labelAVGLength
            // 
            this.labelAVGLength.AutoSize = true;
            this.labelAVGLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAVGLength.Location = new System.Drawing.Point(199, 102);
            this.labelAVGLength.Name = "labelAVGLength";
            this.labelAVGLength.Size = new System.Drawing.Size(18, 20);
            this.labelAVGLength.TabIndex = 7;
            this.labelAVGLength.Text = "0";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 165);
            this.Controls.Add(this.labelAVGLength);
            this.Controls.Add(this.labelAdjectivesCount);
            this.Controls.Add(this.labelNounsCount);
            this.Controls.Add(this.labelCardCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statistics";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCardCount;
        private System.Windows.Forms.Label labelNounsCount;
        private System.Windows.Forms.Label labelAdjectivesCount;
        private System.Windows.Forms.Label labelAVGLength;
    }
}