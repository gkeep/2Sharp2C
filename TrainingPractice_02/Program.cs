using System;

/*
 * SoE implementation on C++: https://gist.github.com/gkeep/4db57a585b5ddbed73a1f99da71a837e#file-1-cpp
 * 
 * Prime numbers up to 100:
 * 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
 */

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

        static void printArray(bool[] array, int highlightIndex, ConsoleColor highlightColor)
        {
            Console.Clear();
            printPrimeNumbers(Console.CursorLeft, Console.CursorTop);

            for (int i = 0; i < array.Length; i++)
            {
                if (i < highlightIndex)
                    fillPrimeArray(array, highlightIndex);

                if (i == highlightIndex)
                    Console.ForegroundColor = highlightColor;
                else if (array[i] && i < highlightIndex)
                    Console.ForegroundColor = ConsoleColor.Green;

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
                if (array[i])
                    for (int j = i * i; j < array.Length; j += i)
                    {
                        array[j] = false;
                        printArray(array, j, ConsoleColor.Red);
                    }
        }

        static void fillPrimeArray(bool[] array, int stop_index)
        {
            primeArray = new int[primeArray.Length]; // обнуляем массив, чтобы избавиться от лишних чисел
            int iter = 0;
            for (int i = 1; i < stop_index; i++)
                if (array[i])
                {
                    primeArray[iter] = i;
                    iter++;
                }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = 0;
            try
            {
                bool suuccessfulConversion = Int32.TryParse(Console.ReadLine(), out size);

                if (!suuccessfulConversion || size <= 0)
                    throw new ArithmeticException("Size must be a positive integer.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            bool[] arrayOfOnes = InitialArray(size);
            primeArray = new int[size];

            printArrayInProgress(arrayOfOnes);
        }
    }
}
