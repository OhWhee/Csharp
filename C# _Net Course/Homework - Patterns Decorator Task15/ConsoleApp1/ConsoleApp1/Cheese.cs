using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cheese : BaseDecorator, IComponent
    {
        double cals = 70.0;
        public Cheese(IComponent component) : base(component) { base.Calories += cals; }

    }
}
