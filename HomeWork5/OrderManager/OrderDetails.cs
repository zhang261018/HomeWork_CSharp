﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class OrderDetails
    {
        private string tradeName;
        private string tradePrice;
        private int tradeAmount;

        public string TradeName { get => tradeName; set => tradeName = value; }
        public string TradePrice { get => tradePrice; set => tradeName = value; }
        public int TradeAmount { get => tradeAmount; set => tradeAmount = value; }
        //两个水长度的构造函数...
        public OrderDetails(string tradeName, string tradePrice, string tradeAmount)
        {
            this.tradeName = tradeName;
            this.tradePrice = tradePrice;
            this.tradeAmount = Convert.ToInt32(tradeAmount);
        }

        public OrderDetails(OrderDetails order)
        {
            this.tradeName = order.tradeName;
            this.tradePrice = order.tradePrice;
            this.tradeAmount = order.tradeAmount;
        }

        //ToString方法的重载
        public override string ToString()
        {
            return string.Format("{0,-16}{1,-8:C}{2,-8}",tradeName, tradePrice, tradeAmount);
        }

        //Equals方法的重载
        public override bool Equals(object obj)
        {
            OrderDetails newOrder = obj as OrderDetails;
            if (newOrder == null)
                return false;
            return (newOrder.tradeName == this.tradeName)
                && (newOrder.tradePrice == this.tradePrice)
                && (newOrder.tradeAmount == this.tradeAmount);
        }

        //GetHashCode方法的重载
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
