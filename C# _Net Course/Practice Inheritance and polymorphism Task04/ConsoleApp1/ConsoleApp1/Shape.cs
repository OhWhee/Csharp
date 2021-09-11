using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Shape
    {
        double r, h;
        public double R { get => r; }
        public double H { get => h; }

        public Shape(double r, double h) { this.r = r; this.h = h; }



        public abstract void Show();

    }

}
