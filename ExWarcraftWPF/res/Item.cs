using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExWarcraftWPF.res
{
    public class Item
    {
        public Item(String itemName, int itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
        }

        public String ItemName { get; set; }
        public int ItemCount { get; set; }
    }
}
