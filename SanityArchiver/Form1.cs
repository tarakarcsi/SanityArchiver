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
        public string Path { get; set; }
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
            Path = @"C:\Users\tarak\";
        }

        public void ShowFiles(string path)
        {
            fileList_left.Items.Clear();
            FileHandler fileHandler = new FileHandler(Path);

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
                    string[] details = { item.Name, item.Extension, item.LastAccessTime.ToShortDateString(), item.Attributes.ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_left.Items.Add(listViewItem);
                    /*ListViewItem clonedItem = new ListViewItem();
                    listViewItem.Clone();
                    fileList_right.Items.Add(clonedItem);*/
                }

                foreach (var item in fileHandler.Files)
                {
                    string[] details = { item.Name, item.Extension, item.LastAccessTime.ToShortDateString(), item.Attributes.ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_right.Items.Add(listViewItem);
                    
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"File or folder cannot be accessed.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
            }

        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SelectedItem.Text);
        }

        public void Archive(FileInfo fileToArchive, string path)
        {
            using (FileStream input = fileToArchive.OpenRead())
            {
                FileStream output = File.Create(path + @"\" + fileToArchive.Name + ".gz");
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
            Archive(SelectedFile, Path);
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileList_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedFile = new FileInfo(SelectedItem.Text);
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




            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                driveBox_left.Items.Add(di.ToString());
            }

            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                driveBox_right.Items.Add(di.ToString());
            }

            ShowFiles(Path);
        }

        private void OpenDirs()
        {
            
        }

        private void fileList_left_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem selectedItem = fileList_left.SelectedItems[0];
            if (selectedItem.SubItems[1].Text == "DIR")
            {
                SelectedDirectory = new DirectoryInfo(Path + @"\" + selectedItem.Text);
                Path = Path + @"\" + selectedItem.Text;
                ShowFiles(Path);
            }
            else
            {
                SelectedFile = new FileInfo(Path + @"\" + selectedItem.Text);
                System.Diagnostics.Process.Start(SelectedFile.FullName);
            }
        }
    }


}
