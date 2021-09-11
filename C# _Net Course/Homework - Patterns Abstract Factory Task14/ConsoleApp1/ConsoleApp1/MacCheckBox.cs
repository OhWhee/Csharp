using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MacCheckBox: ICheckBox
    {
        public void paint() { Console.WriteLine("Чек-бокс mac"); }
    }
}

