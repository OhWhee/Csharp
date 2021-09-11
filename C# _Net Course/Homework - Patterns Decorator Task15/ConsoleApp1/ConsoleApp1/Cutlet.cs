using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cutlet : BaseDecorator, IComponent
    {
        double cals = 150.0;
        public Cutlet(IComponent component) : base(component) { base.Calories += cals; }


    }
}
