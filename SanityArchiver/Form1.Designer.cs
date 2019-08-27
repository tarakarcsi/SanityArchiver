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
            this.ZipFileButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.fileList_left = new System.Windows.Forms.ListView();
            this.fileList_right = new System.Windows.Forms.ListView();
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
            // 
            // ZipFileButton
            // 
            this.ZipFileButton.Location = new System.Drawing.Point(268, 12);
            this.ZipFileButton.Name = "ZipFileButton";
            this.ZipFileButton.Size = new System.Drawing.Size(108, 27);
            this.ZipFileButton.TabIndex = 2;
            this.ZipFileButton.Text = "Zip";
            this.ZipFileButton.UseVisualStyleBackColor = true;
            this.ZipFileButton.Click += new System.EventHandler(this.ZipFileButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(141, 12);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(108, 27);
            this.OpenFileButton.TabIndex = 3;
            this.OpenFileButton.Text = "Open";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // fileList_left
            // 
            this.fileList_left.HideSelection = false;
            this.fileList_left.Location = new System.Drawing.Point(12, 59);
            this.fileList_left.Name = "fileList_left";
            this.fileList_left.Size = new System.Drawing.Size(355, 297);
            this.fileList_left.TabIndex = 4;
            this.fileList_left.UseCompatibleStateImageBehavior = false;
            this.fileList_left.View = System.Windows.Forms.View.SmallIcon;
            this.fileList_left.SelectedIndexChanged += new System.EventHandler(this.fileList_left_SelectedIndexChanged);
            // 
            // fileList_right
            // 
            this.fileList_right.HideSelection = false;
            this.fileList_right.Location = new System.Drawing.Point(434, 59);
            this.fileList_right.Name = "fileList_right";
            this.fileList_right.Size = new System.Drawing.Size(354, 297);
            this.fileList_right.TabIndex = 5;
            this.fileList_right.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileList_right);
            this.Controls.Add(this.fileList_left);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.ZipFileButton);
            this.Controls.Add(this.BrowseButton);
            this.Name = "Form1";
            this.Text = "Sanity Archiver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ZipFileButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.ListView fileList_left;
        private System.Windows.Forms.ListView fileList_right;
    }
}

