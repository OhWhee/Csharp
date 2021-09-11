using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class File
    {
        string filename;

        public string Filename { get => filename; set => filename = value; }
        public File(string filename) { this.filename = filename; }
        public void write() { Console.WriteLine("Файл {0} успешно сохранен", this.filename); }
    }
}
