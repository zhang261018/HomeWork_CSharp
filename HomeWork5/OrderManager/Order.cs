using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class Order: IComparable
    {
        private List<OrderDetails> order = new List<OrderDetails>();
        private string orderNumber = "";
        private string client = "";
        private int orderAmount = 0;
        private DateTime orderTime = new DateTime();
        private string orderAddress = "";            

        public List<OrderDetails> Orders { get => order; }
        public string OrderNumber { get => orderNumber; }
        public string Client { get => client; }
        public int OrderAmount { get => orderAmount; }
        public DateTime OrderTime { get => orderTime; }
        public string OrderAddress { get => orderAddress; }

        //
        public Order(string orderNumber, string client, string orderAmount, 
            string orderAddress, List<OrderDetails> order, DateTime orderTime)
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
            if (newOrder == null)
                throw new TypeAccessException("对象类型不正确");
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
