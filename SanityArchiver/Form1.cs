using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if(FBD.ShowDialog() == DialogResult.OK)
            {
                fileList.Items.Clear();
                string[] files = Directory.GetFiles(FBD.SelectedPath);
                string[] dirs = Directory.GetDirectories(FBD.SelectedPath);

                foreach(string file in files)
                {
                    fileList.Items.Add(file);
                }
                foreach (string dir in dirs)
                {
                    fileList.Items.Add(dir);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        /*
        private void button1_Click_1(object sender, EventArgs e)
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
        }*/

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(fileList.SelectedItem.ToString());
        }
    }
}
