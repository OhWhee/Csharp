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
            /*Дана квадратная вещественная матрица размерности n. Найти количество нулевых
                элементов, стоящих: выше главной диагонали; ниже главной диагонали; выше и ниже
                побочной. */

            int[,] matrix = new int[3,3] { { 1, 0, 5 }, { 8, 3, 0 }, { 0, 4, 6 } };


            /*  1    0   5
                8    3   0
                0    4   6    */

            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix.GetUpperBound(1) + 1;
            int zerosUpperDiagonal = 0;
            int zerosUnderDiagonal = 0;
            int zerosUpperSubDiagonal = 0;
            int zerosUnderSubDiagonal = 0;

            if (rows != cols)
            {
                Console.WriteLine("Матрица не квадратная");
                
            }
            else
            {


                for (int i = 0; i < rows;i++){
                    for (int j = 0; j < rows; j++)
                    {
                        bool diagonal = i == j;
                        bool subdiagonal = i + j == rows - 1;
                        
                        if(j>i && !diagonal && matrix[i,j] == 0)
                        {
                            zerosUpperDiagonal++;
                        }
                        if (j < i && !diagonal && matrix[i, j] == 0)
                        {
                            zerosUnderDiagonal++;
                        }

                        if(!subdiagonal && i+j < rows && matrix[i, j] == 0)
                        {
                            zerosUpperSubDiagonal++;
                        }

                        if (!subdiagonal && i+j >= rows && matrix[i, j] == 0)
                        {
                            zerosUnderSubDiagonal++;
                        }
                    }

                }

                Console.WriteLine("Количество нулевых элементов выше основной диагонали: " + zerosUpperDiagonal.ToString());
                Console.WriteLine("Количество нулевых элементов ниже основной диагонали: " + zerosUnderDiagonal.ToString());
                Console.WriteLine("Количество нулевых элементов выше побочной диагонали: " + zerosUpperSubDiagonal.ToString());
                Console.WriteLine("Количество нулевых элементов ниже побочной диагонали: " + zerosUnderSubDiagonal.ToString());
                Console.ReadKey();

            }

        }
    }
}
