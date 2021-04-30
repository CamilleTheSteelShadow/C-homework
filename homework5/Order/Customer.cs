using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    class Customer
    {
        public int ID { get; set; }

        public string NAME { get; set; }

        public Customer(int id,string name)
        {
            this.ID = id;
            this.NAME = name;
        }

        public override string ToString()
        {
            return $"顾客ID:{ID},顾客姓名:{NAME}";
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            return customer != null &&
                   ID == customer.ID &&
                   NAME ==customer.NAME;
        }

        public override int GetHashCode()
        {
            return 123456 + ID.GetHashCode();
        }
    }
}
