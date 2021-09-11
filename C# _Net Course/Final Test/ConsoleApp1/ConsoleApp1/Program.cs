using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizzaIngredientFactory ingredientFactory = FactoryProvider.GetPizzaIngredientFactory("NY");
            IDough dough = ingredientFactory.GetConcreteProduct<IDough>();
            ISauce sauce = ingredientFactory.GetConcreteProduct<ISauce>();
            ICheese cheese = ingredientFactory.GetConcreteProduct<ICheese>();
            IVeggies veggies = ingredientFactory.GetConcreteProduct<IVeggies>();
            IPepperoni pepperoni = ingredientFactory.GetConcreteProduct<IPepperoni>();
            IClam clam = ingredientFactory.GetConcreteProduct<IClam>();

            ingredientFactory.getStyle();
            Console.WriteLine("Состав:");
            dough.AboutMe();
            sauce.AboutMe();
            cheese.AboutMe();
            veggies.AboutMe();
            clam.AboutMe();

            Console.WriteLine("\nЗаменим стиль\n");

            ingredientFactory = FactoryProvider.GetPizzaIngredientFactory("Chicago");
            dough = ingredientFactory.GetConcreteProduct<IDough>();
            sauce = ingredientFactory.GetConcreteProduct<ISauce>();
            cheese = ingredientFactory.GetConcreteProduct<ICheese>();
            veggies = ingredientFactory.GetConcreteProduct<IVeggies>();
            pepperoni = ingredientFactory.GetConcreteProduct<IPepperoni>();
            clam = ingredientFactory.GetConcreteProduct<IClam>();


            ingredientFactory.getStyle();
            Console.WriteLine("Состав:");
            dough.AboutMe();
            sauce.AboutMe();
            cheese.AboutMe();
            veggies.AboutMe();
            clam.AboutMe();

            
            Console.ReadKey();
        }
    }
}
