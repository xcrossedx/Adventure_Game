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
            { 2, 2, 6, 2, 2, 2, 2, 2, 2, 2, 2, 6, 6, 6, 6, 6, 6, 8, 2, 2 },
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
        public static (int row, int col, int direction) finePlayerLocation = (25, 115, 0);
        public static (int row, int col, int direction) playerLocation = (2, 11, 0);

        //0 = direction unavailable, 1 = direction available, 2 = direction leads to new location
        private static int[] directions = { 2, 0, 1, 0 };

        public static void Initialize()
        {
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

            int d = playerLocation.direction;
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

            int d = playerLocation.direction;

            if (direction == 0 && directions[playerLocation.direction] == 1)
            {
                if (d == 0)
                {
                    playerLocation.row -= 1;
                }
                else if (d == 1)
                {
                    playerLocation.col += 1;
                }
                else if (d == 2)
                {
                    playerLocation.row += 1;
                }
                else
                {
                    playerLocation.col -= 1;
                }
            }
            if (direction == 2 && directions[(playerLocation.direction + 2) % 4] == 1)
            {
                if (d == 0)
                {
                    playerLocation.row += 1;
                }
                else if (d == 1)
                {
                    playerLocation.col -= 1;
                }
                else if (d == 2)
                {
                    playerLocation.row -= 1;
                }
                else
                {
                    playerLocation.col += 1;
                }
            }
            if (direction == 1)
            {
                playerLocation.direction = (d + 1) % 4;

                if (directions[playerLocation.direction] == 0)
                {
                    playerLocation.direction = (playerLocation.direction + 1) % 4;
                }

                finePlayerLocation.direction = playerLocation.direction;
            }
            if (direction == 3)
            {
                if (d != 0)
                {
                    playerLocation.direction = d - 1;
                }
                else
                {
                    playerLocation.direction = 3;
                }

                if (directions[playerLocation.direction] == 0)
                {
                    if (playerLocation.direction != 0)
                    {
                        playerLocation.direction = playerLocation.direction - 1;
                    }
                    else
                    {
                        playerLocation.direction = 3;
                    }
                }

                finePlayerLocation.direction = playerLocation.direction;
            }
        }

        private static void GetDirections()
        {
            //Setting the value of north
            if ((playerLocation.col == 2 && (playerLocation.row > 5 && playerLocation.row < 23)) || (playerLocation.col == 11 && (playerLocation.row > 2 && playerLocation.row < 22)))
            {
                directions[0] = 1;
            }
            else if ((playerLocation.col == 2 && playerLocation.row == 5) || (playerLocation.col == 11 && playerLocation.row == 2))
            {
                directions[0] = 2;
            }
            else
            {
                directions[0] = 0;
            }

            //Setting the value of east
            if ((playerLocation.row == 7 && (playerLocation.col > 10 && playerLocation.col < 16)) || (playerLocation.row == 14 && (playerLocation.col > 1 && playerLocation.col < 17)))
            {
                directions[1] = 1;
            }
            else if ((playerLocation.row == 7 && playerLocation.col == 16) || (playerLocation.row == 14 && playerLocation.col == 17))
            {
                directions[1] = 2;
            }
            else
            {
                directions[1] = 0;
            }

            //Setting the value of south
            if ((playerLocation.col == 2 && (playerLocation.row > 4 && playerLocation.row < 22)) || (playerLocation.col == 11 && (playerLocation.row > 1 && playerLocation.row < 21)))
            {
                directions[2] = 1;
            }
            else if ((playerLocation.col == 2 && playerLocation.row == 22) || (playerLocation.col == 11 && playerLocation.col == 21))
            {
                directions[2] = 2;
            }
            else
            {
                directions[2] = 0;
            }

            //Setting the value of west
            if ((playerLocation.row == 7 && (playerLocation.col > 11 && playerLocation.col < 17)) || (playerLocation.row == 14 && (playerLocation.col > 2 && playerLocation.col < 18)))
            {
                directions[3] = 1;
            }
            else if (playerLocation.row == 14 && playerLocation.col == 2)
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
