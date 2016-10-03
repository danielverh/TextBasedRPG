using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Mob {
    internal interface Mob {
        int Damage { get; }
        int Defense { get; }
        int totalHealth { get; }
        int remainingHealth { get; set; }
        string Name { get; set; }
        void Attack(Player.Player _player);
        void recieveAttack(Player.Player _player);
    }
}
