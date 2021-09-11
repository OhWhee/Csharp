using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cucumber : BaseDecorator, IComponent
    {
        double cals = 15;
        public Cucumber(IComponent component) : base(component) { base.Calories += cals; }

    }
}
