using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp {

  /**
   **/
  [Serializable]
  public class Order:IComparable<Order>{

    public int Id { get; set; }

    public Customer Customer { get; set; }

    public DateTime CreateTime { get; set; }

    public float TotalAmount {
      get => Details.Sum(d => d.Amount);
    }

    public List<OrderDetail> Details { get; } = new List<OrderDetail>();

    public Order() {
      CreateTime = DateTime.Now;
    }

    public Order(int orderId, Customer customer,DateTime creatTime) {
      Id = orderId;
      Customer = customer;
      CreateTime = creatTime;
    }

    public void AddDetails(OrderDetail orderDetail) {
      if (this.Details.Contains(orderDetail)) {
        throw new ApplicationException($"The goods ({orderDetail.Goods.Name}) exist in order {Id}");
      }
      Details.Add(orderDetail);
    }

    public int CompareTo(Order other) {
      if (other == null) return 1;
      return Id - other.Id;
    }

    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null && Id == order.Id;
    }

    public override int GetHashCode() {
      return 2108858624 + Id.GetHashCode();
    }

    public void RemoveDetails(int num) {
      Details.RemoveAt(num);
    }

    public override string ToString() {
      String result = $"orderId:{Id}, customer:({Customer})";
      Details.ForEach(detail => result += "\n\t" + detail);
      return result;
    }

  }
}
