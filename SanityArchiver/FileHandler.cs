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
        public string Path { get; set; }
        public DirectoryInfo[] Directories { get; set; }
        public FileInfo[] Files { get; set; }

        public FileHandler (string path)
        {
            Path = path;
            Directories = new DirectoryInfo(path).GetDirectories();
            Files = new DirectoryInfo(path).GetFiles();
        }
    }
}
