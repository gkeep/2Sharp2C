using System;

namespace KGS_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int price = 3; // Цена 1 кристалла

            Console.Write("Количество золота: ");   
            int gold = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{price} - цена за 1 кристалл");
            Console.Write("Сколько кристаллов вы хотите купить: ");
            int crystals = Int32.Parse(Console.ReadLine());

            int can_buy = gold / price; // Сколько кристаллов можно купить за все деньги

            if (can_buy >= crystals)
            {
                Console.WriteLine($"\nВы купили {crystals} кристаллов. {gold - can_buy * price} золота остается у вас в кошельке.");
            }
            else
            {
                Console.WriteLine($"\nУ вас недостаточно денег, чтобы купить {crystals} кристаллов. Вы можете купить {can_buy} кристаллов.");
            }
        }
    }
}
