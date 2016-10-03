using RPG.Utilities;
using RPG.RGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.RGame.Items.Food;
using RPG.RGame.Items.Weapons;
using RPG.RGame.Items.Tools;

namespace RPG.RGame.Player.Inventory
{
    internal class IMS
    {
        private Player player;
        private Settings settings;
        public IMS(Player _player, Settings _settings)
        {
            player = _player;
            settings = _settings;
        }
        public void Load()
        {
            List<Food> foodItems = new List<Food>();
            List<Weapons> weapons = new List<Weapons>();
            List<Tool> tools = new List<Tool>();

            for(int i = 0; true; i++)
            {
            }
        }
    }
}
