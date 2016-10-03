using RPG.RGame.Items.Weapons;
using RPG.RGame.Places;
using RPG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG.RConsole;
namespace RPG.RGame.Player
{
    internal class Player
    {
        private Settings settings;

        public string Name { get; private set; }  // The players name.
        /// <summary>
        /// the remaining health max. 100 min. 0 (negative is dead)
        /// Health = <0,100]
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// The players bonus on his weapon damage
        /// </summary>
        public int Strength { get; private set; }
        public Weapons holdingWeapon { get; set; }
        /// <summary>
        /// Remaining hunger max 10 min 0 (negative is dead)
        /// </summary>
        public int Hunger { get; private set; }
        public Inventory.Inventory Inventory { get; set; } 
        public int Money { get; set; }
        public Player()
        {
            settings = new Settings();
            Inventory = new Inventory.Inventory();
            if (settings.fLaunch)
            {
                settings.putString("name", OpenQuestion("Hi, What is your name? "));
                settings.putInt("health", 100);
                settings.putInt("hunger", 10);
                settings.putInt("strength", 1);
                settings.putInt("money", 100);
            }
            else
            {
                UpdateProps();
            }
            settings.Commit();
            LoadLocation(new Shop());
        }
        public void LoadLocation(Places.Places place)
        {
            place.Initialize(this);
        }
        public void UpdateProps()
        {
            Name = settings.getString("name");
            Health = settings.getInt("health");
            Strength = settings.getInt("strength");
            Hunger = settings.getInt("hunger");
            Money = settings.getInt("money");
        }
    }
}
