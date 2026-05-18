using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain
{
    public class Items
    {
        public string Name { get; private set; }
        public int Count { get; set; }

        public int Price { get; set; }

        public Items(string name, int count, int price)
        {
            Name = name;
            Count = count;
            Price = price;
        }
    }
}
