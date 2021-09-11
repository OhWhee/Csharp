using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HTMLButton : IButton
    {
        public void render() { Console.WriteLine("<button>"); }
        public void onClick() { Console.WriteLine("Нажатие на HTML кнопку"); }
    }
}
