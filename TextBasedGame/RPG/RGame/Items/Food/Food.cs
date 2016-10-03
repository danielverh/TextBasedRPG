using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Food
{
    public interface Food : ItemsInterface
    {
        int healthRestore { get; set; }
        int hungerRestore { get; set; }
        int Price { get; set; }
        string Name { get; set; }
        void Eat();
    }
}
