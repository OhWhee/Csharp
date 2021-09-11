using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Kettle : Consumer
    {
        public Kettle(string Name, int PowerConsumption) : base(Name, PowerConsumption) { }
    }
}
