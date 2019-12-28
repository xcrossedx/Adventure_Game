using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class Screen
    {
        //Current window size used to detect when the screen size changes so it can redraw the whole window
        private static (int width, int height) currentWindowSize = (0, 0);

        //Initializes important screen values
        public static void Initialize()
        {
            currentWindowSize = (Console.WindowWidth, Console.WindowHeight);
        }

        //Draws everything including the outlines of each region
        public static void Draw()
        {

        }

        //Draws the content of the given region
        public static void Draw(int region, int variation)
        {

        }

        //Draw method specifically for drawing the pause menu
        public static void Draw(List<(string label, int highlight)> buttons)
        {
            //Drawing the background of the pause menu
            Console.BackgroundColor = ConsoleColor.Gray;

            if (buttons.Count() == 2)
            {
                (int col, int row) = ((Console.WindowWidth / 2) - 10, (Console.WindowHeight / 2) - 3);

                for (int r = 0; r < 3; r++)
                {
                    Console.SetCursorPosition(col, row + r);
                    Console.Write("                 ");
                }
            }
            else
            {
                (int col, int row) = ((Console.WindowWidth / 2) - 10, (Console.WindowHeight / 2) -1);
                
                for (int r = 0; r < 7; r++)
                {
                    Console.SetCursorPosition(col, row + r);
                    Console.Write("                 ");
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            //If there is an odd number of buttons
            if (buttons.Count() % 2 == 1)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 4, (Console.WindowHeight / 2) - 2);
                Console.Write(buttons[0]);
            }
            //If there is an even number of buttons
            else
            {

            }
        }
    }
}
