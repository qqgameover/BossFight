using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossFight
{
    class Item
    {
        public string ItemType { get; set; }
        public Item(int itemType)
        {
            ItemType = itemType switch
            {
                0 => "HealthPotion",
                1 => "strPotion",
                2 => "stm potion",
                _ => ItemType
            };
        }
    }
}
