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
            /* Ввести с консоли массив целых чисел и отсортировать его методом прямого включения. */

            int defaultSize = 3;
            int arraySize;
            int defaultValue = 0;

            Console.WriteLine("Укажите длину массива\n");
 
            try {
                arraySize = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException e) {
                arraySize = defaultSize;
            }


            
            int[] myArray = new int[arraySize];

            Console.WriteLine("Введите элементы массива\n");

            for(int i = 0; i < arraySize; i++)
            {
                try
                {
                    myArray[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    myArray[i] = defaultValue;
                }
            }

            Console.WriteLine("Введенный массив: \n");

            foreach(int val in myArray)
            {
                Console.WriteLine(val);
            }

            Console.WriteLine("Сортировка прямым включением\n");

            for(int i = 1; i < myArray.Length; i++)
            {
                int val = myArray[i];
                int index = i;

                while((index > 0) && myArray[index - 1] > val)
                {
                    myArray[index] = myArray[index - 1];
                    index--;
                }
                myArray[index] = val;
            }

            Console.WriteLine("Отсортированный массив: \n");

            foreach (int val in myArray)
            {
                Console.WriteLine(val);
            }





            Console.ReadKey();



        }
    }
}
