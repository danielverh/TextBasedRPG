using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Utilities;
using RPG.RGame.Mob;
using static RPG.RConsole;

namespace RPG.RGame.Story
{
    internal static class Story
    {
        public static void Quest1 (Player.Player _player){
            WriteLine("Henk: Please kill that chicken over there for me.");
            WriteLine("Kill chicken:");
            Confirm();
            Chicken ch = new Chicken();
            ch.KillChicken();
            WriteLine("Henk: Good job! I will give you 5$ (Irco's).");
            _player.Money += 5;
            WriteLine("*You completed the quest!*", sleep + 5, ConsoleColor.Black,ConsoleColor.Cyan);
            ReadLine();
        }
    }
}
