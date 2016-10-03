using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Utilities;
using static RPG.RConsole;

namespace RPG.RGame.Mob
{
    internal class Chicken : Mob
    {
        public Chicken()
        {
            Damage = 0;
            totalHealth = 5;
            remainingHealth = 5;
            Name = "Chicken";
        }

        public int Damage { get; }
        public int totalHealth { get; }
        public int remainingHealth { get; set; }
        public int Defense { get; set; }
        public string Name { get; set; }

        public void Attack(Player.Player _player)
        {
            _player.Health -= Damage;
        }

        public void recieveAttack(Player.Player _player)
        {
            remainingHealth -= _player.holdingWeapon.Damage;
            if (remainingHealth <= 0)
            {
                KillChicken();
            }
        }

        public void KillChicken()
        {
            WriteLine("Choock Choock!", fColor: ConsoleColor.Red);
        }
    }
}
