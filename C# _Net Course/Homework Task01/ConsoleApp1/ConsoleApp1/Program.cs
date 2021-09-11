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
            //В данном массиве поменять местами элементы, стоящие на нечетных местах, с
            //элементами, стоящими на четных местах.

            //Создадим массив случайной длины от 1 до 20 элементов
            Random rnd = new Random();
            int val = rnd.Next(1, 20);
            int[] myArray = new int[val];
            
            //Заполним случайными числами
            for(int i = 0; i < myArray.Count(); i++)
            {
                int num = rnd.Next(1, 20);
                myArray[i] = num;
                Console.WriteLine(myArray[i]);
            }

            //Поменяем местами четные элементы массива с нечетными
            for (int i = 0; i < myArray.Count(); i++)
            {
                if(i % 2 != 0){
                    int tmp;
                    tmp = myArray[i];
                    myArray[i] = myArray[i - 1];
                    myArray[i - 1] = tmp;
                }
            }

            for (int i = 0; i < myArray.Count(); i++)
            {
                Console.WriteLine(myArray[i]);
            }

            Console.ReadKey();
        }
    }
}
