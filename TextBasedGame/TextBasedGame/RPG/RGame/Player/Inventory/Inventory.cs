using RPG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Player.Inventory
{
    internal struct Inventory
    {
        public List<Items.Food.Food> FoodItems { get; set; }
        public List<Items.Weapons.Weapons> WeaponsItems { get; set; }
        public List<Items.Tools.Tool> ToolItems { get; set; }
    }
}
