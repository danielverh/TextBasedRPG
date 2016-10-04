using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG;
using static RPG.RConsole;
using RPG.RGame.Mob;

namespace RPG.RGame.Story.Content.Chapter_1 {
    internal class Quest_1 : IStory{
        public bool Execute(Player.Player _player) {
            WriteLine("Henk: Please kill that chicken over there for me.", 99);
            Wait(500);
            WriteLine("Kill chicken:", 0);
            if (Confirm() == true) {
                Chicken ch = new Chicken();
                ch.KillChicken();
                WriteLine("Henk: Good job! I will give you 5$ (Irco's).", 99);
                _player.Money += 5;
                Wait(500);
                WriteLine("*You completed the quest!*", 99, fColor:ConsoleColor.Cyan);
                Wait(500);
                WriteLine("+5 Irco's\nYou now have " + _player.Money.ToString() + " Irco's.", 50, ConsoleColor.Black, ConsoleColor.Yellow);
                Console.ForegroundColor = ConsoleColor.White;
                ReadLine();
                return true;
            } else {
                WriteLine("Henk: I'm very dissapointed in you!", 25 ,fColor:ConsoleColor.White);
                Wait(100);
                WriteLine("Henk: Do it now!", 25);
                ReadLine();
                Chicken ch = new Chicken();
                ch.KillChicken();
                WriteLine("Henk: Good.", 99);
                Wait(500);
                WriteLine("*You completed the quest!*", 99, fColor: ConsoleColor.Cyan);
                Wait(500);
            }   
            return false;
        }
    }
}
