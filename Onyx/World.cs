using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class World
    {
        private static int[,] smallWorldMap =
        {
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 8, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 6, 6, 6, 6, 6, 6, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 8, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 8, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 8, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        };

        private static int[,] largeWorldMap = new int[250, 200];

        //Directions 0 = north, 1 = east, 2 = south, 3 = west
        public static (int row, int col, int direction) finePlayerLocation = (0, 0, 0);

        //0 = direction unavailable, 1 = direction available, 2 = direction leads to new location
        private static int[] directions = { 2, 0, 1, 0 };

        public static void Initialize()
        {
            finePlayerLocation = ((Player.globalLocation.row * 10) + 5, (Player.globalLocation.col * 10) + 5, Player.globalLocation.direction);

            Random rng = new Random();

            for (int r = 0; r < 25; r++)
            {
                for (int c = 0; c < 20; c++)
                {
                    int[] colors = { 8, 8 };
                    int rarity = 0;

                    if (smallWorldMap[r, c] == 2)
                    {
                        colors[0] = 10;
                        colors[1] = 2;
                        rarity = 70;
                    }
                    else if (smallWorldMap[r, c] == 6)
                    {
                        colors[0] = 6;
                        colors[1] = 8;
                        rarity = 99;
                    }

                    for (int er = 0; er < 10; er++)
                    {
                        for (int ec = 0; ec < 10; ec++)
                        {
                            if (rng.Next() % 100 < rarity)
                            {
                                largeWorldMap[(r * 10) + er, (c * 10) + ec] = colors[0];
                            }
                            else
                            {
                                largeWorldMap[(r * 10) + er, (c * 10) + ec] = colors[1];
                            }
                        }
                    }
                }
            }
        }

        public static int[,] GenerateView()
        {
            int[,] worldView = new int[13, 24];

            int d = Player.globalLocation.direction;
            int pRow = finePlayerLocation.row;
            int pCol = finePlayerLocation.col;

            for (int h = 0; h < 13; h++)
            {
                for (int w = 0; w < 24; w++)
                {
                    int heightOffset = 11 - h;
                    int widthOffset = 12 - w;

                    if (d == 0)
                    {
                        if (h < 6)
                        {
                            int row = pRow - (17 - (h * 2));

                            if (row % 2 == 1)
                            {
                                row += 1;
                            }

                            worldView[h, w] = largeWorldMap[row, pCol - widthOffset];
                        }
                        else
                        {
                            worldView[h, w] = largeWorldMap[pRow - heightOffset, pCol - widthOffset];
                        }
                    }
                    else if (d == 1)
                    {
                        heightOffset -= 1;

                        if (h < 6)
                        {
                            int col = pCol + (16 - (h * 2));

                            if (col % 2 == 0)
                            {
                                col -= 1;
                            }

                            worldView[h, w] = largeWorldMap[pRow - widthOffset, col];
                        }
                        else
                        {
                            worldView[h, w] = largeWorldMap[pRow - widthOffset, pCol + heightOffset];
                        }
                    }
                    else if (d == 2)
                    {
                        heightOffset -= 1;
                        widthOffset -= 1;

                        if (h < 6)
                        {
                            int row = pRow + (16 - (h * 2));

                            if (row % 2 == 0)
                            {
                                row -= 1;
                            }

                            worldView[h, w] = largeWorldMap[row, pCol + widthOffset];
                        }
                        else
                        {
                            worldView[h, w] = largeWorldMap[pRow + heightOffset, pCol + widthOffset];
                        }
                    }
                    else if (d == 3)
                    {
                        widthOffset -= 1;

                        if (h < 6)
                        {
                            int col = pCol - (17 - (h * 2));

                            if (col % 2 == 1)
                            {
                                col += 1;
                            }

                            worldView[h, w] = largeWorldMap[pRow + widthOffset, col];
                        }
                        else
                        {
                            worldView[h, w] = largeWorldMap[pRow + widthOffset, pCol - heightOffset];
                        }
                    }
                }
            }

            return worldView;
        }

        public static void Navigate(int direction)
        {
            GetDirections();

            int d = Player.globalLocation.direction;

            if (direction == 0 && directions[Player.globalLocation.direction] == 1)
            {
                if (d == 0)
                {
                    Player.globalLocation.row -= 1;
                }
                else if (d == 1)
                {
                    Player.globalLocation.col += 1;
                }
                else if (d == 2)
                {
                    Player.globalLocation.row += 1;
                }
                else
                {
                    Player.globalLocation.col -= 1;
                }
            }
            if (direction == 2 && directions[(Player.globalLocation.direction + 2) % 4] == 1)
            {
                if (d == 0)
                {
                    Player.globalLocation.row += 1;
                }
                else if (d == 1)
                {
                    Player.globalLocation.col -= 1;
                }
                else if (d == 2)
                {
                    Player.globalLocation.row -= 1;
                }
                else
                {
                    Player.globalLocation.col += 1;
                }
            }
            if (direction == 1)
            {
                Player.globalLocation.direction = (d + 1) % 4;

                if (directions[Player.globalLocation.direction] == 0)
                {
                    Player.globalLocation.direction = (Player.globalLocation.direction + 1) % 4;
                }

                finePlayerLocation.direction = Player.globalLocation.direction;
            }
            if (direction == 3)
            {
                if (d != 0)
                {
                    Player.globalLocation.direction = d - 1;
                }
                else
                {
                    Player.globalLocation.direction = 3;
                }

                if (directions[Player.globalLocation.direction] == 0)
                {
                    if (Player.globalLocation.direction != 0)
                    {
                        Player.globalLocation.direction = Player.globalLocation.direction - 1;
                    }
                    else
                    {
                        Player.globalLocation.direction = 3;
                    }
                }

                finePlayerLocation.direction = Player.globalLocation.direction;
            }

            int rowDif = ((Player.globalLocation.row * 10) + 5) - finePlayerLocation.row;
            int colDif = ((Player.globalLocation.col * 10) + 5) - finePlayerLocation.col;

            if (rowDif != 0)
            {
                for (int i = 0; i < Math.Abs(rowDif); i++)
                {
                    finePlayerLocation.row += (rowDif) / 10;
                    Screen.Draw(0);
                }
            }
            else if (colDif != 0)
            {
                for (int i = 0; i < Math.Abs(colDif); i++)
                {
                    finePlayerLocation.col += (colDif) / 10;
                    Screen.Draw(0);
                }
            }
            else
            {
                Screen.Draw(0);
            }
        }

        private static void GetDirections()
        {
            //Setting the value of north
            if ((Player.globalLocation.col == 2 && (Player.globalLocation.row > 5 && Player.globalLocation.row < 23)) || (Player.globalLocation.col == 11 && (Player.globalLocation.row > 2 && Player.globalLocation.row < 22)))
            {
                directions[0] = 1;
            }
            else if ((Player.globalLocation.col == 2 && Player.globalLocation.row == 5) || (Player.globalLocation.col == 11 && Player.globalLocation.row == 2))
            {
                directions[0] = 2;
            }
            else
            {
                directions[0] = 0;
            }

            //Setting the value of east
            if ((Player.globalLocation.row == 7 && (Player.globalLocation.col > 10 && Player.globalLocation.col < 16)) || (Player.globalLocation.row == 14 && (Player.globalLocation.col > 1 && Player.globalLocation.col < 17)))
            {
                directions[1] = 1;
            }
            else if ((Player.globalLocation.row == 7 && Player.globalLocation.col == 16) || (Player.globalLocation.row == 14 && Player.globalLocation.col == 17))
            {
                directions[1] = 2;
            }
            else
            {
                directions[1] = 0;
            }

            //Setting the value of south
            if ((Player.globalLocation.col == 2 && (Player.globalLocation.row > 4 && Player.globalLocation.row < 22)) || (Player.globalLocation.col == 11 && (Player.globalLocation.row > 1 && Player.globalLocation.row < 21)))
            {
                directions[2] = 1;
            }
            else if ((Player.globalLocation.col == 2 && Player.globalLocation.row == 22) || (Player.globalLocation.col == 11 && Player.globalLocation.col == 21))
            {
                directions[2] = 2;
            }
            else
            {
                directions[2] = 0;
            }

            //Setting the value of west
            if ((Player.globalLocation.row == 7 && (Player.globalLocation.col > 11 && Player.globalLocation.col < 17)) || (Player.globalLocation.row == 14 && (Player.globalLocation.col > 2 && Player.globalLocation.col < 18)))
            {
                directions[3] = 1;
            }
            else if (Player.globalLocation.row == 14 && Player.globalLocation.col == 2)
            {
                directions[3] = 2;
            }
            else
            {
                directions[3] = 0;
            }
        }
    }
}
