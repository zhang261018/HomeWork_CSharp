using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class Order: IComparable
    {
        public OrderDetails order;
        public string orderNumber;
        public string client;
        public int orderAmount;
        public DateTime orderTime;
        public string orderAddress;

        //
        public Order(string orderNumber, string client, string orderAmount, 
            string orderAddress, OrderDetails order, DateTime orderTime)
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
            return string.Format("{0,-8}{1}{2,-24}{3,-8}{4,-16}{5,-16}",
                orderNumber, order.ToString(),
                client, orderAmount,
                orderTime.ToString("yyyy-MM-dd"), orderAddress);
        }

        //Equals方法的重载
        public override bool Equals(object obj)
        {
            Order newOrder = obj as Order;

            if (newOrder == null)
                throw new Exception("无效的对象");

            return order.Equals(newOrder.order) &&
                (orderNumber == newOrder.orderNumber) &&
                (client == newOrder.client) &&
                (orderAmount == newOrder.orderAmount) &&
                (orderTime.Equals(newOrder.orderTime)) &&
                (orderAddress == newOrder.orderAddress);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
