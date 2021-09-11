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
            Week week = new Week();

            foreach(var day in week)
            {
                Console.WriteLine(day);
            }

            Triangle triangle = new Triangle(10, 10, 10);

            foreach (var side in triangle)
            {
                Console.WriteLine(side);
            }


            Console.ReadKey();
        }
    }
}
