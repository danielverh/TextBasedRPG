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
            Inventory = settings.LoadInventory();
            if (settings.fLaunch)
            {
                settings.putString("name", OpenQuestion("Hi, What is your name? "));
                settings.putInt("health", 100);
                settings.putInt("hunger", 10);
                settings.putInt("strength", 1);
                settings.putInt("money", 100000);
                settings.Commit();
                // start new process
                System.Diagnostics.Process.Start(
                     Environment.GetCommandLineArgs()[0],
                     Environment.GetCommandLineArgs()[1]);

                // close current process
                Environment.Exit(0);
            }
            else
            {
                UpdateProps();
                settings.Commit();
            }
            while (true)
            {
                switch (Ask(new Question("Select an action", "Open shop", "List inventory", "Start debug quest.")))
            {
                case 1:
                    LoadLocation(new Shop());
                    break;
                case 2:
                        var weaponsDescription = Inventory.WeaponsItems.Select(i => i.Name).ToArray();
                        SayList(weaponsDescription);
                    break;
                case 3:
                    Story.Story.Quest1(this);
                    break;
            }
        }
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
        public void BuyWeapon(Weapons weapon)
        {
            if(weapon.Price <= this.Money)
            {
                settings.putInt("money", Money - weapon.Price);
                settings.Commit();
                this.Inventory.WeaponsItems.Add(weapon);
                settings.SaveInventory(Inventory);
                WriteLine(String.Format("Bought {0} for {1}$", weapon.Name, weapon.Price));
            }
            else
            {
                WriteLine(String.Format("Not enough money to buy {0} for {1}$", weapon.Name, weapon.Price));
            }
        }
    }
}
