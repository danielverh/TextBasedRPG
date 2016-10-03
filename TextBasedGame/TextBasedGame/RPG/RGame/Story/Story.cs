﻿using System;
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
            WriteLine("Henk: Please kill that chicken over there for me.", 99);
            Wait(500);
            WriteLine("Kill chicken:", 0);
            Confirm();
            Chicken ch = new Chicken();
            ch.KillChicken();
            WriteLine("Henk: Good job! I will give you 5$ (Irco's).");
            _player.Money += 5;
            Wait(500);
            WriteLine("*You completed the quest!*", sleep + 5, ConsoleColor.Black, ConsoleColor.Cyan);
            Wait(500);
            WriteLine("+5 Irco's\nYou now have " + _player.Money.ToString() + " Irco's.", 50, ConsoleColor.Black, ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            ReadLine();
        }
    }
}
