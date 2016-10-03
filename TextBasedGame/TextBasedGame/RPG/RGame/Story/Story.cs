using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Utilities;
using RPG.RGame.Mob;

namespace RPG.RGame.Story
{
    internal static class Story
    {
        public static void Quest1 (Player.Player _player){
            Message.SetDelay(50);
            Message.SendLine("Henk: Please kill that chicken over there for me.", ConsoleColor.White);
            Message.Pause();
            Chicken ch = new Chicken();
            ch.KillChicken();
            Message.SendLine("Henk: Good job! I will give you 5 Irco's.");
            _player.Money += 5;
            Message.SendLine("*You completed the quest!*", true, ConsoleColor.Cyan);
            Message.Pause();
        }
    }
}
