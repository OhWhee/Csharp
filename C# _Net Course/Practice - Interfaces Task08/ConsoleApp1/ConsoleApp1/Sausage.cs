using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Sausage : IFood
    {
        double nutrition;
        double weight;

        

        public double getWeight { get => weight; }
        public double getNutrition()
        {
            return this.nutrition; 
        }

        public Sausage(double cals, double weight)
        {
            this.nutrition = cals;
            this.weight = weight;
        }
    }
}
