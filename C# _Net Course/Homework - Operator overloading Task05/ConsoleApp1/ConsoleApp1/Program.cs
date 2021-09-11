using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Определить класс «множество целых чисел» и операции
соответствующие множеству. «+» - объединение
множеств. «*» - пересечение множеств. «-» - разность
множеств. «==» - равенство множеств. «<» - включение
множества. Предусмотреть возможность неявного
преобразования целых чисел в тип множества. */

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Set set1 = new Set(1, 2, 3);
            Set set2 = new Set(3, 4, 5);

            List<int> nums = new List<int> {1, 2, 3 };
            Set set3 = new Set(nums);

            Set setTest = set1 + set2;
            Console.WriteLine("Заданные множества: ");
            set1.Show();
            set2.Show();
            Console.WriteLine("\n\n");
            Console.WriteLine("Объединение: ");
            setTest.Show();

            Console.WriteLine("\nПересечение");
            setTest = set1 * set2;
            setTest.Show();

            Console.WriteLine("\nРазность");
            setTest = set1 - set2;
            setTest.Show();
            Console.WriteLine("\n\n");

            Console.WriteLine("Заданные множества: ");
            set1.Show();
            set3.Show();
            Console.WriteLine("\nВключение");
            Console.WriteLine(set1 < set3);
            Console.WriteLine(set1 > set3);

            Console.WriteLine("\n\n");

            Console.WriteLine("Заданные множества: ");
            set1.Show();
            set2.Show();
            Console.WriteLine("\nВключение");
            Console.WriteLine(set1 > set2);

            Console.WriteLine("\n\n");
            Console.WriteLine("Заданные множества: ");
            set1.Show();
            set3.Show();
            Console.WriteLine("\nРавенство");
            Console.WriteLine(set1 == set3);
            Console.WriteLine("\n\n");
            Console.WriteLine("Заданные множества: ");
            set1.Show();
            set2.Show();
            Console.WriteLine("\nРавенство");
            Console.WriteLine(set1 == set2);
            Console.WriteLine("\n\n");
            Console.WriteLine("Заданные множества: ");
            set1.Show();
            set3.Show();
            Console.WriteLine(set3 == set1);


            Console.ReadKey();

        }
    }
}
