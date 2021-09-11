using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class File
    {
        string fileName;

        public string FileName { get => fileName; set => fileName = value; }
        public File(string filename) { this.fileName = filename; }
    }
}
