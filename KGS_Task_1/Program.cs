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
                bool successfulConversion = Int32.TryParse(Console.ReadLine(), out gold);

                if (!successfulConversion)
                    throw new ArithmeticException("Количество золота должно быть целым числом.");

                if (gold <= 0)
                    throw new ArithmeticException("Введено неверное количество золота.");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message); // Вывод ошибки
                Environment.Exit(1); // Закончить программу из-за ошибки
            }
            
            Console.WriteLine($"{price} - цена за 1 кристалл");

            try
            {
                Console.Write("Сколько кристаллов вы хотите купить: ");
                bool successfulConversion = Int32.TryParse(Console.ReadLine(), out crystals);

                if (!successfulConversion)
                    throw new ArithmeticException("Количество кристаллов должно быть целым числом.");

                if (crystals <= 0)
                    throw new ArithmeticException("Введено неверное количество кристаллов.");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Environment.Exit(1);
            }

            int maxAmountOfCrystals = gold / price; // Сколько кристаллов можно купить за все деньги

            string result = maxAmountOfCrystals >= crystals 
                ? "\nВы купили " + crystals + " кристаллов. " + (gold - crystals * price) + " золота остается у вас в кошельке." 
                : "\nУ вас недостаточно денег, чтобы купить " + crystals + " кристаллов. Вы можете купить только " + maxAmountOfCrystals + " кристаллов.";

            Console.WriteLine($"{result}");
        }
    }
}
