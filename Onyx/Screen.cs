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

        //List of ConsoleColors
        private static ConsoleColor[] colors = Enum.GetValues(typeof (ConsoleColor)) as ConsoleColor[];

        //Defines the size of the game view pixels
        public static bool bigPixels = false;

        //Origin co-ordinates and dimensions of each screen region
        public static List<(int col, int row, int width, int height)> regions = new List<(int col, int row, int width, int height)>();

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
                Draw(r);
            }
        }

        //Draws the outline and calls for the content of a specified region
        public static void Draw(int region)
        {
            try
            {
                (int col, int row, int width, int height) = regions[region];

                for (int r = row; r < row + height; r++)
                {
                    for (int c = col; c < col + width; c++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
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
                        else if (region == 1 && c == col + 1 && (row + height - r) % 5 == 0)
                        {
                            int hotkey = (r + 6 - row) / 5;

                            if (hotkey == 10)
                            {
                                hotkey = 0;
                            }

                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(hotkey);
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                DrawContent(region);
            }
            catch { }
        }

        //Previous content for comparison
        private static List<List<int>> oldGameView = new List<List<int>>();

        //Draws content within the given region
        private static void DrawContent(int region)
        {
            (int col, int row, int width, int height) fullRegion = regions[region];
            (int col, int row, int width, int height) contentRegion = (fullRegion.col + 1, fullRegion.row + 1, fullRegion.width - 2, fullRegion.height - 2);

            //Main window
            if (region == 0)
            {
                int[,] gameView = GameView.Render();

                for (int r = 0; r < 24; r++)
                {
                    for (int c = 0; c < 24; c++)
                    {
                        DrawPixel(r, c, gameView[r, c]);
                    }
                }
            }
            //Consumables
            else if (region == 1)
            {
                InventoryView.RenderHotBar();
            }
            //Equipped items
            else if (region == 2)
            {
                InventoryView.RenderEquipmentBar();
            }
            //Text input/output
            else if (region == 3)
            {

            }

            //Draws individual "pixels" for the game view region
            void DrawPixel(int row, int col, int color)
            {
                Console.BackgroundColor = colors[color];

                if (!bigPixels)
                {
                    Console.SetCursorPosition(contentRegion.col + (col * 2), contentRegion.row + row);
                    Console.Write("  ");
                }
                else
                {
                    Console.SetCursorPosition(contentRegion.col + (col * 4), contentRegion.row + (row * 2));
                    Console.Write("    ");
                    Console.SetCursorPosition(contentRegion.col + (col * 4), contentRegion.row + (row * 2) + 1);
                    Console.Write("    ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
            }
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

            //Writing in the buttons
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

        //Checks the window size and redraws the screen if it has changed
        public static bool CheckSize()
        {
            bool changed = false;

            if ((Console.WindowWidth, Console.WindowHeight) != currentWindowSize)
            {
                changed = true;

                if (Game.playing)
                {
                    oldGameView = new List<List<int>>();
                    Draw();
                }
                else
                {
                    Initialize();
                }
            }

            return changed;
        }

        //Generates the origin points and dimensions of each screen region given the current window size
        private static void SetRegions()
        {
            bool failed = false;

            regions.Clear();

            (int col, int row, int width, int height) region;

            //Region 0 = main game window
            int width = 0;
            int height = 0;
            int hExcess = 0;
            int vExcess = 0;
            int hOffset = 0;
            int vOffset = 0;

            if (Console.WindowWidth - 24 <= (Console.WindowHeight - 12) * 2)
            {
                width = (Console.WindowWidth - 22) - ((Console.WindowWidth - 22) % 4);

                if (width >= 98)
                {
                    hExcess = width - 98;
                    width = 98;
                    bigPixels = true;
                }
                else if (width >= 50)
                {
                    hExcess = width - 50;
                    width = 50;
                    bigPixels = false;
                }
                else
                {
                    try
                    {
                        Console.WindowWidth += 49 - width;
                        failed = true;
                    }
                    catch
                    {
                        Draw();
                    }
                }

                height = ((width - 2) / 2) + 2;
                hOffset = (((Console.WindowWidth - 26) % 4) + hExcess) / 2;
                vOffset = ((Console.WindowHeight - 10) - height) / 2;
            }
            else
            {
                height = (Console.WindowHeight - 10) - ((Console.WindowHeight - 10) % 2);

                if (height >= 50)
                {
                    vExcess = height - 50;
                    height = 50;
                    bigPixels = true;
                }
                else if (height >= 26)
                {
                    vExcess = height - 26;
                    height = 26;
                    bigPixels = false;
                }
                else
                {
                    try
                    {
                        Console.WindowHeight += 25 - height;
                        failed = true;
                    }
                    catch
                    {
                        Draw();
                    }
                }

                width = ((height - 2) * 2) + 2;
                vOffset = (((Console.WindowHeight - 12) % 2) + vExcess) / 2;
                hOffset = ((Console.WindowWidth - 22) - width) / 2;
            }

            region = (11 + hOffset, 0 + vOffset, width, height);
            regions.Add(region);

            //Region 1 = consumable items
            height = (((Console.WindowHeight - 11) / 5) * 5) + 1;
            if (height > 51) { height = 51; }
            vOffset = ((Console.WindowHeight - 10) - height) / 2;

            region = (1 + (hOffset / 2), 0 + vOffset, 10, height);
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

            region = ((Console.WindowWidth - 11) - (hOffset / 2), 0 + vOffset, 10, height);
            regions.Add(region);

            //Region 3 = text input/output
            region = (1 + (hOffset / 2), Console.WindowHeight - 10, (Console.WindowWidth - 2) - hOffset, 10);
            regions.Add(region);

            if (failed)
            {
                CheckSize();
            }
        }
    }
}
