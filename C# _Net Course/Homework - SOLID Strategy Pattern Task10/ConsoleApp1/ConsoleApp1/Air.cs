using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Air : IShipping
    {


        public double getCost()
        {
            return 1.15;

        }
        public string getDate()
        {
            return "Два дня";
        }

    }
}
