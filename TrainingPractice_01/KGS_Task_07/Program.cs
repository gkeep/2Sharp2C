using System;
using System.Net;

namespace KGS_Task_07
{
    class Program
    {
        static Random random = new Random();

        static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, 20);
        }

        static void Shuffle(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int randIndex = i + (int)(random.NextDouble() * (n - i));
                int temp = array[randIndex];
                array[randIndex] = array[i];
                array[i] = temp;
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (int value in array)
                Console.Write($"{value} ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] array = new int[10];

            // заполняем массив случайными числами
            FillArray(array);
            PrintArray(array);

            // перемешиваем массив методом Shuffle
            Shuffle(array);

            PrintArray(array);
        }
    }
}
