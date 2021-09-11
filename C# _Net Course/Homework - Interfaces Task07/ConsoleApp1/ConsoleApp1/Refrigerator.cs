using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Refrigerator : Consumer
    {
        public Refrigerator(string Name, int PowerConsumption) : base(Name, PowerConsumption) { }
    }
}
