using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дополнительное_задание
{
    class Program
    {
        static void Main(string[] args)
        {
            //int Length = Convert.ToInt32(Console.ReadLine());
            //Array11_Work(Length);
             //Array_turning();
           Array_Shift();
        }
        static int Array11_Work(int Length)
        {
            int[] Array1 = new int[Length];
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                Array1[i] = random.Next(-30, 45);
                Console.Write("{0,4} ", Array1[i]);
                if (i % 10 == 9)
                    Console.WriteLine();
            }
            Console.Write("\n");
            for (int i = Array1.Length - 1; i >= 0; i--)
            {
                if (Array1[i] < 0)
                {
                    continue;
                }
                Console.Write(Array1[i] + " ");
            }
            return 0;
        }
        static int Array_turning()
        {
            int[,] mas = new int[7, 7];
            Random rand = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rand.Next(10);
                    Console.Write("{0}\t", mas[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < mas.GetLength(1); j++)
            {
                for (int i = mas.GetLength(0) - 1; i >= 0; i--)
                {
                    Console.Write("{0}\t", mas[i, j]);
                }
                Console.WriteLine();
            }
            return 0;
        }
        static int Array_Shift()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 5;
            int tmp;
            int nextInd = 0;

            Console.WriteLine(string.Join(" ", arr));

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                nextInd += k;
                nextInd %= arr.Length;

                tmp = arr[nextInd];
                arr[nextInd] = arr[0];
                arr[0] = tmp;
            }

            Console.WriteLine(string.Join(" ", arr));
            return 0;
        }
    }
}
