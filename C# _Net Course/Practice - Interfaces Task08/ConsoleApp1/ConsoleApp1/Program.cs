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
            Cat kotsosiska = new Cat();
            Cat kotNeSosiska = new Cat();
            Sausage sosiska = new Sausage(40, 0.1);
            Sausage sosiska2 = new Sausage(50, 0.12);

            kotsosiska.eat(sosiska);
            kotNeSosiska.eat(sosiska2);

            Console.WriteLine("{0}", kotsosiska.Energy);
            Console.WriteLine("{0}", kotNeSosiska.Energy);


            Console.ReadKey();


        }
    }
}
