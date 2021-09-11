using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Region
    {
        string location;

        public string Location { get => location; set => location = value; }
        public Region(string location) { this.location = location; }
    }
}
