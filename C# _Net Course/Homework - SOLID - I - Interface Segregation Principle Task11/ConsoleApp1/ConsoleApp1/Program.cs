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

            Amazon amazon = new Amazon("Адрес амазона");

            amazon.createServer(new Region("Россия"), "192.168.0.1");
            amazon.createServer(new Region("США"), "192.168.0.2");
            amazon.createServer(new Region("США"), "192.168.0.3");
            amazon.createServer(new Region("Нидерланды"), "192.168.0.4");

            File file = new File("Пароли.txt");

            amazon.storeFile(file);

            File file2 = amazon.getFile(file);

            amazon.listServers(new Region("США"));
            amazon.listServers(new Region("Россия"));

            Console.WriteLine("CDN адрес: {0}", amazon.getCDNAdress());

            amazon.listFiles();
            Console.ReadKey();

        }
    }
}
