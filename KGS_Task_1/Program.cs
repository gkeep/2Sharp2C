using System;

namespace KGS_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int price = 2; // Цена 1 кристалла
            int gold = 0;
            int crystals = 0;

            try
            {
                Console.Write("Количество золота: ");   
                bool successful_conversion = Int32.TryParse(Console.ReadLine(), out gold);

                if (!successful_conversion)
                    throw new ArithmeticException("Количество денег должно быть числом.");

                if (gold <= 0)
                    throw new ArithmeticException("Введено неверное количество денег.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // Вывод ошибки
                Environment.Exit(1); // Закончить программу из-за ошибки
            }
            
            Console.WriteLine($"{price} - цена за 1 кристалл");

            try
            {
                Console.Write("Сколько кристаллов вы хотите купить: ");
                bool successful_conversion = Int32.TryParse(Console.ReadLine(), out crystals);

                if (!successful_conversion)
                    throw new ArithmeticException("Количество денег должно быть числом.");

                if (crystals <= 0)
                    throw new ArithmeticException("Введено неверное количество кристаллов.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            int can_buy = gold / price; // Сколько кристаллов можно купить за все деньги

            string result = can_buy >= crystals 
                ? "\nВы купили " + crystals + " кристаллов. " + (gold - crystals * price) + " золота остается у вас в кошельке." 
                : "\nУ вас недостаточно денег, чтобы купить " + crystals + " кристаллов. Вы можете купить " + can_buy + " кристаллов.";

            Console.WriteLine($"{result}");

            // То же самое, только с использованием if:
            //if (can_buy >= crystals)
            //{
            //    Console.WriteLine($"\nВы купили {crystals} кристаллов. {gold - crystals * price} золота остается у вас в кошельке.");
            //}
            //else
            //{
            //    Console.WriteLine($"\nУ вас недостаточно денег, чтобы купить {crystals} кристаллов. Вы можете купить {can_buy} кристаллов.");
            //}
        }
    }
}
