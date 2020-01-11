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

        //Initialize important game information
        public static void Initialize()
        {
            playing = true;

            World.Initialize();
            Screen.Draw();

            Play();
        }

        //Main game method most roads will lead here
        private static void Play()
        {
            //Wait for keyboard input to process
            while (!interupted)
            {
                while (Console.KeyAvailable == false)
                {
                    Screen.CheckSize();
                }

                ConsoleKey input = Console.ReadKey(true).Key;

                ProcessInput(input);
            }
        }

        private static DateTime lastInputTime = DateTime.MinValue;

        //General input processing for gameplay
        private static void ProcessInput(ConsoleKey input)
        {
            //Opens pause menu
            if (input == ConsoleKey.Escape)
            {
                Menu.Pause();
            }
            //Opens inventory
            else if (input == ConsoleKey.Tab)
            {
                Menu.Inventory();
            }
            //Navigates the game view
            else if ((input == ConsoleKey.UpArrow || input == ConsoleKey.RightArrow || input == ConsoleKey.DownArrow || input == ConsoleKey.LeftArrow) && DateTime.Now > lastInputTime.AddSeconds(.1))
            {
                if (input == ConsoleKey.UpArrow)
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

                lastInputTime = DateTime.Now;
            }
            //Uses hotbar item
            else if (input == ConsoleKey.D1 || input == ConsoleKey.D2 || input == ConsoleKey.D3 || input == ConsoleKey.D4 || input == ConsoleKey.D5 || input == ConsoleKey.D6 || input == ConsoleKey.D7 || input == ConsoleKey.D8 || input == ConsoleKey.D9 || input == ConsoleKey.D0)
            {
                int hotKey = int.Parse(input.ToString());

                if (hotKey == 0)
                {
                    hotKey = 9;
                }
                else
                {
                    hotKey -= 1;
                }

                if (hotKey < Player.hotBar.Count())
                {
                    Player.UseItem(Player.hotBar[hotKey]);
                }
            }
            //Inputs into text region
            else if (input == ConsoleKey.Spacebar || input == ConsoleKey.A || input == ConsoleKey.B || input == ConsoleKey.C || input == ConsoleKey.D || input == ConsoleKey.E || input == ConsoleKey.F || input == ConsoleKey.G || input == ConsoleKey.H || input == ConsoleKey.I || input == ConsoleKey.J || input == ConsoleKey.K || input == ConsoleKey.L || input == ConsoleKey.M || input == ConsoleKey.N || input == ConsoleKey.O || input == ConsoleKey.P || input == ConsoleKey.Q || input == ConsoleKey.R || input == ConsoleKey.S || input == ConsoleKey.T || input == ConsoleKey.U || input == ConsoleKey.V || input == ConsoleKey.W || input == ConsoleKey.X || input == ConsoleKey.Y || input == ConsoleKey.Z)
            {
                TextView.input += input;
                Screen.Draw(3);
            }
            //Processes current text region input
            else if (input == ConsoleKey.Enter)
            {
                TextView.Process();
            }
        }
    }
}
