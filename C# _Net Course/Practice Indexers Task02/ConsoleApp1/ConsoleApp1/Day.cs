using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Day
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

        public int this[string day]
        {
            get
            {
                for (int j = 0; j < days.Length; j++)
                    if (days[j] == day) return j;
                    return -1;
                
            }
        }
    }
}
