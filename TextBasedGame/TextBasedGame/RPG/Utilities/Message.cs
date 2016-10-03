using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;

namespace RPG.Utilities
{

    /// <summary>
    /// This class is used for console messaging.
    /// </summary>
    public class Message
    {

        /// <summary>
        /// The time in milliseconds the console waits before sending the next character.
        /// </summary>
        public static int delay { get; set; }

        /// <summary>
        /// The latest string the console wrote.
        /// </summary>
        private static string latestPrint { get; set; }

        /// <summary>
        /// The # of messages sent.
        /// </summary>
        private static int messagesSent { get; set; }


        /// <summary>
        /// Used to ask questions to the users.
        /// </summary>
        /// <param name="_question">The question.</param>
        /// <param name="_options">The apossible answers.</param>
        /// <returns></returns>
        public static string Ask(string _question, List<string> _options)
        {
            foreach (char c in _question)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.Write("\n");
            for (int i = 0; i < _options.Count; i++)
            {
                foreach (char c in _options[i])
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }
                Console.Write("\n");
            }
            string answer = Console.ReadLine().ToUpper();
            return answer;
        }

        /// <summary>
        /// Clears all messages
        /// </summary>
        public static void ClearAll()
        {
            Console.Clear();
            messagesSent = 0;
        }

        /// <summary>
        /// Prints an error message to the console in red font.
        /// </summary>
        /// <param name="_error">The error message that will be displayed.</param>
        public static void Error(string _error)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Message.SendLine("Error: " + _error);
            Console.ForegroundColor = c;
        }

        /// <summary>
        /// Gets the delay.
        /// </summary>
        /// <returns>Current delay</returns>
        public static int GetDelay()
        {
            return delay;
        }

        /// <summary>
        /// Returns latest line writen by the console.
        /// </summary>
        /// <returns>Latest print</returns>
        public static string GetLatestPrint()
        {
            return latestPrint;
        }

        /// <summary>
        /// Waits for another user input.
        /// </summary>
        public static void Pause()
        {
            Console.WriteLine("");
            Console.ReadKey();
        }

        /// <summary>
        /// Message Send Normal
        /// </summary>
        /// <param name="_message"></param>
        public static void Send(string _message)
        {
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message SendLine Normal
        /// </summary>
        /// <param name="_message"></param>
        public static void SendLine(string _message)
        {
            if (messagesSent != 0)
                Console.Write("\n");
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message Send Direct
        /// </summary>
        /// <param name="_message"></param>
        /// <param name="_isDirect"></param>
        public static void Send(string _message, bool _isDirect)
        {
            if (_isDirect)
            {
                foreach (char c in _message)
                {
                    Console.Write(c);
                }

                latestPrint = _message;
                messagesSent += 1;
            }
        }

        /// <summary>
        ///  Message SendLine Direct
        /// </summary>
        /// <param name="_message"></param>
        /// <param name="_isDirect"></param>
        public static void SendLine(string _message, bool _isDirect)
        {
            if (_isDirect)
            {
                if (messagesSent != 0)
                    Console.Write("\n");
                foreach (char c in _message)
                {
                    Console.Write(c);
                }

                latestPrint = _message;
                messagesSent += 1;
            }
        }

        /// <summary>
        /// Message Send Direct Color
        /// </summary>
        /// <param name="_message"></param>
        /// <param name="_isDirect"></param>
        public static void Send(string _message, bool _isDirect, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            if (_isDirect)
            {
                foreach (char c in _message)
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }

                latestPrint = _message;
                messagesSent += 1;
            }
        }

        /// <summary>
        ///  Message SendLine Direct Color
        /// </summary>
        /// <param name="_message"></param>
        /// <param name="_isDirect"></param>
        public static void SendLine(string _message, bool _isDirect, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            if (_isDirect)
            {
                if (messagesSent != 0)
                    Console.Write("\n");
                foreach (char c in _message)
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }

                latestPrint = _message;
                messagesSent += 1;
            }
        }

        /// <summary>
        /// Message Send Color
        /// </summary>
        /// <param name="_message"></param>
        public static void Send(string _message, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message SendLine Color
        /// </summary>
        /// <param name="_message"></param>
        public static void SendLine(string _message, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            if (messagesSent != 0)
                Console.Write("\n");
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message Send Delay
        /// </summary>
        /// <param name="_message"></param>
        public static void Send(string _message, int _customDelay)
        {
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(_customDelay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message SendLine Delay
        /// </summary>
        /// <param name="_message"></param>
        public static void SendLine(string _message, int _customDelay)
        {
            if (messagesSent != 0)
                Console.Write("\n");
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(_customDelay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message Send Color and Delay
        /// </summary>
        /// <param name="_message"></param>
        public static void Send(string _message, ConsoleColor _color, int _customDelay)
        {
            Console.ForegroundColor = _color;
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(_customDelay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Message SendLine Color and Delay
        /// </summary>
        /// <param name="_message"></param>
        public static void SendLine(string _message, ConsoleColor _color, int _customDelay)
        {
            Console.ForegroundColor = _color;
            if (messagesSent != 0)
                Console.Write("\n");
            foreach (char c in _message)
            {
                Console.Write(c);
                Thread.Sleep(_customDelay);
            }

            latestPrint = _message;
            messagesSent += 1;
        }

        /// <summary>
        /// Method to change the delay.
        /// </summary>
        /// <param name="_delay">The new value for delay</param>
        public static void SetDelay(int _delay)
        {
            delay = _delay;
        }

        /// <summary>
        /// Used to play sounds.
        /// </summary>
        /// <param name="_path"></param>
        public static void Sound(string _path)
        {
            if (File.Exists(_path))
            {
                SoundPlayer snd = new SoundPlayer(_path);
                snd.Play();
            }
            else
                Send(_path + " is not found.");
        }
    }
}