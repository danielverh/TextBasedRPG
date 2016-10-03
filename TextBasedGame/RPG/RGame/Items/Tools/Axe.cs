using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Tools
{
    public class Axe : Tool
    {
        public Axe()
        {
            Name = "Axe";
            Damage = 10;
            Price = 100;
            totalHealth = 50;
            remainingHealth = 50;
        }
        public Criticals Critical { get { return Criticals.Wood; } }

        public int Damage { get; private set; }

        public string Name { get; private set; }

        public int Price { get; }

        public int remainingHealth { get; set; }

        public int totalHealth { get; private set; }

        public ItemType itemType { get { return ItemType.Tool; } }
    }
}
