using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Programmer : IEmployee
    {
        public void doWork() { Console.WriteLine("Я кодю"); }
    }
}
