using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public IDough createDough() { return new ThinCrustDough(); }
        public ISauce createSauce() { return new MarinaraSauce(); }
        public ICheese createCheese() { return new ReggianoCheese(); }
        public IVeggies createVeggies() { return new Olives(); }
        public IPepperoni createPepperoni() { return new Pepperoni(); }
        public IClam createClam() { return new FreshClams(); }
        public void getStyle() { Console.WriteLine("Нью-Йоркский стиль"); }

        public T GetConcreteProduct<T>()
        {
            switch (typeof(T).Name)
            {
                case "IDough":
                    object dough = createDough();
                    return (T)dough;
                case "ISauce":
                    object sauce = createSauce();
                    return (T)sauce;
                case "ICheese":
                    object cheese = createCheese();
                    return (T)cheese;
                case "IVeggies":
                    object veggies = createVeggies();
                    return (T)veggies;
                case "IPepperoni":
                    object pepperoni = createPepperoni();
                    return (T)pepperoni;
                case "IClam":
                    object clam = createClam();
                    return (T)clam;
                default:
                    object result = -1;
                    return (T)result;

            }
        }
    }
}
