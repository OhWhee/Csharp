using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Electronics
    {
        string brand;
        string whatis;

        public string Brand { get => brand; set => brand = value; }
        public string Whatis { get => whatis; set => whatis = value; }

        public virtual void MainFunctionality()
        {
            Console.WriteLine("Что-то делает");
        }
        public Electronics(string brand) { this.brand = brand; }
    }
}
