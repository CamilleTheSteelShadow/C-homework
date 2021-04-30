using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

  public class OrderService {


    private readonly List<Order> orders = new List<Order>();

    public OrderService() {
    }

    public void AddOrder(Order order) {
      if (orders.Contains(order)) {
        throw new ApplicationException($"the order {order.Id} already exists!");
      }
      orders.Add(order);
    }

    public void Update(Order order) {
      RemoveOrder(order.Id);
      orders.Add(order);
    }

    public Order GetById(int orderId) {
      return orders.FirstOrDefault(o => o.Id == orderId);
    }

    public void RemoveOrder(int orderId) {
      orders.RemoveAll(o => o.Id == orderId);
    }

    public List<Order> QueryAll() {
      return orders;
    }

    public IEnumerable<Order> Query(Predicate<Order> condition) {
      return orders.Where(o => condition(o));
    }

    public List<Order> QueryByGoodsName(string goodsName) {
      var query = orders.Where(
        o => o.Details.Any(d => d.Goods.Name == goodsName));
      return query.ToList();
    }

    public List<Order> QueryByTotalAmount(float totalAmount) {
      var query = orders.Where(o => o.TotalAmount >= totalAmount);
      return query.ToList();
    }

    public List<Order> QueryByCustomerName(string customerName) {
      var query = orders
          .Where(o => o.Customer.Name == customerName);
      return query.ToList();
    }


    public void Sort(Comparison<Order> comparison) {
      orders.Sort(comparison);
    }

    public void Export(String fileName) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
        xs.Serialize(fs, orders);
      }
    }

    public void Import(string path) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(path, FileMode.Open)) {
        List<Order> temp = (List<Order>)xs.Deserialize(fs);
        temp.ForEach(order => {
          if (!orders.Contains(order)) {
            orders.Add(order);
          }
        });
      }
    }
    
  }
}
