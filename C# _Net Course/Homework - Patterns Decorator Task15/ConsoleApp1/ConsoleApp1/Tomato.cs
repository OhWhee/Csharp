using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tomato : BaseDecorator, IComponent
    {
        double cals = 20.0;
        public Tomato(IComponent component) : base(component) { base.Calories += cals; }
    }
}
