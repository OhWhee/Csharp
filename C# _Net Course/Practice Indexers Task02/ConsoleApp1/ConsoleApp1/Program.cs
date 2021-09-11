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

            Day week = new Day();

            Console.WriteLine("Mon - {0}", week["Mon"]);
            Console.WriteLine("Other - {0}", week["Other"]);
            Console.ReadKey();

        }
    }
}
