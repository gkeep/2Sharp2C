using System;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;

namespace KGS_Task_05
{
    class Program
    {
        static int initialX = 0;
        static int initialY = 0;
        static int coins = 0;
        static int steps = 0;

        static public char[,] FillLabyrinthArray()
        {
            string[] newFile = File.ReadAllLines("..\\..\\..\\labyrinth.txt");
            char[,] array = new char[newFile.Length, newFile[0].Length];


            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    array[i, j] = newFile[j][i];

                    if (array[i, j] == '■')
                    {
                        initialX = i;
                        initialY = j;
                    }
                }
            }

            return array;
        }

        static public void Draw(char[,] array)
        {
            Console.Clear();
            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static public bool isNotWall(char[,] array, int pos_x, int pos_y)
        {
            switch (array[pos_x, pos_y])
            {
                case ' ':
                    steps += 1;
                    return true;
                case '·':
                    coins += 1;
                    steps += 1;
                    CoinCounter(array, pos_x, pos_y);
                    return true;
                case '■':
                    steps += 1;
                    return true;
                case '@':
                    WinScreen();
                    steps += 1;
                    return true;
                default:
                    return false;
            }
        }

        static public void Move(char[,] array, int pos_x, int pos_y)
        {
            int newVal;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    newVal = pos_x - 1;
                    if (isNotWall(array, newVal, pos_y))
                      pos_x = newVal;
                    break;
                case ConsoleKey.RightArrow:
                    newVal = pos_x + 1;
                    if (isNotWall(array, newVal, pos_y))
                        pos_x = newVal;
                    break;
                case ConsoleKey.UpArrow:
                    newVal = pos_y - 1;
                    if (isNotWall(array, pos_x, newVal))
                        pos_y = newVal;
                    break;
                case ConsoleKey.DownArrow:
                    newVal = pos_y + 1;
                    if (isNotWall(array, pos_x, newVal))
                        pos_y = newVal;
                    break;
            }
            Console.SetCursorPosition(pos_x, pos_y);
            Move(array, pos_x, pos_y);
        }

        static void CoinCounter(char[,] array, int pos_x, int pos_y)
        {
            Console.SetCursorPosition(60, 5);
            if (coins > 0)
                Console.WriteLine($"Вы собрали {coins} монеток!");
            Console.SetCursorPosition(pos_x, pos_y);
            array[pos_x, pos_y] = ' ';
            Console.Write(array[pos_x, pos_y]);
        }

        static void WinScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 10);
            Console.Write($"Вы прошли лабиринт за {steps} шагов и собрали {coins} монеток!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            char[,] mainArray = FillLabyrinthArray();
            Draw(mainArray);
            CoinCounter(mainArray, initialX, initialY);
            Console.SetCursorPosition(initialX, initialY);
            Move(mainArray, initialX, initialY);

            Console.ReadKey();
        }
    }
}
