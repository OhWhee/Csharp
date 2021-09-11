using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Onion : BaseDecorator, IComponent
    {
        double cals = 10.0;
        public Onion(IComponent component) : base(component) { base.Calories += cals; }
    }
}
