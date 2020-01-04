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
            bool canEscape = false;
            List<(string label, ConsoleColor highlight)> buttons = new List<(string label, ConsoleColor highlight)>();

            if (!Game.playing)
            {
                if (!Program.hasSave)
                {
                    buttons.Add(("Play", ConsoleColor.DarkGray));
                    buttons.Add(("Exit", ConsoleColor.DarkGray));
                }
                else
                {
                    buttons.Add(("Play", ConsoleColor.DarkGray));
                    buttons.Add(("Exit", ConsoleColor.DarkGray));
                    buttons.Add(("Load", ConsoleColor.DarkGray));
                }
            }
            else
            {
                canEscape = true;

                if (!Program.hasSave)
                {
                    buttons.Add(("Resume", ConsoleColor.DarkGray));
                    buttons.Add(("Exit", ConsoleColor.DarkGray));
                    buttons.Add(("Save", ConsoleColor.DarkGray));
                }
                else
                {
                    buttons.Add(("Resume", ConsoleColor.DarkGray));
                    buttons.Add(("Save", ConsoleColor.DarkGray));
                    buttons.Add(("Exit", ConsoleColor.DarkGray));
                    buttons.Add(("Load", ConsoleColor.DarkGray));
                }
            }

            List<List<(string label, ConsoleColor highlight)>> rows = makeRows(buttons);

            bool selected = false;
            (int row, int col) selection = (0, 0);
            (int row, int col) previousSelection = (0, 0);

            while (!selected)
            {
                if (selection.col > rows[selection.row].Count() - 1)
                {
                    selection.col = rows[selection.row].Count() - 1;
                }

                rows[previousSelection.row][previousSelection.col] = (rows[previousSelection.row][previousSelection.col].label, ConsoleColor.DarkGray);
                rows[selection.row][selection.col] = (rows[selection.row][selection.col].label, ConsoleColor.Red);
                previousSelection = selection;
                Screen.Draw(rows);

                while (Console.KeyAvailable == false)
                {
                    if (Screen.CheckSize())
                    {
                        Screen.Draw(rows);
                    }
                }

                ConsoleKey input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.UpArrow)
                {
                    if (selection.row == 0)
                    {
                        selection.row = rows.Count() - 1;
                    }
                    else
                    {
                        selection.row -= 1;
                    }
                }

                if (input == ConsoleKey.DownArrow)
                {
                    if (selection.row == rows.Count() - 1)
                    {
                        selection.row = 0;
                    }
                    else
                    {
                        selection.row += 1;
                    }
                }

                if (input == ConsoleKey.LeftArrow)
                {
                    if (selection.col == 0)
                    {
                        selection.col = rows[selection.row].Count() - 1;
                    }
                    else
                    {
                        selection.col -= 1;
                    }
                }

                if (input == ConsoleKey.RightArrow)
                {
                    if (selection.col == rows[selection.row].Count() - 1)
                    {
                        selection.col = 0;
                    }
                    else
                    {
                        selection.col += 1;
                    }
                }

                if (input == ConsoleKey.Enter)
                {
                    selected = true;
                }

                if (input == ConsoleKey.Escape && canEscape)
                {
                    selection = (0, 0);
                    selected = true;
                }
            }

            if (rows[selection.row][selection.col].label == "Play")
            {
                Game.Initialize();
            }
            else if (rows[selection.row][selection.col].label == "Exit")
            {
                Environment.Exit(0);
            }
            else if (rows[selection.row][selection.col].label == "Save")
            {
                SaveFile.Save();
            }
            else if (rows[selection.row][selection.col].label == "Load")
            {
                SaveFile.load();
            }

            List<List<(string, ConsoleColor)>> makeRows(List<(string, ConsoleColor)> allButtons)
            {
                List<List<(string, ConsoleColor)>> buttonRows = new List<List<(string, ConsoleColor)>>();
                List<(string, ConsoleColor)> buttonRow = new List<(string, ConsoleColor)>();

                for (int b = 0; b < buttons.Count(); b++)
                {
                    buttonRow.Add(buttons[b]);

                    if (b == 0 && buttons.Count() % 2 == 1)
                    {
                        List<(string, ConsoleColor)> finalRow = new List<(string, ConsoleColor)>();
                        finalRow.AddRange(buttonRow);
                        buttonRows.Add(finalRow);
                        buttonRow.Clear();
                    }
                    else if (buttonRow.Count() == 2)
                    {
                        List<(string, ConsoleColor)> finalRow = new List<(string, ConsoleColor)>();
                        finalRow.AddRange(buttonRow);
                        buttonRows.Add(finalRow);
                        buttonRow.Clear();
                    }
                }

                return buttonRows;
            }
        }

        public static void Inventory()
        {

        }
    }
}
