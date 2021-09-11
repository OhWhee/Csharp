using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex number = new Complex(10.0, 3.0);
            Console.WriteLine("{0} + {1}i", number.Re, number.Im);

            Console.ReadKey();
        }
    }
}
