using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class TextView
    {
        //Log of previous text view inputs and outputs
        private static List<string> textLog = new List<string>();

        private static string[] responses = { "" };

        //Current input string stored until enter is pressed
        public static string input = "";

        //Processes the current input and carries out necessary commands
        public static void Process()
        {
            textLog.Add(input);

            if (input.ToLower() == "help")
            {

            }

            input = "";
            Screen.Draw(3);
        }

        //Renders a character map for the current visible text region
        public static List<List<char>> Render(int width, int height)
        {
            List<List<char>> render = new List<List<char>>();

            return render;
        }
    }
}
