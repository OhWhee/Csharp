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
            Shape[] masShape = new Shape[2];
            masShape[0] = new Square(3, 5);
            masShape[1] = new Circle(5);

            foreach (Shape elem in masShape) elem.Show();

            Console.ReadKey();
        }
    }
}
