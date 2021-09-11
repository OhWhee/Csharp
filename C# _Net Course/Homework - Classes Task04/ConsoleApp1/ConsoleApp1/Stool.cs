using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Stool : Furniture
    {
        public Stool(string brand) : base(brand) { this.Whatis = "Стул"; }
    }
}
