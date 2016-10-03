
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items
{
    public class ItemsController
    {
        public static List<Food.Food> getFood { get { return new List<Food.Food>() { new Food.Apple() }; } }
        public static List<Weapons.Weapons> getWeapons { get { return new List<Weapons.Weapons>() { new Weapons.Sword(), new Weapons.Spear() }; } }
        public static List<Tools.Tool> getTools { get { return new List<Tools.Tool>() { new Tools.Axe(), new Tools.PickAxe() }; } }
    }
}
