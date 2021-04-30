using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    class Goods
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }

        public Goods(int id,string name,double price)
        {
            this.ID = id;
            this.NAME = name;
            this.PRICE = price;
        }
        public override bool Equals(object obj)
        {
            Goods goods = obj as Goods;
            return goods != null &&
                goods.ID == ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, NAME, PRICE);
        }

        public override string ToString()
        {
            return $"ID:{ID},NAME:{NAME},PRICE:{PRICE}";
        }
    }
}
