using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    class Program
    {
        public static bool hasSave = false;

        static void Main()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Screen.Initialize();
            SaveFile.Check();
            Menu.Pause();
        }
    }
}
