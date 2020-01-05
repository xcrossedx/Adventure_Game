using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Onyx
{
    static class GameView
    {
        public static int currentGameView = 0;

        //0 = up
        //1 = right
        //2 = down
        //3 = left
        public static void Move(int direction)
        {
            //View 0 = world view
            if (currentGameView == 0)
            {
                World.Navigate(direction);

                int rowDif = ((World.playerLocation.row * 10) + 5) - World.finePlayerLocation.row;
                int colDif = ((World.playerLocation.col * 10) + 5) - World.finePlayerLocation.col;

                if (rowDif != 0)
                {
                    for (int i = 0; i < Math.Abs(rowDif); i++)
                    {
                        World.finePlayerLocation.row += (rowDif) / 10;
                        Screen.Draw(0);
                    }
                }
                else if (colDif != 0)
                {
                    for (int i = 0; i < Math.Abs(colDif); i++)
                    {
                        World.finePlayerLocation.col += (colDif) / 10;
                        Screen.Draw(0);
                    }
                }
                else
                {
                    Screen.Draw(0);
                }
            }
        }

        //Renders the current game view screen
        public static int[,] Render()
        {
            int[,] render = new int[24, 24];

            //If currently in the world map
            if (currentGameView == 0)
            {
                int[,] worldView = World.GenerateView();

                //Laying world texture and the base for the sky
                for (int r = 0; r < 24; r++)
                {
                    for (int c = 0; c < 24; c++)
                    {
                        if (r == 0)
                        {
                            render[r, c] = 1;
                        }
                        else if (r == 1)
                        {
                            if (c < 4 || c > 19)
                            {
                                render[r, c] = 1;
                            }
                            else
                            {
                                render[r, c] = 9;
                            }
                        }
                        else if (r < 11)
                        {
                            render[r, c] = 9;
                        }
                        else if (r == 11)
                        {
                            if (c < 6 || c > 17)
                            {
                                render[r, c] = 9;
                            }
                            else
                            {
                                render[r, c] = worldView[r - 11, c];
                            }
                        }
                        else
                        {
                            render[r, c] = worldView[r - 11, c];
                        }
                    }
                }


            }

            return render;

            void AddAssetLayer()
            {
                if (currentGameView == 0)
                {

                }
            }
        }
    }
}
