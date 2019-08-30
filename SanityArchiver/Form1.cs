using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        public FileInfo SelectedFile { get; set; }
        public string currentPath { get; set; }
        public DirectoryInfo SelectedDirectory { get; set; }

        private ListViewItem SelectedItem
        {
            get
            {
                if (fileList_left.SelectedItems.Count > 0)
                {
                    return fileList_left.SelectedItems[0];
                }
                else
                    return null;
            }
        }

        public Form1()
        {
            InitializeComponent();
            currentPath = @"C:\Users\tarak\";
        }

        public void ShowFiles(string currentPath)
        {
            fileList_left.Items.Clear();
            FileHandler fileHandler = new FileHandler(currentPath);

            try
            {
                foreach (var item in fileHandler.Directories)
                {
                    string[] details = { item.Name, "DIR", item.LastAccessTime.ToShortDateString(), item.Attributes.ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_left.Items.Add(listViewItem);
                    /*ListViewItem clonedItem = new ListViewItem();
                    listViewItem.Clone();
                    fileList_right.Items.Add(clonedItem);*/
                }

                foreach (var item in fileHandler.Directories)
                {
                    string[] details = { item.Name, "DIR", item.LastAccessTime.ToShortDateString(), item.Attributes.ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_right.Items.Add(listViewItem);

                }

                foreach (var item in fileHandler.Files)
                {
                    string[] details = { item.Name, item.Extension, item.LastAccessTime.ToShortDateString(), item.Attributes.ToString(), (item.Length / 1024).ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_left.Items.Add(listViewItem);
                    /*ListViewItem clonedItem = new ListViewItem();
                    listViewItem.Clone();
                    fileList_right.Items.Add(clonedItem);*/
                }

                foreach (var item in fileHandler.Files)
                {
                    string[] details = { item.Name, item.Extension, item.LastAccessTime.ToShortDateString(), item.Attributes.ToString(), (item.Length / 1024).ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_right.Items.Add(listViewItem);

                }
                //fileList_left.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"File or folder cannot be accessed.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
            }

        }



        public void Archive(FileInfo fileToArchive, string currentPath)
        {
            using (FileStream input = fileToArchive.OpenRead())
            {
                FileStream output = File.Create(currentPath + @"\" + fileToArchive.Name + ".gz");
                GZipStream compressor = new GZipStream(output, CompressionMode.Compress);
                int b = input.ReadByte();

                while (b != -1)
                {
                    compressor.WriteByte((byte)b);
                    b = input.ReadByte();
                }
            }
        }

        private void ZipFileButton_Click(object sender, EventArgs e)
        {
            Archive(SelectedFile, currentPath);
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileList_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFile = new FileInfo(currentPath + @"\" + fileList_left.SelectedItems[0].Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ColumnHeader left_header1 = new ColumnHeader();
            left_header1.Text = "Name";
            left_header1.Name = "name";
            fileList_left.Columns.Add(left_header1);

            ColumnHeader left_header2 = new ColumnHeader();
            left_header2.Text = "Extension";
            left_header2.Name = "ext";
            fileList_left.Columns.Add(left_header2);

            ColumnHeader left_header3 = new ColumnHeader();
            left_header3.Text = "Last Accessed";
            left_header3.Name = "lastAccessed";
            fileList_left.Columns.Add(left_header3);

            ColumnHeader left_header4 = new ColumnHeader();
            left_header4.Text = "Attributes";
            left_header4.Name = "attributes";
            fileList_left.Columns.Add(left_header4);

            ColumnHeader left_header5 = new ColumnHeader();
            left_header5.Text = "Size";
            left_header5.Name = "size";
            fileList_left.Columns.Add(left_header5);

            ColumnHeader right_header1 = new ColumnHeader();
            right_header1.Text = "Name";
            right_header1.Name = "name";
            fileList_right.Columns.Add(right_header1);

            ColumnHeader right_header2 = new ColumnHeader();
            right_header2.Text = "Extension";
            right_header2.Name = "ext";
            fileList_right.Columns.Add(right_header2);

            ColumnHeader right_header3 = new ColumnHeader();
            right_header3.Text = "Last Accessed";
            right_header3.Name = "lastAccessed";
            fileList_right.Columns.Add(right_header3);

            ColumnHeader right_header4 = new ColumnHeader();
            right_header4.Text = "Attributes";
            right_header4.Name = "attributes";
            fileList_right.Columns.Add(right_header4);

            ColumnHeader right_header5 = new ColumnHeader();
            right_header5.Text = "Size";
            right_header5.Name = "size";
            fileList_right.Columns.Add(right_header5);




            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                driveBox_left.Items.Add(di.ToString());
            }

            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                driveBox_right.Items.Add(di.ToString());
            }

            ShowFiles(currentPath);
        }

        private void OpenDirs()
        {

        }

        private void fileList_left_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem selectedItem = fileList_left.SelectedItems[0];
            if (selectedItem.SubItems[1].Text == "DIR")
            {
                SelectedDirectory = new DirectoryInfo(currentPath + @"\" + selectedItem.Text);
                currentPath = currentPath + @"\" + selectedItem.Text;
                ShowFiles(currentPath);
            }
            else
            {
                SelectedFile = new FileInfo(currentPath + @"\" + selectedItem.Text);
                System.Diagnostics.Process.Start(SelectedFile.FullName);
            }
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            if (currentPath != Path.GetPathRoot(Environment.SystemDirectory))
            {
                if (SelectedDirectory != null && new DirectoryInfo(SelectedDirectory.Parent.FullName) != null)
                {
                    SelectedDirectory = new DirectoryInfo(SelectedDirectory.Parent.FullName);
                    currentPath = SelectedDirectory.FullName;
                    ShowFiles(currentPath);
                }
            }

        }

        private void fileList_right_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem selectedItem = fileList_right.SelectedItems[0];
            if (selectedItem.SubItems[1].Text == "DIR")
            {
                SelectedDirectory = new DirectoryInfo(currentPath + @"\" + selectedItem.Text);
                currentPath = currentPath + @"\" + selectedItem.Text;
                ShowFiles(currentPath);
            }
            else
            {
                SelectedFile = new FileInfo(currentPath + @"\" + selectedItem.Text);
                System.Diagnostics.Process.Start(SelectedFile.FullName);
            }
        }

        public void Copy(FileInfo file, string newPath)
        {
            File.Copy(file.FullName, Path.Combine(newPath, file.Name));
        }

        public void Move(FileInfo file, string newPath)
        {
            File.Move(file.FullName, Path.Combine(newPath, file.Name));
        }

        private void CopyFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedFile != null)
                {
                    FolderBrowserDialog FBD = new FolderBrowserDialog();
                    DialogResult result = FBD.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string newPath = FBD.SelectedPath;
                        Copy(SelectedFile, newPath);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Error locating file.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error while copying file.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }
        }

        private void MoveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedFile != null)
                {
                    FolderBrowserDialog FBD = new FolderBrowserDialog();
                    DialogResult result = FBD.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string newPath = FBD.SelectedPath;
                        Move(SelectedFile, newPath);
                        ShowFiles(currentPath);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Error locating file.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error while copying file.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }
        }
    }
    
}
