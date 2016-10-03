using ConsoleHotKey;
using RPG.Properties;
using RPG.RGame;
using RPG.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RPG
{
    public static class RConsole
    {
        private static bool _first = true;
        private const int sleep = 20;

        static void Main(string[] args)
        {
            //Sets the hotkey(s):
            HotKeyManager.RegisterHotKey(Keys.C, KeyModifiers.Control);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            StartGame();
        }
        /// <summary>
        /// Begins the game in RGame\Game.cs <see cref="RPG.RGame.Game"/>
        /// </summary>
        /// <param name="_newGame"></param>
        public static void StartGame(Boolean _newGame = false)
        {
            if (_newGame)
                new Settings().Reset();
            Game g = new Game();
        }
        private static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            if (e.Key == Keys.C && e.Modifiers == KeyModifiers.Control)
                Clear();
        }

        public static void WriteLine(string text)
        {
            if (_first)
                _first = false;
            else
            {
                if (Console.CursorTop != 0 && text.Length == 0)
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine();
            }
            Write(text);
        }
        public static void Write(string text, int _sleep = sleep)
        {
            int i = 0;
            SoundPlayer sound = new SoundPlayer(Resources.typing);
            foreach (char c in text)
            {
                Console.Write(c);
                if (i == 8)
                {
                    sound.Play();
                    i = 0;
                }
                Thread.Sleep(sleep);
                i++;
            }
        }
        public static string ReadLine()
        {
            WriteLine(">>> ");
            return Console.ReadLine();
        }
        /// <summary>
        /// Ask a question using the question class.
        /// </summary>
        /// <param name="question"></param>
        /// <returns>-1 if cancelled by user otherwise the index</returns>
        public static int Ask(Question question)
        {
            WriteLine(question.QuestionText);
            WriteLine("(Anwser c to cancel)");
            for (int i = 0; i < question.Options.Length; i++)
            {
                WriteLine(String.Format(" {0}. {1}", i + 1, question.Options[i]));
            }
            int parsed = 0;
            string input = ReadLine();
            while (!int.TryParse(input, out parsed) || parsed > question.Options.Length || parsed <= 0)
            {
                if (input == "c")
                    return -1;
                WriteLine("Not a valid number...");
                WriteLine("Please try again:");
                WriteLine(question.QuestionText);
                for (int i = 0; i < question.Options.Length; i++)
                {
                    WriteLine(String.Format(" {0}. {1}", i + 1, question.Options[i]));
                }

                input = ReadLine();
            }
            return parsed;
        }
        public static bool Confirm()
        {
            WriteLine("Are you sure?");
            WriteLine("(Y/n)");
            string r = ReadLine().ToLower();
            while (true)
            {
                if (r[0] != 'y' && r[0] != 'n')
                {
                    WriteLine("No valid anwser, anwser with Y or N");
                    r = ReadLine().ToLower();
                }
                else
                    break;
            }
            if (r == "y")
                return true;
            return false;
        }
        public static string OpenQuestion(string q)
        {
            WriteLine(q);
            return ReadLine();
        }
        public static void Clear()
        {
            Console.Clear();
        }
    }
}
