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
            Transport car = new Transport();
            Console.WriteLine("{0}", car.Engine);
            car.Engine = new ElectricEngine();
            Console.WriteLine("{0}", car.Engine);

            Robot iRobot = new Robot();
            Human chelovek = new Human();

            car.Driver = iRobot;
            car.Driver.navigate();
            Console.WriteLine("\nМеняем водителя...");

            car.Driver = chelovek;
            car.Driver.navigate();


            Console.ReadKey();
        }
    }
}
