using System;

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
            this.ZipFileButton = new System.Windows.Forms.Button();
            this.fileList_left = new System.Windows.Forms.ListView();
            this.fileList_right = new System.Windows.Forms.ListView();
            this.driveBox_left = new System.Windows.Forms.ListView();
            this.driveBox_right = new System.Windows.Forms.ListView();
            this.backButton = new System.Windows.Forms.Button();
            this.backButton_right = new System.Windows.Forms.Button();
            this.CopyFileButton = new System.Windows.Forms.Button();
            this.MoveFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ZipFileButton
            // 
            this.ZipFileButton.Location = new System.Drawing.Point(12, 12);
            this.ZipFileButton.Name = "ZipFileButton";
            this.ZipFileButton.Size = new System.Drawing.Size(82, 27);
            this.ZipFileButton.TabIndex = 2;
            this.ZipFileButton.Text = "Zip";
            this.ZipFileButton.UseVisualStyleBackColor = true;
            this.ZipFileButton.Click += new System.EventHandler(this.ZipFileButton_Click);
            // 
            // fileList_left
            // 
            this.fileList_left.HideSelection = false;
            this.fileList_left.Location = new System.Drawing.Point(12, 82);
            this.fileList_left.Name = "fileList_left";
            this.fileList_left.Size = new System.Drawing.Size(355, 297);
            this.fileList_left.TabIndex = 4;
            this.fileList_left.UseCompatibleStateImageBehavior = false;
            this.fileList_left.View = System.Windows.Forms.View.Details;
            this.fileList_left.ItemActivate += new System.EventHandler(this.fileList_left_ItemActivate);
            this.fileList_left.SelectedIndexChanged += new System.EventHandler(this.fileList_left_SelectedIndexChanged);
            // 
            // fileList_right
            // 
            this.fileList_right.HideSelection = false;
            this.fileList_right.Location = new System.Drawing.Point(434, 82);
            this.fileList_right.Name = "fileList_right";
            this.fileList_right.Size = new System.Drawing.Size(354, 297);
            this.fileList_right.TabIndex = 5;
            this.fileList_right.UseCompatibleStateImageBehavior = false;
            this.fileList_right.View = System.Windows.Forms.View.Details;
            this.fileList_right.ItemActivate += new System.EventHandler(this.fileList_right_ItemActivate);
            // 
            // driveBox_left
            // 
            this.driveBox_left.HideSelection = false;
            this.driveBox_left.Location = new System.Drawing.Point(12, 385);
            this.driveBox_left.Name = "driveBox_left";
            this.driveBox_left.Size = new System.Drawing.Size(102, 53);
            this.driveBox_left.TabIndex = 6;
            this.driveBox_left.UseCompatibleStateImageBehavior = false;
            this.driveBox_left.View = System.Windows.Forms.View.List;
            // 
            // driveBox_right
            // 
            this.driveBox_right.HideSelection = false;
            this.driveBox_right.Location = new System.Drawing.Point(434, 385);
            this.driveBox_right.Name = "driveBox_right";
            this.driveBox_right.Size = new System.Drawing.Size(102, 53);
            this.driveBox_right.TabIndex = 7;
            this.driveBox_right.UseCompatibleStateImageBehavior = false;
            this.driveBox_right.View = System.Windows.Forms.View.List;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 50);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(48, 26);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "<-";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click_1);
            // 
            // backButton_right
            // 
            this.backButton_right.Location = new System.Drawing.Point(434, 50);
            this.backButton_right.Name = "backButton_right";
            this.backButton_right.Size = new System.Drawing.Size(48, 26);
            this.backButton_right.TabIndex = 9;
            this.backButton_right.Text = "<-";
            this.backButton_right.UseVisualStyleBackColor = true;
            // 
            // CopyFileButton
            // 
            this.CopyFileButton.Location = new System.Drawing.Point(112, 12);
            this.CopyFileButton.Name = "CopyFileButton";
            this.CopyFileButton.Size = new System.Drawing.Size(82, 27);
            this.CopyFileButton.TabIndex = 10;
            this.CopyFileButton.Text = "Copy";
            this.CopyFileButton.UseVisualStyleBackColor = true;
            this.CopyFileButton.Click += new System.EventHandler(this.CopyFileButton_Click);
            // 
            // MoveFileButton
            // 
            this.MoveFileButton.Location = new System.Drawing.Point(215, 12);
            this.MoveFileButton.Name = "MoveFileButton";
            this.MoveFileButton.Size = new System.Drawing.Size(82, 27);
            this.MoveFileButton.TabIndex = 11;
            this.MoveFileButton.Text = "Move";
            this.MoveFileButton.UseVisualStyleBackColor = true;
            this.MoveFileButton.Click += new System.EventHandler(this.MoveFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MoveFileButton);
            this.Controls.Add(this.CopyFileButton);
            this.Controls.Add(this.backButton_right);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.driveBox_right);
            this.Controls.Add(this.driveBox_left);
            this.Controls.Add(this.fileList_right);
            this.Controls.Add(this.fileList_left);
            this.Controls.Add(this.ZipFileButton);
            this.Name = "Form1";
            this.Text = "Sanity Archiver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void driveBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button ZipFileButton;
        private System.Windows.Forms.ListView fileList_left;
        private System.Windows.Forms.ListView fileList_right;
        private System.Windows.Forms.ListView driveBox_left;
        private System.Windows.Forms.ListView driveBox_right;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button backButton_right;
        private System.Windows.Forms.Button CopyFileButton;
        private System.Windows.Forms.Button MoveFileButton;
    }
}

