using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Circle : Shape { 
    
        public Circle(double r) : base(r, 0) { }
        public override void Show() { Console.WriteLine("круг площадью {0}", 0.5*Math.PI*Math.Pow(R,2)); }
    
    }

}
