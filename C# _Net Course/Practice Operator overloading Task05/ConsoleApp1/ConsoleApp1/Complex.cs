using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Complex
    {
        public double Re { get; private set; }
        public double Im { get; private set; }
        public Complex(double r, double i) { Re = r;Im = i; }
        public static Complex operator -(Complex x)
        {
            return new Complex(-x.Re, -x.Im);
        }
    }
}
