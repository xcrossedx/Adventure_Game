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

        private static List<(int col, int row, int width, int height)> regions = new List<(int col, int row, int width, int height)>();

        //Initializes important screen values
        public static void Initialize()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            currentWindowSize = (Console.WindowWidth, Console.WindowHeight);
            try
            {
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            }
            catch { }
        }

        //Draws every region of the game
        public static void Draw()
        {
            Initialize();

            SetRegions();

            for (int r = 0; r < 4; r++)
            {
                Draw(r, ConsoleColor.Blue);
            }
        }

        //Draws the outline and calls for the content of a specified region
        public static void Draw(int region, ConsoleColor highlight)
        {
            try
            {
                (int col, int row, int width, int height) = regions[region];

                for (int r = row; r < row + height; r++)
                {
                    for (int c = col; c < col + width; c++)
                    {
                        Console.ForegroundColor = highlight;
                        Console.SetCursorPosition(c, r);

                        if (r == row && c == col)
                        {
                            Console.Write("╔");
                        }
                        else if (r == row && c == col + width - 1)
                        {
                            Console.Write("╗");
                        }
                        else if (r == row + height - 1 && c == col)
                        {
                            Console.Write("╚");
                        }
                        else if (r == row + height - 1 && c == col + width - 1)
                        {
                            Console.Write("╝");
                        }
                        else if ((r == row || r == row + height - 1) || ((region == 1 || region == 2) && ((row + height - 1) - r) % 5 == 0 && (c != col && c != col + width - 1)))
                        {
                            Console.Write("═");
                        }
                        else if ((region == 1 || region == 2) && ((row + height - 1) - r) % 5 == 0 && (r != row && r != height + row - 1))
                        {
                            if (c == col)
                            {
                                Console.Write("╠");
                            }
                            else if (c == col + width - 1)
                            {
                                Console.Write("╣");
                            }
                        }
                        else if (c == col || c == col + width - 1)
                        {
                            Console.Write("║");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                DrawContent(region);
            }
            catch { }
        }

        private static void DrawContent(int region)
        {
            (int col, int row, int width, int height) fullRegion = regions[region];
            (int col, int row, int width, int height) contentRegion = (fullRegion.col + 1, fullRegion.row + 1, fullRegion.width - 2, fullRegion.height - 2);


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
                            if (buttonRows[r][c].label == "Resume")
                            {
                                Console.SetCursorPosition(bOrigin.col + 2, bOrigin.row + 1);
                            }
                            else
                            {
                                Console.SetCursorPosition(bOrigin.col + 3, bOrigin.row + 1);
                            }

                            Console.Write(buttonRows[r][c].label);
                        }
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        public static bool CheckSize()
        {
            bool changed = false;

            if ((Console.WindowWidth, Console.WindowHeight) != currentWindowSize)
            {
                changed = true;

                if (Game.playing)
                {
                    Draw();
                }
                else
                {
                    Initialize();
                }
            }

            return changed;
        }

        private static void SetRegions()
        {
            regions.Clear();

            (int col, int row, int width, int height) region;

            //Region 0 = main game window
            int width = 0;
            int height = 0;
            int hOffset = 0;
            int vOffset = 0;

            if (Console.WindowWidth - 24 <= (Console.WindowHeight - 12) * 2)
            {
                width = Console.WindowWidth - 22;
                height = ((Console.WindowWidth - 24) / 2) + 2;
                vOffset = ((Console.WindowHeight - 10) - (((Console.WindowWidth - 24) / 2) + 2)) / 2;
            }
            else
            {
                width = ((Console.WindowHeight - 12) * 2) + 2;
                height = Console.WindowHeight - 10;
                hOffset = ((Console.WindowWidth - 22) - (((Console.WindowHeight - 12) * 2) + 2)) / 2;
            }

            region = (11 + hOffset, 0 + vOffset, width, height);
            regions.Add(region);

            //Region 1 = consumable items
            height = (((Console.WindowHeight - 11) / 5) * 5) + 1;
            vOffset = ((Console.WindowHeight - 11) % 5) / 2;

            region = (1, 0 + vOffset, 10, height);
            regions.Add(region);

            //Region 2 = equipped items
            if (Console.WindowHeight - 10 >= 26)
            {
                height = 26;
            }
            else
            {
                height = 6;
            }

            vOffset = ((Console.WindowHeight - 10) - height) / 2;

            region = (Console.WindowWidth - 11, 0 + vOffset, 10, height);
            regions.Add(region);

            //Region 3 = text input/output
            region = (1, Console.WindowHeight - 10, Console.WindowWidth - 2, 10);
            regions.Add(region);
        }
    }
}
