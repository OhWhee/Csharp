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

            var c1 = new Circle(3, 5, 100);
            

            Console.WriteLine(c1.IY);
            Console.WriteLine(c1.IX);
            Console.WriteLine(c1.IR);
            Console.WriteLine(c1.Length);
            Console.WriteLine(c1.Sqr);


            Console.ReadKey();

        }
    }
}
