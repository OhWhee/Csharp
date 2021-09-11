using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IPizzaIngredientFactory
    {
        IDough createDough();
        ISauce createSauce();
        ICheese createCheese();
        IVeggies createVeggies();
        IPepperoni createPepperoni();
        IClam createClam();
        void getStyle();
        T GetConcreteProduct<T>();

    }
}
