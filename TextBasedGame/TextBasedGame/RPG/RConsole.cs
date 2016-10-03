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
        public const int sleep = 15;
        private const bool mute = true;
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
        public static void WriteLine(string question)
        {
            WriteLine(question, sleep, ConsoleColor.Black, ConsoleColor.White,true);
        }
        public static void WriteLine(string question, int _sleep)
        {
            WriteLine(question, _sleep, ConsoleColor.Black, ConsoleColor.White,true);
        }
        public static void WriteLine(string question, int _sleep, ConsoleColor bColor)
        {
            WriteLine(question, _sleep, bColor, ConsoleColor.White,true);
        }
        public static void WriteLine(string question, int _sleep, ConsoleColor bColor, ConsoleColor fColor)
        {
            WriteLine(question, _sleep, bColor, fColor, true);
        }
        public static void WriteLine(string text,int _sleep = sleep, ConsoleColor bColor = ConsoleColor.Black, ConsoleColor fColor = ConsoleColor.White, bool remote = false)
        {
            if (_first)
                _first = false;
            else
            {
                if (Console.CursorTop != 0 && text.Length == 0)
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine();
            }
            Write(text, _sleep, bColor, fColor);
        }
        public static void Write(string text, int _sleep = sleep, ConsoleColor bColor = ConsoleColor.Black, ConsoleColor fColor = ConsoleColor.White)
        {
            Console.BackgroundColor = bColor;
            Console.ForegroundColor = fColor;
            int i = 0;
            SoundPlayer sound = new SoundPlayer(Resources.typing);
            foreach (char c in text)
            {
                Console.Write(c);
                if (i == 8 && !mute)
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
        public static int Ask(Question question)
        {
            return Ask(question, sleep, ConsoleColor.Black, ConsoleColor.White);
        }
        public static int Ask(Question question, int _sleep)
        {
            return Ask(question, _sleep, ConsoleColor.Black, ConsoleColor.White);
        }
        public static int Ask(Question question, int _sleep, ConsoleColor bColor)
        {
            return Ask(question, _sleep, bColor, ConsoleColor.White);
        }
        public static int Ask(Question question, int _sleep, ConsoleColor bColor, ConsoleColor fColor)
        {
            return Ask(question, _sleep, bColor, fColor, true);
        }
        /// <summary>
        /// Ask a question using the question class.
        /// </summary>
        /// <param name="question"></param>
        /// <returns>-1 if cancelled by user otherwise the index</returns>
        public static int Ask(Question question, int _sleep = sleep, ConsoleColor bColor = ConsoleColor.Black, ConsoleColor fColor = ConsoleColor.White, bool remote = true)
        {
            WriteLine(question.QuestionText, _sleep, bColor, fColor);
            WriteLine("(Anwser c to cancel)", _sleep, bColor, fColor);
            for (int i = 0; i < question.Options.Length; i++)
            {
                WriteLine(String.Format(" {0}. {1}", i + 1, question.Options[i]), _sleep, bColor, fColor);
            }
            int parsed = 0;
            string input = ReadLine();
            while (!int.TryParse(input, out parsed) || parsed > question.Options.Length || parsed <= 0)
            {
                if (input == "c")
                    return -1;
                WriteLine("Not a valid number...", _sleep, bColor, fColor);
                WriteLine("Please try again:", _sleep, bColor, fColor);
                WriteLine(question.QuestionText, _sleep, bColor, fColor);
                for (int i = 0; i < question.Options.Length; i++)
                {
                    WriteLine(String.Format(" {0}. {1}", i + 1, question.Options[i]), _sleep, bColor, fColor);
                }

                input = ReadLine();
            }
            return parsed;
        }
        public static bool Confirm()
        {
            return Confirm(sleep, ConsoleColor.Black, ConsoleColor.White);
        }
        public static bool Confirm(int _sleep)
        {
            return Confirm(_sleep, ConsoleColor.Black, ConsoleColor.White);
        }
        public static bool Confirm(int _sleep, ConsoleColor bColor)
        {
            return Confirm(_sleep, bColor, ConsoleColor.White);
        }
        public static bool Confirm(int _sleep, ConsoleColor bColor, ConsoleColor fColor)
        {
            return Confirm(_sleep, bColor, fColor, true);
        }
        private static bool Confirm(int _sleep = sleep, ConsoleColor bColor = ConsoleColor.Black, ConsoleColor fColor = ConsoleColor.White, bool remote = true)
        {
            WriteLine("Are you sure?", _sleep, bColor, fColor);
            WriteLine("(Y/n)", _sleep, bColor, fColor);
            string r = ReadLine().ToLower();
            while (true)
            {
                if (r[0] != 'y' && r[0] != 'n')
                {
                    WriteLine("No valid anwser, anwser with Y or N", _sleep, bColor, fColor);
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
            return OpenQuestion(q, sleep, ConsoleColor.Black, ConsoleColor.White);
        }
        public static string OpenQuestion(string q, int _sleep)
        {
            return OpenQuestion(q, _sleep, ConsoleColor.Black, ConsoleColor.White);
        }
        public static string OpenQuestion(string q, int _sleep, ConsoleColor bColor)
        {
            return OpenQuestion(q, _sleep, bColor, ConsoleColor.White);
        }
        public static string OpenQuestion(string q, int _sleep, ConsoleColor bColor, ConsoleColor fColor)
        {
            return OpenQuestion(q, _sleep, bColor, fColor, true);
        }
        private static string OpenQuestion(string q, int _sleep = sleep, ConsoleColor bColor = ConsoleColor.Black, ConsoleColor fColor = ConsoleColor.White, bool remote = false)
        {
            WriteLine(q, _sleep, bColor, fColor);
            return ReadLine();
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void SayList(params string[] items)
        {
            for(int i = 0; i < items.Length; i++)
            {
                WriteLine(String.Format("{0}. {1}",i + 1,items[i]));
            }
        }
        public static void SayList(IEnumerable<string> str_enum)
        {
            SayList(str_enum.ToArray());
        }
    }
}
