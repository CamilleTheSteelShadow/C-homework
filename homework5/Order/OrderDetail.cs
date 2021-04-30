using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    class OrderDetail
    {
        public Goods Goods { get; set; }

        public int Number { get; set; }

        public double Amount
        {
            get => Goods.PRICE * Number;
        }

        public OrderDetail(Goods goods, int number)
        {
            this.Goods = goods;
            this.Number = number;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                   EqualityComparer<Goods>.Default.Equals(Goods, detail.Goods);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"OrderDetail:{Goods},{Number}";
        }


    }
}
