﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class Player
    {
        public static (int row, int col, int direction) globalLocation = (7, 16, 0);
        public static (int row, int col, int direction) localLocation = (0, 0, 0);

        public static List<Item> hotBar = new List<Item>();
        public static List<Item> equipmentBar = new List<Item>();

        public static void GenerateHotBar()
        {

        }

        public static void GenerateEquipmentBar()
        {

        }

        public static void UseItem(Item item)
        {
            Screen.Draw(1);
        }
    }
}
