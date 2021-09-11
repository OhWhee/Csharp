using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Ground : IShipping
    {
        public double getCost()
        {
            return 1.1;

        }
        public string getDate()
        {
            return "Четыре дня";
        }
    }
}
