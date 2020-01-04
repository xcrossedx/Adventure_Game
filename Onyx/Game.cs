using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class Game
    {
        public static bool playing = false;
        public static bool interupted = false;

        public static void Initialize()
        {
            playing = true;

            Screen.Draw();

            while (!interupted)
            {
                while (Console.KeyAvailable == false)
                {
                    Screen.CheckSize();
                }

                ProcessInput();
            }
        }

        private static void ProcessInput()
        {
            ConsoleKey input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.Escape)
            {
                Menu.Pause();
            }
            else if (input == ConsoleKey.Tab)
            {
                Menu.Inventory();
            }
            else if (input == ConsoleKey.UpArrow)
            {
                GameView.Move(0);
            }
            else if (input == ConsoleKey.RightArrow)
            {
                GameView.Move(1);
            }
            else if (input == ConsoleKey.DownArrow)
            {
                GameView.Move(2);
            }
            else if (input == ConsoleKey.LeftArrow)
            {
                GameView.Move(3);
            }
            else if (input == ConsoleKey.A || input == ConsoleKey.B || input == ConsoleKey.C || input == ConsoleKey.D || input == ConsoleKey.E || input == ConsoleKey.F || input == ConsoleKey.G || input == ConsoleKey.H || input == ConsoleKey.I || input == ConsoleKey.J || input == ConsoleKey.K || input == ConsoleKey.L || input == ConsoleKey.M || input == ConsoleKey.N || input == ConsoleKey.O || input == ConsoleKey.P || input == ConsoleKey.Q || input == ConsoleKey.R || input == ConsoleKey.S || input == ConsoleKey.T || input == ConsoleKey.U || input == ConsoleKey.V || input == ConsoleKey.W || input == ConsoleKey.X || input == ConsoleKey.Y || input == ConsoleKey.Z)
            {
                TextView.input += input;
                Screen.Draw(3);
            }
            else if (input == ConsoleKey.Enter)
            {
                TextView.Process();
            }
        }
    }
}
