using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Weapons
{
    public class Spear : Weapons
    {
        private string _name = "Spear";
        public Spear()
        {
            Damage = 8;
            Price = 30;
            totalHealth = 30;
            remainingHealth = 30;
        }
        public Spear(int _remainingHealth)
        {
            Damage = 8;
            Price = 30;
            totalHealth = 30;
            remainingHealth = _remainingHealth;
        }
        public string Name { get { return _name; } }

        public int Damage { get; private set; }

        public int Price { get; private set; }

        public int totalHealth { get; private set; }

        public int remainingHealth { get; set; }

        public ItemType itemType { get { return ItemType.Weapon; } }
    }
}
