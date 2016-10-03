using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Tools
{
    public class PickAxe : Tool
    {
        public PickAxe()
        {
            Name = "Pickaxe";
            Damage = 20;
            Price = 120;
            totalHealth = 80;
            remainingHealth = 80;
        }
        public Criticals Critical { get { return Criticals.Stone; } }

        public int Damage { get; private set; }

        public string Name { get; private set; }

        public int Price { get; }

        public int remainingHealth { get; set; }

        public int totalHealth { get; private set; }

        public ItemType itemType { get { return ItemType.Tool; } }
    }
}
