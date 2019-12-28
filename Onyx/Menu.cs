using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class Menu
    {
        public static void Pause()
        {
            List<(string label, int highlight)> buttons = new List<(string label, int highlight)>();
            int[] rows = { 0, 0 };

            if (!Game.playing)
            {
                if (!Program.hasSave)
                {
                    buttons.Add(("Play", 0));
                    buttons.Add(("Exit", 0));
                    rows[0] = 2;
                }
                else
                {
                    buttons.Add(("New", 0));
                    buttons.Add(("Load", 0));
                    buttons.Add(("Exit", 0));
                    rows[0] = 1;
                    rows[1] = 2;
                }
            }
            else
            {
                if (!Program.hasSave)
                {
                    buttons.Add(("Resume", 0));
                    buttons.Add(("Save", 0));
                    buttons.Add(("Exit", 0));
                    rows[0] = 1;
                    rows[1] = 2;
                }
                else
                {
                    buttons.Add(("Resume", 0));
                    buttons.Add(("Save", 0));
                    buttons.Add(("Load", 0));
                    buttons.Add(("Exit", 0));
                    rows[0] = 2;
                    rows[1] = 2;
                }
            }

            bool selected = false;
            (int row, int col) = (0, 0);

            while (!selected)
            {
                buttons[selection] = (buttons[selection].label, 1);
                Screen.Draw(buttons);

                (row, col) = Game.Navigate(rows);
            }
        }
    }
}
