using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    [Serializable]
    public class Order: IComparable
    {
        public List<OrderDetails> order;
        public string orderNumber;
        public string client;
        public int orderAmount;
        public DateTime orderTime;
        public string orderAddress;

        public Order()
        {
            order = new List<OrderDetails>();
            orderNumber = ""; client = "";
            orderAmount = 0; orderTime = new DateTime();
            orderAddress = "";
        }

        //
        public Order(List<OrderDetails> order,string orderNumber = "", string client = "", string orderAmount = "",
            string orderAddress = "", DateTime orderTime = new DateTime())
        {
            this.orderNumber = orderNumber;
            this.client = client;
            this.orderAmount = Int32.Parse(orderAmount);
            this.orderAddress = orderAddress;
            this.order = order;
            this.orderTime = orderTime;
        }

        //比较器
        public int CompareTo(object obj)
        {
            Order newOrder = obj as Order;
            return Int32.Parse(this.orderNumber) - Int32.Parse(newOrder.orderNumber);
        }

        //ToString方法的重载
        public override string ToString()
        {
            string output =  string.Format("{0,-8}{1,-24}{2,-8}{3,-16}{4,-16}",
                orderNumber,
                client, orderAmount,
                orderTime.ToString("yyyy-MM-dd"), orderAddress);
            foreach (OrderDetails o in order)
                output += o.ToString();
            return output;
        }

        //Equals方法的重载
        public override bool Equals(object obj)
        {
            Order newOrder = obj as Order;

            if (newOrder == null)
                return false;

            return orderNumber == newOrder.orderNumber;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(this.orderNumber);
        }
    }
}
