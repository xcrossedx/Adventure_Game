using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onyx
{
    class Item
    {
        public int[,] graphic;
        public int type;
        public int subtype;
        public int health;
        public int material;

        private Item(int[,] graphic, int type, int subtype, int health, int material)
        {
            this.graphic = graphic;
            this.type = type;
            this.subtype = subtype;
            this.health = health;
            this.material = material;
        }

        //public static Item bread = new Item({ {} });
    }
}
