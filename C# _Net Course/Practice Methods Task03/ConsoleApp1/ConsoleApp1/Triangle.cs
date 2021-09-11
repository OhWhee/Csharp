using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Triangle
    {
        public double Area(int side, int height)
        {
            return (1.0 / 2.0 * side * height);
        }

        public double Area(int a, int b, int c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }

    }
}
