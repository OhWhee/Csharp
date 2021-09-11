using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MacButton: IButton
    {
        public void paint() { Console.WriteLine("Кнопка mac"); }
    }

}
