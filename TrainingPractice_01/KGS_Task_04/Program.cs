using System;

namespace KGS_Task_04
{
    public class Helper
    {
        static public void colorText(string text, ConsoleColor color, bool line = true)
        // Вспомогательная функция, которая меняет цвет для данного текста
        {
            Console.ForegroundColor = color;

            if (line)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Player
    {
        public int health;

        public int spellDamage(string spell)
        {
            int damage;
            int playerDamage;

            switch (spell.ToLower())
            {
                case "frostbolt":
                    damage = 45;
                    Helper.colorText($"Вы нанесли {damage} урона противнику.", ConsoleColor.Green);
                    return damage;
                case "fireball":
                    damage = 60;
                    Helper.colorText($"Вы нанесли {damage} урона противнику.", ConsoleColor.Green);
                    return damage;
                case "blizzard":
                    damage = 200;
                    playerDamage = 70;
                    health -= playerDamage;
                    Helper.colorText($"Вы нанесли {damage} урона противнику. Но вы сами попали под метель и получили {playerDamage} урона.", ConsoleColor.Green);
                    return damage;
                case "lightning strike":
                    damage = 300;
                    playerDamage = 170;
                    health -= playerDamage;
                    Helper.colorText($"Вы нанесли {damage} урона противнику. Но молния попала и в вас, вы получили {playerDamage} урона.", ConsoleColor.Green);
                    return damage;
                case "cup of tea":
                    if (health <= 100)
                    {
                        health += 80;
                        Helper.colorText("Вы выпили чашку чая и чувствуете себя лучше.", ConsoleColor.Green);
                    }
                    else
                        Helper.colorText("Вы можете использовать это заклинание только, когда у вас меньше чем 100 ХП.", ConsoleColor.Red);

                    return 0;
            }
            Console.WriteLine("Вы замешкались и не использовали заклинание.");
            return 0;
        }
    }

    public class Enemy
    {
        public int health;
        public int attackStrength = 55;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Player player = new Player();
            Enemy enemy = new Enemy();

            Console.WriteLine("Заклинания: \n" +
                "   Frostbolt        - наносит 45 урона противнику\n" +
                "   Fireball         - наносит 60 урона противнику\n" +
                "   Blizzard         - наносит 200 урона противнику, но вы можете сами попасть под метель\n" +
                "   Lightning Strike - наносит 370 урона противнику, но вы можете сами попасть под метель\n" +
                "   Cup of Tea       - вылечивает вас на 80 ХП, но вы не можете использовать это заклинание пока у вас больше 100 ХП.\n");

            player.health = random.Next(600, 700);
            enemy.health = random.Next(500, 800);

            for (int turn = 1; (player.health > 0) && (enemy.health > 0); turn++)
            {
                Helper.colorText($"{turn} ход. ", ConsoleColor.Yellow);
                Helper.colorText($"У вас {player.health} ХП. У противника - {enemy.health}.", ConsoleColor.Cyan, true);
                Helper.colorText("\nЗаклинание: ", ConsoleColor.Blue, false);
                string spell = Console.ReadLine();

                enemy.health -= player.spellDamage(spell);
                if (spell.ToLower() != "cup of tea")
                {
                    enemy.attackStrength = random.Next(20, 100);
                    player.health -= enemy.attackStrength;
                    Helper.colorText($"Противник нанес вам {enemy.attackStrength} урона.", ConsoleColor.Red);
                }

                Console.Write("\n-----\n");
            }

            Console.Clear(); // очистка консоли после конца игры

            if (enemy.health <= 0)
            {
                if (player.health > 0)
                    Helper.colorText("Вы выиграли!", ConsoleColor.Green, true);
                else
                    Helper.colorText("Ничья!", ConsoleColor.White, true);
            }
            else
                Helper.colorText("Вы проиграли!", ConsoleColor.Red, true);
        }
    }
}
