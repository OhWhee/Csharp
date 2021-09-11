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
            Burger burger = new Burger();
            IComponent filling = new Filling();
            filling = new Cutlet(filling);
            filling = new Cucumber(filling);
            filling = new Cheese(filling);
            filling = new Tomato(filling);
            filling = new Onion(filling);
            burger.addFilling(filling);
            
            
            
            Console.WriteLine("В начинке бургера {0} ккал.", filling.getCalories());

            Console.ReadKey();
        }
    }
}
