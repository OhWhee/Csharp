using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fridge : Electronics
    {
        int doorsCount = 1;

        public int DoorsCount { get => doorsCount; set => doorsCount = value; }
        public override void MainFunctionality() {

            Console.WriteLine("Я морожу!");
        }

        public Fridge(string brand, int doors) : base(brand) { this.doorsCount = doors; this.Whatis = "Холодильник"; }

    }
}
