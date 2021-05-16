using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Data.Entity;
using HomeWork8;

namespace OrderManager
{
    public delegate int SortMethod(Order obj1, Order obj2);
    public class OrderService
    {
        // private List<Order> orderList;

        // public List<Order> OrderList { get => orderList; }

        public OrderService()
        {
            // orderList = new List<Order>();
        }
        
        //public OrderService(List<Order> list)
        //{
        //    foreach (Order o in list)
        //    {
        //        this.Add(o);
        //    }
        //}

        //添加订单,添加不成功会抛出异常
        public bool Add(object obj)
        {
            Order newOrder = obj as Order;
            if (newOrder == null)
                throw new Exception("无效的对象");

            using (var context = new OrdersContainer())
            {
                var ans = context.OrderSet.Where(odr=>odr.OrderNumber == newOrder.OrderNumber);
                List<Order> list = ans.ToList();
                if (list != null && list.Count > 0)
                    throw new Exception("订单已存在");
                newOrder.OrderDetails = new List<OrderDetail>();
                context.OrderSet.Add(newOrder);
                context.SaveChanges();
            }
            return true;
        }

        public bool AddDetail(object odrDetails)
        {
            OrderDetail newDetails = odrDetails as OrderDetail;
            if (newDetails == null)
                throw new Exception("无效的对象");

            using (var context = new OrdersContainer())
            {
                Random rand = new Random();

                //主键约束，防止tradeId重复（model first使用string类型主键容易报插入null错误，所以加了一个隐藏的标识货物的id）
                int ranId = 0;
                do
                {
                    ranId = rand.Next();
                    newDetails.TradeId = ranId;
                    var query = context.OrderDetailSet.Where(od => od.TradeId == ranId);
                    if (query.ToList().Count == 0) break;
                } while (true);

                Order modOdr = context.OrderSet.FirstOrDefault(odr=>odr.OrderNumber == newDetails.OrderNumber);
                modOdr.OrderDetails.Add(newDetails);
                // context.OrderDetailSet.Add(newDetails);
                context.SaveChanges();
            }
            return true;
        }


        //提供订单号进行删除，提供了错误的订单号会抛出异常
        public void Delete(int orderNum)
        {
            using (var context = new OrdersContainer())
            {
                var order = context.OrderSet.FirstOrDefault(p => p.OrderNumber == orderNum);
                // var orderDetails = context.OrderDetailSet.Where(p => p.OrderNumber == orderNum);
                if(order != null)
                {
                    context.OrderSet.Remove(order);
                    //foreach(OrderDetail ordD in orderDetails)
                    //{
                    //    context.OrderDetailSet.Remove(ordD);
                    //}
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("order not found");
                }
            }
        }

        public bool DeleteDetail(int orderNum, string detailName)
        {
            using (var context = new OrdersContainer())
            {
                var details = context.OrderDetailSet.FirstOrDefault(od=>od.OrderNumber == orderNum && od.TradeName == detailName.Trim());
                if (details != null)
                {
                    Order modOdr = context.OrderSet.FirstOrDefault(odr => odr.OrderNumber == details.OrderNumber);
                    modOdr.OrderDetails.Remove(details);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ArgumentException("要删除的订单明细不存在");
                }
            }
        }

        //修改订单，当提供的订单不正常或者要修改的订单号不存在的时候抛出异常
        public bool Modify(int orderNum, object order)
        {
            Order newOrder = order as Order;
            if (newOrder == null)
                throw new Exception("请提供有效订单");

            using (var context = new OrdersContainer())
            {
                var find = context.OrderSet.FirstOrDefault(p => p.OrderNumber == orderNum);
                if(find != null)
                {
                    var match = context.OrderSet.Where(odr => odr.OrderNumber == newOrder.OrderNumber);
                    List<Order> matches = match.ToList();
                    if (matches != null && matches.Count > 0)
                        throw new ArgumentException("修改信息不合法");
                    find = newOrder;
                    context.SaveChanges();
                }
                return true;
            }
        }

        public void ModifyDetails(int orderNumber,string TradeName ,object newOrdD)
        {
            OrderDetail newOrderD = newOrdD as OrderDetail;
            if (newOrdD == null)
                throw new Exception("请提供有效订单明细");

            using (var context = new OrdersContainer())
            {
                var find = context.OrderSet.FirstOrDefault(odr=>odr.OrderNumber == orderNumber);
                if (find != null)
                {
                    OrderDetail target = find.OrderDetails.FirstOrDefault(obj=>obj.TradeName == TradeName.Trim());
                    if (target != null)
                        target = newOrderD;
                    else
                        throw new ArgumentException("要修改的订单明细不存在");
                    context.SaveChanges();
                }
                else
                    throw new ArgumentException("请输入有效订单号");
            }
        }

        public List<Order> QueryAll()
        {
            List<Order> ans = new List<Order>();
            using (var context = new OrdersContainer())
            {
                foreach(Order o in context.OrderSet)
                {
                    ans.Add(o);
                }
            }
            return ans;
        }

        public List<Order> QueryOrder(Func<Order, bool> filter)
        {
            using (var context = new OrdersContainer())
            {
                var query = context.OrderSet.Where(filter);
                return query.ToList();
            }    
        }

        public List<OrderDetail> QueryAllDetail(int orderNum)
        {
            List<OrderDetail> ans = new List<OrderDetail>();
            using (var context = new OrdersContainer())
            {
                var list = context.OrderDetailSet.Where(p => p.OrderNumber == orderNum);
                ans = list.ToList();
                if (ans == null)
                    throw new ArgumentException("无效订单号");

                //foreach(OrderDetail obj in list)
                //{
                //    ans.Add(obj);
                //}
            }
            return ans;
        }

        public Order FindOrder(int orderNum)
        {
            using (var context = new OrdersContainer())
            {
                var query = context.OrderSet.FirstOrDefault(p=>p.OrderNumber == orderNum);
                if (query == null)
                    throw new ArgumentException("订单不存在");
                return query;
            }
        }

        //将存储的数据写入xml文件中存储
        public void Export(string targetAddress)
        {
            List<Order> orderList = new List<Order>();
            using (var context = new OrdersContainer())
            {
                foreach(Order o in context.OrderSet)
                {
                    orderList.Add(o);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(targetAddress, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    serializer.Serialize(fs, orderList);
                }
            }
        }

        //将xml文件数据读入系统
        public void Import(string targetAddress)
        {
            List<Order> orderList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(targetAddress, FileMode.Open, FileAccess.Read))
            {
                orderList = (List<Order>)serializer.Deserialize(fs);
                foreach(Order o in orderList)
                {
                    this.Add(o);
                }
            }
        }

        //public override bool Equals(object obj)
        //{
        //    OrderService tmp = obj as OrderService;
        //    if (tmp == null)
        //        return false;
        //    return this.orderList.Equals(tmp.orderList);
        //}

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}