using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Реализовать обработку исключительных ситуаций. Варьируя
входными данными обеспечить возникновение исключительной ситуации.
Организовать информативный вывод данных о возникшем исключении на
экран с предложением продолжить выполнение, проигнорировав ошибку,
или завершить выполнение программы. */

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[5];

            Console.WriteLine("Введите целые числа");
            for(int i =0; i< mas.Length; i++)
            {
                bool repeat = false;
                try
                {
                    string inputText = Console.ReadLine();
                    mas[i] = int.Parse(inputText);


                }
                catch (FormatException ex)
                {
                    repeat = true;
                    Console.WriteLine("Введенное значение не является целым числом");
                    Console.WriteLine("Введите корректное целое число");
                    Console.WriteLine(ex.Message);
                    while (repeat)
                    {
                        try
                        {
                            mas[i] = int.Parse(Console.ReadLine());
                            repeat = false;
                        }
                        catch (FormatException ex2)
                        {
                            Console.WriteLine("Введенное значение все еще не является целым числом!");
                            Console.WriteLine("Введите корректное целое число");
                            Console.WriteLine(ex2.Message);


                            bool repeat2 = true;
                            while (repeat2)
                            {
                                Console.WriteLine("\nВыберите дальнешее действие:\nПродолжить ввод - 'n'\nЗаменить введенный символ нулем - 'z'\nЗавершить программу - 'q'");
                                var input = Console.ReadKey();

                                switch (input.Key)
                                {
                                    case ConsoleKey.N:
                                        {
                                            Console.WriteLine("\n");
                                            repeat2 = false;
                                            
                                            break;
                                        }
                                    case ConsoleKey.Z:
                                        {
                                            Console.WriteLine("\n");
                                            mas[i] = 0;
                                            repeat2 = false;
                                            repeat = false;
                                            break;
                                        }
                                    case ConsoleKey.Q:
                                        {
                                            Environment.Exit(1);
                                            break;
                                        }
                                }

                            }
                        }
                    }
                }
            }

            Console.WriteLine("\n");
            for (int i = 0; i < mas.Length; i++) Console.WriteLine(mas[i]);
            Console.ReadKey();
        }
    }
}
