namespace SwfExtractor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelFileName = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BtnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFileName.Location = new System.Drawing.Point(98, 21);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelFileName.Size = new System.Drawing.Size(103, 16);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "Select swf files...";
            // 
            // btnOpen
            // 
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnOpen.Size = new System.Drawing.Size(80, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(355, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // BtnStop
            // 
            this.BtnStop.Enabled = false;
            this.BtnStop.Location = new System.Drawing.Point(374, 49);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 3;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 82);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Swf Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button BtnStop;
    }
}

