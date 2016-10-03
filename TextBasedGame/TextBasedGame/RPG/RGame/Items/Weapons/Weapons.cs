using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Weapons
{
    public interface Weapons : ItemsInterface
    {
        /// <summary>
        /// The damage the weapons does
        /// </summary>
        int Damage { get; }
        int Price { get; }
        /// <summary>
        /// Total amount of health
        /// </summary>
        int totalHealth { get; }
        int remainingHealth { get; set; }
        /// <summary>
        /// The weapons name
        /// </summary>
        string Name { get; }
    }
}
