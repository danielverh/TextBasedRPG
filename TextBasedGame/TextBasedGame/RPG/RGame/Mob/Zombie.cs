using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.RGame.Player;

namespace RPG.RGame.Mob {
    internal class Zombie : Mob {
        public Zombie() {
            Damage = 5;
            totalHealth = 25;
            remainingHealth = 25;
            Name = "Zombie";
        }

        public int Damage { get; }
        public int totalHealth { get; }
        public int remainingHealth { get; set; }
        public int Defense { get; set; }
        public string Name { get; set; }

        public void Attack(Player.Player _player){
            _player.Health -= Damage;
        }

        public void recieveAttack(Player.Player _player)
        {
            remainingHealth -= _player.holdingWeapon.Damage;
        }

    }
}
