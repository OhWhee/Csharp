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
            System.Collections.IEnumerable Range(int init, int upTo)
            {
                Console.WriteLine("Начало выполнения итератора...");
                for (int i = init; i < upTo; i++)
                {
                    yield return i;
                }
                Console.WriteLine("\nКонец выполнения программы...");
            }

            Console.WriteLine("Начало программы...");
            var iter = Range(0, 5);
            Console.WriteLine("Начало цикла...");
            foreach (int j in iter) Console.Write("{0} ", j);
            Console.WriteLine("Завершение цикла...");
            Console.ReadKey();

        }
    }
}
