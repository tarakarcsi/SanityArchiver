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
            FileHandler fileHandler = new FileHandler(Path);

            try
            {
                foreach (var item in fileHandler.Directories)
                {
                    string[] details = { item.Name, "DIR", item.LastAccessTime.ToShortDateString(), item.Attributes.ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_left.Items.Add(listViewItem);
                }

                foreach(var item in fileHandler.Files)
                {
                    string[] details = { item.Name, item.Extension, item.LastAccessTime.ToShortDateString(), item.Attributes.ToString() };
                    ListViewItem listViewItem = new ListViewItem(details);
                    fileList_left.Items.Add(listViewItem);
                }
            }catch (UnauthorizedAccessException ex)
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
            ColumnHeader header1 = new ColumnHeader();
            header1.Text = "Name";
            header1.Name = "name";
            fileList_left.Columns.Add(header1);
            ColumnHeader header2 = new ColumnHeader();
            header2.Text = "Extension";
            header2.Name = "ext";
            fileList_left.Columns.Add(header2);


            ShowFiles(Path);
        }
    }


}
