using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Circle
    {
        double iR;
        double iX = 0;
        double iY = 0;
        double sqr;
        const double pi = 3.14;
        readonly double length;

        public double IX { get => iX; set => iX = value; }
        public double IY { get => iY; set => iY = value; }
        public double IR {
            get => iR;
            set {
                if (value >= 0 && value <= 100)
                    iR = value;
                else
                {
                    throw new Exception("Input value is not valid.");
                }
            }
        }
        public static double Pi => pi;
        public double Length => length;

        public double Sqr {
            get => Pi * Math.Pow(IR,2);
           }

        public Circle(double x, double y, double r)
        {
            IX = x; IY = y; IR = r;
            length = 2 * Pi * IR;
        }
    }
}
