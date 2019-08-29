using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver
{
    public class FileHandler
    {
        public string currentPath { get; set; }
        public DirectoryInfo[] Directories { get; set; }
        public FileInfo[] Files { get; set; }

        public FileHandler (string currentPath)
        {
            currentPath = currentPath;
            Directories = new DirectoryInfo(currentPath).GetDirectories();
            Files = new DirectoryInfo(currentPath).GetFiles();
        }
    }
}
