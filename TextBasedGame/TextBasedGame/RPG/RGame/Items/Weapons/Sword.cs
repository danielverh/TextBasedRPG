using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Weapons
{
    [Serializable]
    public class Sword : Weapons
    {
        public Sword()
        {
            Name = "Sword";
            Damage = 10;
            Price = 100;
            totalHealth = 50;
            remainingHealth = 50;
        }
        public Sword(int _remainingHealth)
        {
            Name = "Sword";
            Damage = 10;
            Price = 100;
            totalHealth = 50;
            remainingHealth = _remainingHealth;
        }
        public string Name { get; private set; }

        public int Damage { get; private set; }

        public int Price { get; private set; }

        public int totalHealth { get; private set; }

        public int remainingHealth { get; set; }

        public ItemType itemType { get { return ItemType.Weapon; } }

    }
}
