using System;

namespace KGS_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "a-VERY-strong-password";
            string input = "";
            int attemptCounter;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите пароль: ");
            Console.ForegroundColor = ConsoleColor.White;

            for (attemptCounter = 1; (input != password) && (attemptCounter <= 3); attemptCounter++)
            {
                if (input != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Введен неверный пароль. У вас осталось {3 - attemptCounter} попыток. Введите пароль: ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                input = Console.ReadLine();
            }

            if (input == password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nСекретное сообщение!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n3 неверные попытки, закрытие программы.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
