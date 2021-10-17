using System;
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

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "fight")
                {
                    heroGame.Fight(bossGame);
                }
                if (command == "rest")
                {
                    heroGame.Rest();
                }
                Thread.Sleep(500);

                if (bossGame.Stamina >= 10)
                {
                    bossGame.Strength = rng.Next(0, 30);
                    bossGame.Fight(heroGame);
                    continue;
                }
                bossGame.Rest();
            }
        }
    }
}
