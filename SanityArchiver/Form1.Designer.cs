namespace SanityArchiver
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.AutoEllipsis = true;
            this.BrowseButton.Location = new System.Drawing.Point(12, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(110, 27);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.Location = new System.Drawing.Point(12, 60);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(364, 290);
            this.fileList.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.BrowseButton);
            this.Name = "Form1";
            this.Text = "Sanity Archiver";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ListBox fileList;
    }
}

