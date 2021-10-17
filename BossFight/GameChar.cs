using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    class GameChar
    {
        public string Name { get; set; }
        public int Health { get; private set; }
        public int Strength { get; set; }
        public int Stamina { get; private set; }

        public GameChar(string name ,int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
            Name = name;
        }

        public void Fight(GameChar target)
        {
            target.Health -= Strength;
            Stamina -= 10;
            Console.WriteLine($"{Name} attacked {target.Name} for {Strength} damage, the targets HP is now {target.Health}");
        }

        public void Rest()
        {
            Stamina += 10;
            Console.WriteLine($"The {Name} is resting, their stamina is now: {Stamina}");
        }
    }
}
