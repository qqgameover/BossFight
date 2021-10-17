using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    class GameChar
    {
        private static readonly Random rng = new Random();
        public string Name { get; set; }
        public int Health { get; private set; }
        public int Strength { get; set; }
        public int Stamina { get; private set; }
        public List<Item> ItemList { get; private set; }
        public GameChar(string name ,int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
            Name = name;
            ItemList = new List<Item>();
            while (ItemList.Count < 10)
            {
                ItemList.Add(new Item(rng.Next(0, 3)));
            }
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

        public void UseItem()
        {
            var item = ItemList.FirstOrDefault();
            if (item.ItemType == "HealthPotion")
            {
                Health += 30;
                Console.WriteLine($"The hero used a Health potion, their health is now {Health}");
            }

            if (item.ItemType == "stm potion")
            {
                Stamina += 20;
                Console.WriteLine($"The hero used a stamina potion, their stamina is now {Stamina}");
            }

            if (item.ItemType == "str potion")
            {
                Strength += 30;
                Console.WriteLine($"The hero used a str potion, their attack is empowered for one round");
            }
            ItemList.RemoveAt(0);
        }
    }
}
