using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Order
{
    class Order : IComparable<Order>
    {
        public int ID{ get; set; }
        public Customer Customer { get; set; }

        public double TotalPrice {
            get => Details.Sum(d => d.Amount);
        }
        public List<OrderDetail> Details = new List<OrderDetail>();

        public Order(int id,Customer customer)
        {
            this.ID = id;
            this.Customer = customer;
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new ApplicationException($"The goods ({orderDetail.Goods.NAME}) exist in order {ID}");
            }
            Details.Add(orderDetail);
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return ID - other.ID;
        }

        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && order.ID == ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void RemoveDetails(int num)
        {
            Details.RemoveAt(num);
        }
    }
}
