using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Burger
    {
        IComponent filling;

        public void addFilling(IComponent filling) { this.filling = filling; }
        IComponent getFilling() { return this.filling; }

    }
}
