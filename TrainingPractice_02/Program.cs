using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

// https://gist.github.com/gkeep/4db57a585b5ddbed73a1f99da71a837e#file-1-cpp

namespace TrainingPractice_02
{
    class Program
    {
        static int[] primeArray;

        static bool[] InitialArray(int size)
        {
            bool[] array = new bool[size];
            for (int i = 0; i < array.Length; i++)
                array[i] = true;

            return array;
        }

        static void printPrimeNumbers(int pos_x, int pos_y)
        {
            Console.SetCursorPosition(pos_x + 50, pos_y);
            int line = 1;

            Console.WriteLine("Prime numbers:");
            Console.SetCursorPosition(pos_x + 50, pos_y + line);
            for (int i = 0; i < primeArray.Length; i++)
            {
                if (primeArray[i] != 0)
                    Console.Write($"{primeArray[i]} ");

                if (i % 10 == 0)
                {
                    Console.SetCursorPosition(pos_x + 50, pos_y + line);
                    line++;
                }
            }
            Console.SetCursorPosition(pos_x, pos_y);
        }

        static void printArray(bool[] array, int highlight_index)
        {
            Console.Clear();
            printPrimeNumbers(Console.CursorLeft, Console.CursorTop);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == highlight_index)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write($"{Convert.ToInt32(array[i])} ");

                if ((i + 1) % 10 == 0)
                    Console.Write("\n");

                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ReadKey();
        }

        static void printArrayInProgress(bool[] array)
        {
            for (int i = 2; i * i < array.Length; i++)
            {
                if (array[i])
                {
                    for (int j = i * i; j < array.Length; j += i)
                    {
                        array[j] = false;
                        printArray(array, j);
                    }
                }
            }
        }

        static void fillPrimeArray(bool[] array)
        {
            int iter = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i])
                {
                    primeArray[iter] = i;
                    iter++;
                }
            //printPrimeNumbers(Console.CursorLeft, Console.CursorTop);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = Int32.Parse(Console.ReadLine());

            bool[] arrayOfOnes = InitialArray(size);
            primeArray = new int[size];

            fillPrimeArray(arrayOfOnes);
            printArrayInProgress(arrayOfOnes);
        }
    }
}
