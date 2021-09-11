using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Square: Shape
    {
        public Square(double r, double h): base(r, h) { }
        public override void Show() { Console.WriteLine("Квадрат площадью {0}", R * H); }
    }
}
