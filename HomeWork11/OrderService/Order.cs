using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    [Serializable]
    public class Order: IComparable
    {
        public List<OrderDetails> order = new List<OrderDetails>();
        public string orderNumber = "0";
        public string client = "";
        public int orderAmount = 0;
        public DateTime orderTime = new DateTime();
        public string orderAddress = "";

        //private List<OrderDetails> order = new List<OrderDetails>();
        //private string orderNumber = "0";
        //private string client = "";
        //private int orderAmount = 0;
        //private DateTime orderTime = new DateTime();
        //private string orderAddress = "";

        public List<OrderDetails> Orders { get => order; }
        public string OrderNumber { get => orderNumber; }
        public string Client { get => client; }
        public int OrderAmount { get => orderAmount; }
        public DateTime OrderTime { get => orderTime; }
        public string OrderAddress { get => orderAddress; }

        public Order()
        {
            order = new List<OrderDetails>();
            orderNumber = "0"; client = "";
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
