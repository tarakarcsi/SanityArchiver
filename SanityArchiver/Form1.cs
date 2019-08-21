using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
