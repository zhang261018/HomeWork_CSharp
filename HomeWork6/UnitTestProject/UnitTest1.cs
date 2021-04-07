using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System;
using OrderManager;

namespace UnitTestProject
{
    [TestClass]
    public class OrderManageTest
    {
        private List<OrderDetails> list;
        private List<Order> orders;
        private OrderService test;
        private List<String> orderNums;

        [TestInitialize]
        public void TestInitialize()
        {
            orderNums = new List<string>();
            orderNums.Add("001");
            orderNums.Add("005");
            orderNums.Add("004");
            list = new List<OrderDetails>();
            list.Add(new OrderDetails("snacks", "15", "100"));
            list.Add(new OrderDetails("desktop", "1", "10000"));
            orders = new List<Order>();
            orders.Add(new Order(list, "001", "zhangjiarui", "1500", "武汉大学", new DateTime(2021, 3, 18)));
            orders.Add(new Order(list, "005", "zhangjiarui", "10000", "武汉大学", new DateTime(2021, 2, 18)));
            orders.Add(new Order(list, "004", "zhangjiarui", "300", "武汉大学",  new DateTime(2021, 3, 11)));
            test = new OrderService(orders);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //删除产生的文件（在测试Export过程中产生的）
            if (File.Exists("testOrder.xml"))
                File.Delete("testOrder.xml");
        }

        [TestMethod]
        public void TestAdd()
        {
            OrderService obj = new OrderService();

            foreach (Order o in orders)
            {
                obj.Add(o);
            }

            CollectionAssert.AreEqual(test.OrderList, obj.OrderList);
        }

        [TestMethod]
        public void TestDelete()
        {
            OrderService obj = new OrderService();

            foreach (String o in orderNums)
            {
                test.Delete(o);
            }

            CollectionAssert.AreEqual(test.OrderList, obj.OrderList);
        }

        [TestMethod]
        public void TestImport()
        {
            //读入提前写入的正确的程序
            OrderService obj = new OrderService();
            obj.Import("OrderList.xml");
            Assert.IsTrue(obj.OrderList.Count != 0);
            //判断是否正确
            CollectionAssert.AreEqual(test.OrderList, obj.OrderList);
        }

        [TestMethod]
        public void TestExport()
        {
            //测试xml文件是否成功生成（前提即文件类型正确）
            test.Export("testOrder.xml");
            DateTime writeTime = DateTime.Now;
            Assert.IsNotNull(File.Exists("testOrder.xml"));

            //判断写入时间是否正常（防止是早已生成的文件）
            FileInfo info = new FileInfo("testOrder.xml");
            Assert.IsTrue(info.LastWriteTime == writeTime);
        }

        [TestMethod]
        public void TestModify()
        {
            List<Order> newOrders = new List<Order>();
            newOrders.Add(new Order(list, "001", "zhangjiarui", "1500", "武汉大学", new DateTime(2021, 3, 18)));
            newOrders.Add(new Order(list, "005", "zhangjiarui", "10000", "武汉大学", new DateTime(2021, 2, 18)));
            newOrders.Add(new Order(list, "007", "zhangjiarui", "300", "武汉大学", new DateTime(2021, 3, 11)));
            OrderService obj = new OrderService(newOrders);
            obj.Modify("007", orders[2]);

            CollectionAssert.AreEqual(test.OrderList, obj.OrderList);
        }

        [TestMethod]
        public void TestSearchByNumber()
        {
            List<Order> list = test.SearchByNumber("001");
            Assert.AreEqual(list[0], orders[0]);
        }

        [TestMethod]
        public void TestSort()
        {
            TestInitialize();

            List<Order> newOrders = new List<Order>();
            newOrders.Add(new Order(list, "001", "zhangjiarui", "1500", "武汉大学", new DateTime(2021, 3, 18)));
            newOrders.Add(new Order(list, "004", "zhangjiarui", "300", "武汉大学", new DateTime(2021, 3, 11)));
            newOrders.Add(new Order(list, "005", "zhangjiarui", "10000", "武汉大学", new DateTime(2021, 2, 18)));
            OrderService obj = new OrderService(newOrders);

            test.Sort();
            CollectionAssert.AreEqual(test.OrderList, obj.OrderList);
        }

        [TestMethod]
        public void TestSearch()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order(list, "004", "zhangjiarui", "300", "武汉大学", new DateTime(2021, 3, 11)));
            orders.Add(new Order(list, "001", "zhangjiarui", "1500", "武汉大学", new DateTime(2021, 3, 18)));
            orders.Add(new Order(list, "005", "zhangjiarui", "10000", "武汉大学", new DateTime(2021, 2, 18)));
            List<Order> newList1 = test.SearchByClient("zhangjiarui");
            List<Order> newList2 = test.SearchByAddress("武汉大学");
            List<Order> result1 = test.SearchByAmount(300);
            List<Order> result2 = test.SearchByTime((new DateTime(2021, 3, 11).ToString("yyyy-MM-dd")));
            List<Order> result3 = test.SearchByNumber("001");

            CollectionAssert.AreEqual(newList1, orders);
            CollectionAssert.AreEqual(newList2, orders);
            Assert.AreEqual(result1[0], orders[0]);
            Assert.AreEqual(result2[0], orders[0]);
            Assert.AreEqual(result3[0], orders[1]);
        }
    }
}
