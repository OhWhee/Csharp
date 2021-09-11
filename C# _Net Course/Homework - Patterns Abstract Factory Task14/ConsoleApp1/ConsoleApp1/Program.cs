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
            Config config = new Config("Windows");

            Application app = new Application(config.main());
            app.createUI();
            app.paint();

            Config config1 = new Config("Mac");
            Application app1 = new Application(config1.main());
            app1.createUI();
            app1.paint();


            Console.ReadKey();
        }
    }
}
