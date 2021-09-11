using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class VideoFile
    {
        string filename;
        public VideoFile(string filename) { this.Filename = filename; }

        public string Filename { get => filename; set => filename = value; }
    }
}
