using System;
using System.Linq;
using System.Threading;

namespace BossFight
{
    class Program
    {
        private static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            var heroGame = new GameChar("Hero", 100, 20, 40);
            var bossGame = new GameChar("Boss", 400, 30, 10);
            var count = 0;
            var emergency = false;

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "fight" && heroGame.Stamina >= 10)
                {
                    heroGame.Fight(bossGame);
                    count++;
                    if (heroGame.Health < 30)
                    {
                        emergency = true;
                        heroGame.ItemList[0] = new Item(0);
                        heroGame.UseItem();
                    }
                    if(count == 3)
                    {
                        if (!emergency)
                        {
                            heroGame.UseItem();
                            heroGame.Strength = 30;
                            count = 0;
                        }
                    }
                }
                else
                {
                    heroGame.Rest();
                }
                emergency = false;
                Thread.Sleep(500);
                if (bossGame.Health <= 0)
                {
                    Console.WriteLine("The hero wins! The boss has been defeated");
                    break;
                }

                if (bossGame.Stamina >= 10)
                {
                    bossGame.Strength = rng.Next(0, 30);
                    bossGame.Fight(heroGame);
                    if (heroGame.Health <= 0)
                    {
                        Console.WriteLine("The boss wins! The hero has been defeated");
                        break;
                    }
                    continue;
                }
                bossGame.Rest();
            }
        }
    }
}
