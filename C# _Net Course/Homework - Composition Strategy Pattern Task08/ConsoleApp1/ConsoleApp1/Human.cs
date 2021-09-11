using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Human : IDriver
    {
        public void navigate() { Console.WriteLine("Поехали!"); }
    }
}
