using RPG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG.RConsole;
namespace RPG.RGame
{
    internal class Game
    {
        public Game()
        {
            this.Player = new Player.Player();
        }

        public Player.Player Player { get; private set; }
    }
}
