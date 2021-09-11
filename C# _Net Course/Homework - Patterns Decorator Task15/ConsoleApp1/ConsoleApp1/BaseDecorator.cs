using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BaseDecorator: IComponent
    {
        IComponent wrapper;
        double calories;

        public double Calories { get => calories; set => calories = value; }
        internal IComponent Wrapper { get => wrapper; }

        public double addCalories()
        {
            return this.getCalories();
        }

        public BaseDecorator(IComponent component) { this.wrapper = component; this.calories += component.addCalories(); }
        public double getCalories() { return this.calories; }
    }
}
