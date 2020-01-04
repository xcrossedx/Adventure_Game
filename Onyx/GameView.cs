using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class GameView
    {


        //0 = up
        //1 = right
        //2 = down
        //3 = left
        public static void Move(int direction)
        {
            Screen.Draw(0);
        }

        //Renders the current game view screen
        public static List<List<int>> Render(int width, int height)
        {
            List<List<int>> render = new List<List<int>>();

            for (int r = 0; r < height; r++)
            {
                List<int> row = new List<int>();

                for (int c = 0; c < width / 2; c++)
                {
                    row.Add(10);
                }

                render.Add(row);
            }

            return render;
        }
    }
}
