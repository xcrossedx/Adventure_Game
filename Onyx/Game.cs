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

        public static void Initialize()
        {
            playing = true;

            Screen.Draw();

            while (Console.KeyAvailable == false)
            {
                Screen.CheckSize();
            }

            Console.ReadLine();
        }
    }
}
