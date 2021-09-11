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
            Config WINconfig = new Config("Windows");
            Config Webconfig = new Config("Web");
            Application app = new Application();

            app.Config = WINconfig;
            app.Init();
            app.Dialog.render();

            app.Config = Webconfig;
            app.Init();
            app.Dialog.render();


            Console.ReadKey();
        }
    }
}
