using System;

namespace KGS_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while (input != "exit")
            {
                Console.Write("Введите что-нибудь (exit для завершения цикла программы): ");
                input = Console.ReadLine();
            }

            Console.WriteLine("\nВы вышли из цикла!");
        }
    }
}
