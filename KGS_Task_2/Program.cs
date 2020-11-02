using System;

namespace KGS_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while (input != "exit")
            {
                input = Console.ReadLine();
                Console.WriteLine($"Вы ввели {input}.");
            }

            Console.WriteLine("\nВы вышли из цикла!");
        }
    }
}
