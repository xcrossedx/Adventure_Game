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
            Console.CursorVisible = false;
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
        public static void Draw(List<List<(string label, ConsoleColor highlight)>> buttonRows)
        {
            (int col, int row) mOrigin = (0, 0);
            int height = 0;

            //Drawing the background of the pause menu
            Console.BackgroundColor = ConsoleColor.Gray;

            if (buttonRows.Count() == 1)
            {
                mOrigin = ((Console.WindowWidth / 2) - 10, (Console.WindowHeight / 2) - 2);
                height = 5;
            }
            else
            {
                mOrigin = ((Console.WindowWidth / 2) - 10, (Console.WindowHeight / 2) - 4);
                height = 9;
            }

            for (int r = 0; r < height; r++)
            {
                Console.SetCursorPosition(mOrigin.col, mOrigin.row + r);
                Console.Write("                          ");
            }

            Console.ForegroundColor = ConsoleColor.White;

            for (int r = 0; r < buttonRows.Count(); r++)
            {
                (int col, int row) rOrigin = (0, mOrigin.row + (4 * r) + 1);

                if (buttonRows[r].Count() == 1)
                {
                    rOrigin.col = mOrigin.col + 8;
                }
                else
                {
                    rOrigin.col = mOrigin.col + 2;
                }

                for (int c = 0; c < buttonRows[r].Count(); c++)
                {
                    (int col, int row) bOrigin = (rOrigin.col + (12 * c), rOrigin.row);

                    for (int br = 0; br < 3; br++)
                    {
                        if (br == 2)
                        {
                            Console.BackgroundColor = buttonRows[r][c].highlight;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }

                        Console.SetCursorPosition(bOrigin.col, bOrigin.row + br);
                        Console.Write("          ");

                        if (br == 1)
                        {
                            Console.SetCursorPosition(bOrigin.col + 2, bOrigin.row + 1);
                            Console.Write(buttonRows[r][c].label);
                        }
                    }
                }
            }
        }
    }
}
