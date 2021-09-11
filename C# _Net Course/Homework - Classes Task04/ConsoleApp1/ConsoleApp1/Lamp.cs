using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Lamp : Electronics
    {
        public Lamp(string brand):base(brand) { this.Whatis = "Лампочка"; }

        public override void MainFunctionality()
        {
            Console.WriteLine("Я освещаю!");
        }
    }
}
