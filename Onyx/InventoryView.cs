using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    static class InventoryView
    {
        public static List<string[]> RenderHotBar()
        {
            List<string[]> hotBarItems = new List<string[]>();

            Player.GenerateHotBar();

            return hotBarItems;
        }

        public static List<string[]> RenderEquipmentBar()
        {
            List<string[]> equipmentBarItems = new List<string[]>();

            Player.GenerateEquipmentBar();

            return equipmentBarItems;
        }
    }
}
