using System;

namespace KGS_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "a-VERY-strong-password";
            string input = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите пароль: ");
            Console.ForegroundColor = ConsoleColor.White;

            while (input != password)
            {
                if (input != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Введен неверный пароль. Введите пароль: ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("\nСекретное сообщение!");
        }
    }
}
