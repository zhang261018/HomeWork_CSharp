using System;
using System.Collections.Generic;


namespace OrderManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService newOrder = new OrderService();
            List<OrderDetails> list = new List<OrderDetails>();
            list.Add(new OrderDetails("snacks", "15", "100"));
            list.Add(new OrderDetails("desktop", "1", "10000"));

            //添加一定数量的订单
            newOrder.Add(new Order("001", "zhangjiarui", "1500", "武汉大学", list, new DateTime(2021, 3, 18)));
            newOrder.Add(new Order("005", "zhangjiarui", "10000", "武汉大学", list, new DateTime(2021, 2, 18)));
            newOrder.Add(new Order("004", "zhangjiarui", "300", "武汉大学", list, new DateTime(2021, 3, 11)));
            newOrder.Add(new Order("003", "zhangjiarui", "5000", "武汉大学", list, new DateTime(2021, 2, 27)));
            newOrder.Add(new Order("002", "zhangjiarui_copy1", "800", "华中科技大学", list, new DateTime(2021, 3, 1)));
            newOrder.Add(new Order("006", "zhangjiarui_copy1", "60", "华中科技大学", list, new DateTime(2021, 3, 18)));
            newOrder.Add(new Order("007", "zhangjiarui_copy2", "10000", "武汉大学", list, new DateTime(2021, 3, 18)));
            newOrder.Add(new Order("008", "zhangjiarui_copy2", "1500", "武汉大学", list, new DateTime(2021, 3, 11)));
            newOrder.Add(new Order("009", "zhangjiarui_copy3", "300", "华中科技大学", list, new DateTime(2021, 3, 1)));
            newOrder.Add(new Order("0010", "zhangjiarui_copy3", "27", "华中科技大学", list, new DateTime(2021, 3, 18)));

            Console.WriteLine("展示所有订单");
            newOrder.Display();

            Console.WriteLine("\n按订单金额排序(从小到大)后");
            newOrder.Sort((odr1, odr2) => odr1.orderAmount - odr2.orderAmount);
            newOrder.Display();

            Console.WriteLine("\n按订单号排序后");
            newOrder.Sort();
            newOrder.Display();

            Console.WriteLine("\n所有zhangjiarui下的订单");
            foreach (Order o in newOrder.SearchByClient("zhangjiarui"))
                Console.WriteLine(o.ToString());

            Console.WriteLine("\n所有在华中科技大学下的订单");
            foreach (Order o in newOrder.SearchByAddress("华中科技大学"))
                Console.WriteLine(o.ToString());

            Console.WriteLine("\n删除订单号为009的订单");
            newOrder.Delete("009");
            newOrder.Display();

            try
            {
                Console.WriteLine("\n尝试删除订单号为011的订单");
                newOrder.Delete("011");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
