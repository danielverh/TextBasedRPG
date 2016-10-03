using RPG.RGame.Items.Food;
using RPG.RGame.Items.Tools;
using RPG.RGame.Items.Weapons;
using RPG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sPlayer = RPG.RGame.Player.Player;
using static RPG.RConsole;
namespace RPG.RGame.Places
{
    internal class Shop : Places
    {
        private List<Food> foodItems = Items.ItemsController.getFood;
        private List<Weapons> Weapons = Items.ItemsController.getWeapons;
        private List<Tool> Tools = Items.ItemsController.getTools;
        private sPlayer player { get; set; }
        public void Initialize(sPlayer _player)
        {
            player = _player;
            WriteLine(String.Format("Welcome {0}, to the shop!", player.Name));
            WriteLine(String.Format("You have {0}$", player.Money));
            int result = Ask(new Question("What do you wanna buy?", "Weapons", "Tools", "Food"));
            if (result != -1)
            {
                switch (result)
                {
                    case 1:
                        ListItems(Weapons);
                        break;
                    case 2:
                        ListItems(Tools);
                        break;
                    case 3:
                        ListItems(foodItems);
                        break;
                }
            }
            player.UpdateProps();
        }
        public void ListItems(List<Food> food)
        {
            List<string> questions = new List<string>();
            foreach(Food f in food)
            {
                questions.Add(String.Format("1 {0} for {1}!", f.Name, f.Price));
            }
            int index = Ask(new Question("What kind of food do you wanna buy?", questions.ToArray())) - 1;
        }
        public void ListItems(List<Weapons> weapons)
        {
            List<string> questions = new List<string>();
            foreach (Weapons f in weapons)
            {
                questions.Add(String.Format("{0} for {1}!\n  More info:\n   - Damage: {2}\n   - Item Health: {3}", f.Name, f.Price, f.Damage, f.totalHealth));
            }
            int index = Ask(new Question("What kind of weapon do you wanna buy?", questions.ToArray())) - 1;
            if (Confirm())
            {
                player.BuyWeapon(weapons[index]);
            }
        }
        public void ListItems(List<Tool> tools)
        {
            List<string> questions = new List<string>();
            foreach (Tool f in tools)
            {
                questions.Add(String.Format("{0} for {1}!\n  More info:\n   - Critical for: {2}\n   - Item Health: {3}", f.Name, f.Price, f.Critical.ToString(), f.totalHealth));
            }
            int index = Ask(new Question("What kind of tool do you wanna buy?", questions.ToArray())) - 1;
        }
    }
}
