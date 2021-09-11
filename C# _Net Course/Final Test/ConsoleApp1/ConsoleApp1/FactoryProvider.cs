using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class FactoryProvider
    {
        public static IPizzaIngredientFactory GetPizzaIngredientFactory(string factoryType)
        {
            if (factoryType.Contains("NY"))
                return new NYPizzaIngredientFactory();
            else if (factoryType.Contains("Chicago"))
                return new ChicagoPizzaIngredientFactory();
            else
                throw new ArgumentException("Необходимо ввести стиль начинки для пиццы");
        }
            

    }
}
