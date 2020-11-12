using System;

/*
 * Sieve of Eratosphenes implementation on C++: https://gist.github.com/gkeep/4db57a585b5ddbed73a1f99da71a837e#file-1-cpp
 * 
 * Prime numbers up to 100:
 * 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
 */

namespace TrainingPractice_02
{
    public class Helper
    {
        // Вспомогательная функция, которая меняет цвет для данного текста
        static public void ColorText(string text, ConsoleColor color, bool line = true)
        {
            Console.ForegroundColor = color;

            if (line)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Program
    {
        static int[] primeArray;
        static int loopIdx = 1;

        static bool[] InitialArray(int size)
        {
            bool[] array = new bool[size];

            for (int i = 1; i < array.Length; i++)
                array[i] = true;

            return array;
        }

        static void PrintPrimeNumbers(int pos_x, int pos_y)
        {
            int topOffset = 3;
            Console.SetCursorPosition(50, topOffset);
            int line = 1;

            Console.WriteLine("Простые числа:");
            Console.SetCursorPosition(50, topOffset + line);
            for (int i = 0; i < primeArray.Length; i++)
            {
                if (primeArray[i] != 0)
                    Console.Write($"{primeArray[i]} ");

                if (i % 10 == 0)
                {
                    Console.SetCursorPosition(50, topOffset + line);
                    line++;
                }
            }
            Console.SetCursorPosition(pos_x, pos_y);
        }

        static void PrintInfo(int pos_x, int pos_y, int mul)
        {
            int topOffset = 0;

            Console.SetCursorPosition(50, topOffset);
            Helper.ColorText("Enter", ConsoleColor.Cyan, false);
            Console.Write(" - продолжить.");

            Console.SetCursorPosition(50, topOffset + 1);
            Console.Write("Шаг ");
            Helper.ColorText($"{loopIdx}", ConsoleColor.Yellow, false);
            Console.Write($" - удаление чисел, кратных {mul}");

            Console.SetCursorPosition(pos_x, pos_y);
        }

        static void PrintArray(bool[] array, int highlightIndex)
        {
            int idx = 0;
            Console.Write("  ");
            for (int i = 1; i < array.Length; i++)
            {
                if (i < highlightIndex && array[i])
                {
                    primeArray[idx] = i;
                    idx++;
                }

                if (i == highlightIndex)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (array[i] && i < highlightIndex)
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write($"{Convert.ToInt32(array[i])} ");

                if ((i + 1) % 10 == 0)
                    Console.Write("\n");

                Console.ForegroundColor = ConsoleColor.White;
            }

            PrintPrimeNumbers(Console.CursorLeft, Console.CursorTop);
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        static void Start(bool[] array)
        {
            for (int i = 2; i * i < array.Length; i++)
            {
                if (array[i])
                    for (int j = i * i; j < array.Length; j += i)
                    {
                        array[j] = false;

                        Console.Clear();
                        PrintInfo(Console.CursorLeft, Console.CursorTop, i);
                        PrintArray(array, j);
                    }
                primeArray = new int[primeArray.Length]; // обнуляем массив, чтобы избавиться от лишних чисел
                loopIdx++;
            }
            Done();
        }

        static void Done()
        {
            Console.SetCursorPosition(10, Console.CursorTop + 10);
            Helper.ColorText("Выполнение алгоритма закончено!", ConsoleColor.Cyan, true);
        }

        static void Main()
        {
            Console.Clear();
            Console.Write("Добро пожаловать в визуализацию ");
            Helper.ColorText("Решета Эратосфена", ConsoleColor.Green, true);
            Console.Write("Введите размер матрицы: ");

            int size = 0;
            try
            {
                bool suuccessfulConversion = Int32.TryParse(Console.ReadLine(), out size);

                if (!suuccessfulConversion || size <= 0)
                    throw new ArithmeticException("Размер должен быть положительным целым числом.");
            }
            catch (Exception e)
            {
                Helper.ColorText($"\n{e.Message}", ConsoleColor.Red);
                Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова.");
                Console.ReadKey();
                Main();
                Environment.Exit(0); // после выхода из вызванного цикла Main, программа все равно будет пытаться пойти дальше с неверным size
            }

            bool[] arrayOfOnes = InitialArray(size);
            primeArray = new int[size];

            Start(arrayOfOnes);

            Console.ReadKey();
        }
    }
}
