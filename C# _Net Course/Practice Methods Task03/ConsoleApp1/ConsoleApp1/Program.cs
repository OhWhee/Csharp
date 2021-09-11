using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Set(int a, ref int b, out int c) { a = 10; b = 5; c = a; }
        static int Min(params int[] values)
        {
            int min = int.MaxValue;
            for (int i = 0; i < values.Length; i++)
                if (values[i] < min) min = values[i];
            return min;
        }

        static void BetweenAandB(int a, int b, params int[] values)
        {
   
            for (int i = 0; i < values.Length; i++)
                if (values[i] > a && values[i] < b) Console.WriteLine(values[i]);
        }

        static void Main(string[] args)
        {
            Square square1 = new Square();
            square1.SetSide(4);
            Console.WriteLine("square1 side = {0}", square1.GetSide());

            Square square2 = new Square();
            square2.SetSide(11);
            Console.WriteLine("square2 side = {0}", square2.GetSide());

            Square square3 = new Square(6);
            Console.WriteLine("square3 side = {0}", square3.GetSide());


            Triangle triangle1 = new Triangle();
            Console.WriteLine("triangle1 area = {0}", triangle1.Area(7, 7));

            Triangle triangle2 = new Triangle();
            Console.WriteLine("triangle2 area = {0}", triangle2.Area(10, 10, 10));

            int A = 1;
            int B = 2;
            int C = 0;

            Console.WriteLine("A = {0} B = {1} C = {2}", A, B, C);
            Set(A, ref B, out C);
            Console.WriteLine("A = {0} B = {1} C = {2}", A, B, C);

            Console.WriteLine(Min(new int[] { 6, 7, 9, 1, 2, 5, 6, 11 }));

            Console.WriteLine(Min(6, 7, 9, 1, 2, 5, 6, 11));
            Console.WriteLine();

            BetweenAandB(1, 10, new int[] { 7, 6, 9, 2, 0, 5, 8, 3, 4, 15, 34, 35 });


            Console.ReadKey();
        }
    }
}
