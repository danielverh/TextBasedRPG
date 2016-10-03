using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG.RConsole;

namespace RPG.RGame.Items.Food
{
    [Serializable]
    public class Apple : Food
    {
        public Apple() {
            Name = "Apple";
            Price = 1;
            healthRestore = 2;
            hungerRestore = 5;
        }

        public void Eat() {
            WriteLine("Nom nom, that apple was delicious!");
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int healthRestore { get; set; }

        public int hungerRestore { get; set; }

        public ItemType itemType { get { return ItemType.Food; } }
    }
}
