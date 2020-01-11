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

                AddAssetLayer(CreateAssetLayer());
            }
            //If currently in town
            else if (currentGameView == 1)
            {

            }
            //If currently in the ruined keep
            else if (currentGameView == 2)
            {

            }
            //If currently in the ancestral tomb
            else if (currentGameView == 3)
            {

            }
            //If currently in the cursed mine
            else if (currentGameView == 4)
            {

            }
            //If currently in the necromancer's lair
            else if (currentGameView == 5)
            {

            }
            //If currently in the forgotten cave
            else if (currentGameView == 6)
            {

            }

            return render;

            //Creates a layer containing all visible assets to be layered over the current game view
            int[,] CreateAssetLayer()
            {
                //Initializing asset information
                int row;
                int col;
                int dir;

                int[,] assetLayer = new int[24, 24];

                int[,] asset = { { 0 } };

                for (int r = 0; r < 24; r++)
                {
                    for (int c = 0; c < 24; c++)
                    {
                        assetLayer[r, c] = -1;
                    }
                }

                //Detecting and placing visible assets in the world map
                if (currentGameView == 0)
                {
                    //aquiring specific asset information
                    row = World.finePlayerLocation.row;
                    col = World.finePlayerLocation.col;
                    dir = World.finePlayerLocation.direction;

                    (int col, int row, int width, int height, bool covered) assetValues = (0, 0, 0, 0, false);

                    bool visible = false;

                    //Checking for the town
                    if (col == 115 && row < 62 && dir == 0)
                    {
                        visible = true;

                        asset = Town.exterior.Clone() as int[,];

                        assetValues.col = 0;
                        assetValues.width = 24;
                        assetValues.height = 13;

                        if (row < 62 && row > 35)
                        {
                            assetValues.covered = true;
                            assetValues.row = (11 - (assetValues.height - 1)) + ((row - 34) / 2) - 1;
                        }
                        else if (row <= 35)
                        {
                            assetValues.row = (16 - (assetValues.height - 1)) - ((row - 25) / 2);
                        }
                    }

                    //Checking for the ruined keep
                    if (row == 75 && col > 129 && dir == 1)
                    {
                        visible = true;

                        //Placing the background paralax layer
                        asset = Keep.exteriorBackground.Clone() as int[,];

                        assetValues.col = 5;
                        assetValues.width = 14;
                        assetValues.height = 9;

                        if (col > 129 && col < 155)
                        {
                            assetValues.covered = true;
                            assetValues.row = (11 - (assetValues.height + 2)) + ((156 - col) / 2) - 1;
                        }
                        else if (col >= 155)
                        {
                            assetValues.row = (16 - (assetValues.height + 2)) - ((165 - col) / 2);
                        }

                        assetValues.row += (11 - assetValues.row) / 4;

                        AddAsset(assetValues);

                        //Placing the foreGround layer
                        asset = Keep.exteriorForeground.Clone() as int[,];

                        assetValues.height = 12;

                        if (col > 129 && col < 155)
                        {
                            assetValues.covered = true;
                            assetValues.row = (11 - (assetValues.height - 1)) + ((156 - col) / 2) - 1;
                        }
                        else if (col >= 155)
                        {
                            assetValues.row = (16 - (assetValues.height - 1)) - ((165 - col) / 2);
                        }
                    }

                    //Adding visible assets
                    if (visible)
                    {
                        AddAsset(assetValues);
                    }
                }

                return assetLayer;

                //Addes an asset to the asset layer with the given specifications
                void AddAsset((int col, int row, int width, int height, bool covered) assetValues)
                {
                    for (int r = 0; r < assetValues.height; r++)
                    {
                        if (r + assetValues.row >= 0)
                        {
                            for (int c = 0; c < assetValues.width; c++)
                            {
                                if (asset[r, c] != -1)
                                {
                                    if (assetValues.covered)
                                    {
                                        if (r + assetValues.row > 11)
                                        {
                                            assetLayer[r + assetValues.row, c + assetValues.col] = -1;
                                        }
                                        else if (r + assetValues.row == 11)
                                        {
                                            if (c + assetValues.col < 6 || c + assetValues.col > 17)
                                            {
                                                assetLayer[r + assetValues.row, c + assetValues.col] = asset[r, c];
                                            }
                                            else
                                            {
                                                assetLayer[r + assetValues.row, c + assetValues.col] = -1;
                                            }
                                        }
                                        else
                                        {
                                            assetLayer[r + assetValues.row, c + assetValues.col] = asset[r, c];
                                        }
                                    }
                                    else
                                    {
                                        assetLayer[r + assetValues.row, c + assetValues.col] = asset[r, c];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Adds the asset layer the the existing render
            void AddAssetLayer(int[,] assetLayer)
            {
                for (int r = 0; r < 24; r++)
                {
                    for (int c = 0; c < 24; c++)
                    {
                        if (assetLayer[r, c] != -1)
                        {
                            render[r, c] = assetLayer[r, c];
                        }
                    }
                }
            }
        }
    }
}
