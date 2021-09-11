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

            GameDevCompany gamedev = new GameDevCompany(new List<IEmployee>() { new Designer(), new Programmer(), new Programmer(), new Tester() });
            List<IEmployee> gamedevEmployees = gamedev.getEmployees();

            OutsourcingCompany outsource = new OutsourcingCompany(new List<IEmployee>() { new Programmer(), new Programmer(), new Programmer(), new Programmer(), new Programmer(), new Programmer(), new Tester() });
            List<IEmployee> outsourceEmployees = outsource.getEmployees();


            Console.WriteLine("Посмотрим сотрудников геймдева");
            foreach(IEmployee employee in gamedevEmployees) { employee.doWork(); }
            Console.WriteLine("\nПосмотрим сотрудников аутсорса");
            foreach (IEmployee employee in outsourceEmployees) { employee.doWork(); }

            Console.ReadKey();



        }
    }
}
