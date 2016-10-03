using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items.Tools
{
    public interface Tool : ItemsInterface
    {
        Criticals Critical { get; }
        int Damage { get; }
        int Price { get; }
        /// <summary>
        /// Total amount of health
        /// </summary>
        int totalHealth { get; }
        int remainingHealth { get; set; }
        /// <summary>
        /// The tools name
        /// </summary>
        string Name { get; }
    }
    public enum Criticals { Wood, Iron, Stone, Animals}
}
