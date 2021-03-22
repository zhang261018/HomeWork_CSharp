using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderManager
{
    public delegate int SortMethod(Order obj1, Order obj2);
    public class OrderService
    {
        private List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }
        
        //展示所有订单
        public void Display()
        {
            Console.WriteLine("{0,-5}{1,-12}{2,-6:C}{3,-6}{4,-22}{5,-5}{6,-12}{7,-12}",
                "订单号","货物种类","数量","单价","客户","总金额","订单时间","订单地址");
            
            foreach(Order o in orderList)
            {
                Console.WriteLine(o.ToString());
            }
        }

        //对于订单按照订单号排序
        public void Sort()
        {
            this.orderList.Sort();
        }

        //传递lambda表达式的排序函数
        public void Sort(Func<Order, Order, int> func)
        {
            this.orderList.Sort((odr1, odr2) => func(odr1, odr2));
        }

        //添加订单,添加不成功会抛出异常
        public bool Add(object obj)
        {
            Order newOrder = obj as Order;
            if (newOrder == null)
                throw new Exception("无效的对象");

            orderList.Add(newOrder);
            return true;
        }

        //提供订单号进行删除，提供了错误的订单号会抛出异常
        public void Delete(string orderNum)
        {
            List<Order> searchResult = this.Search("orderNumber", orderNum);

            if (searchResult.Count == 0)
            {
                throw new ArgumentException("订单号不存在");
            }

            for(int i=0;i<searchResult.Count;i++)
            {
                orderList.Remove(searchResult[i]);
            }
        }

        //修改订单，当提供的订单不正常或者要修改的订单号不存在的时候抛出异常
        public bool Modify(string orderNum, object order)
        {
            Order newOrder = order as Order;
            if (newOrder == null)
                throw new Exception("请提供有效订单");

            List<Order> newList = this.Search("orderNumber", orderNum);
            if (newList == null)
                throw new ArgumentException("订单号不存在");
            else
                newList[0] = newOrder;
            return true;
        }

        //查询所需订单，当查询结果为空的时候抛出异常
        public List<Order> Search(string type, string name)
        {
            List<Order> result;
            if (type.ToLower() == "ordernumber")
            {
                var order = from odr in orderList where odr.orderNumber == name orderby odr.orderAmount select odr;
                result = order.ToList();
            }
            else if (type.ToLower() == "tradename")
            {
                var order = from odr in orderList where odr.order.tradeName == name orderby odr.orderAmount select odr;
                result = order.ToList();
            }
            else if (type.ToLower() == "client")
            {
                var order = from odr in orderList where odr.client == name orderby odr.orderAmount select odr;
                result = order.ToList();
            }
            else if (type.ToLower() == "orderaddress")
            {
                var order = from odr in orderList where odr.orderAddress == name orderby odr.orderAmount select odr;
                result = order.ToList();
            }
            else if (type.ToLower() == "ordertime")
            {
                var order = from odr in orderList where odr.orderTime.ToString("yyyy-MM-dd") == name orderby odr.orderAmount select odr;
                result = order.ToList();
            }
            else if (type.ToLower() == "orderamount")
            {
                var order = from odr in orderList where odr.orderAmount == Convert.ToInt32(name) select odr;
                result = order.ToList();
            }
            else
            {
                result = null;
                throw new ArgumentException("typeError");
            }
            return result;
        }
    }
}