using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OrderManager
{
    public delegate int SortMethod(Order obj1, Order obj2);
    public class OrderService
    {
        private List<Order> orderList;

        public List<Order> OrderList { get => orderList; }

        public OrderService()
        {
            orderList = new List<Order>();
        }
        
        public OrderService(List<Order> list)
        {
            this.orderList = list;
        }

        //展示所有订单
        public void Display()
        {
            Console.WriteLine("{0,-5}{1,-22}{2,-5}{3,-12}{4,-12}{5}",
                "订单号","客户","总金额","订单时间","订单地址","订单");
            
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

            foreach(Order o in orderList)
            {
                if (o.Equals(newOrder))
                    throw new Exception("订单已存在");
            }

            orderList.Add(newOrder);
            return true;
        }

        //提供订单号进行删除，提供了错误的订单号会抛出异常
        public void Delete(string orderNum)
        {
            List<Order> searchResult = this.SearchByNumber(orderNum);

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

            List<Order> newList = this.SearchByNumber(orderNum);
            if (newList == null)
                throw new ArgumentException("订单号不存在");
            else
            {
                for(int i=0;i<orderList.Count;i++)
                {
                    if (orderList[i].OrderNumber == newList[0].OrderNumber)
                    {
                        orderList[i] = newOrder;break;
                    }
                }
            }                
            return true;
        }



        //查询所需订单，当查询结果为空的时候抛出异常
        public List<Order> SearchByNumber(string name)
        {
            var order = from odr in orderList where odr.OrderNumber == name orderby odr.OrderAmount select odr;
            List<Order> result = order.ToList();
            if(result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }
        
        public List<Order> SearchByClient(string name)
        {
            var order = from odr in orderList where odr.Client == name orderby odr.OrderAmount select odr;
            List<Order> result = order.ToList();
            if (result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }
        public List<Order> SearchByAddress(string name)
        {
            var order = from odr in orderList where odr.OrderAddress == name orderby odr.OrderAmount select odr;
            List<Order> result = order.ToList();
            if (result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }
        public List<Order> SearchByTime(string name)
        {
            var order = from odr in orderList where odr.OrderTime.ToString("yyyy-MM-dd") == name orderby odr.OrderAmount select odr;
            List<Order> result = order.ToList();
            if (result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }
        public List<Order> SearchByAmount(double name)
        {
            var order = from odr in orderList where odr.OrderAmount == name select odr;
            List<Order> result = order.ToList();
            if (result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }

        //将存储的数据写入xml文件中存储
        public void Export(string targetAddress)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(targetAddress, FileMode.OpenOrCreate, FileAccess.Write))
            {
                serializer.Serialize(fs, orderList);
            }
        }

        //将xml文件数据读入系统
        public void Import(string targetAddress)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(targetAddress, FileMode.Open, FileAccess.Read))
            {
                orderList = (List<Order>)serializer.Deserialize(fs);
            }
        }

        public override bool Equals(object obj)
        {
            OrderService tmp = obj as OrderService;
            if (tmp == null)
                return false;
            return this.orderList.Equals(tmp.orderList);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}