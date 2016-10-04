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
            settings.Committed += Settings_Committed;
            Inventory = settings.LoadInventory();
            if (settings.fLaunch)
            {
                settings.putString("name", OpenQuestion("Hi, What is your name? "));
                settings.putInt("health", 100);
                settings.putInt("hunger", 10);
                settings.putInt("strength", 1);
                settings.putInt("money", 100000);
                settings.Commit();
            }
            else
            {
                UpdateProps();
                settings.Commit();

            }
            while (true)
            {
                switch (Ask(new Question("Select an action", "Open shop", "List inventory", "Start debug quest.", "Settings")))
                {
                    case 1:
                        LoadLocation(new Shop());
                        break;
                    case 2:
                        var weaponsDescription = Inventory.WeaponsItems.Select(i => i.Name).ToArray();
                        int index = Ask(new Question("Your inventory, select an number for more info.", weaponsDescription)) - 1;
                        var weapon = Inventory.WeaponsItems[index];
                        WriteLine(String.Format("This {0} deals {1} damage, and has {2}/{3} usability left", weapon.Name, weapon.Damage, weapon.remainingHealth, weapon.totalHealth));
                        break;
                    case 3:
                        Story.Content.Chapter_1.Quest_1 q = new Story.Content.Chapter_1.Quest_1();
                        q.Execute(this);
                        break;
                    case 4:
                        int res = Ask(new Question("Select an action", "Reset settings", "Change name"));
                        switch (res)
                        {
                            case 1:
                                settings.Reset();
                                settings = new Settings();
                                WriteLine("Done. \nRestart to display changes.");
                                break;
                            case 2:
                                settings.putString("name", OpenQuestion("Enter the name: "));
                                settings.Commit();
                                settings = new Settings();
                                this.UpdateProps();
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        private void Settings_Committed(object sender, EventArgs e)
        {
            UpdateProps();
        }

        private void Restart()
        {
            System.Diagnostics.Process.Start(
                 Environment.GetCommandLineArgs()[0]);

            Environment.Exit(0);
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
            if (weapon.Price <= this.Money)
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
