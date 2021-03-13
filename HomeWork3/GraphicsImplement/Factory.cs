using System;
using System.Collections.Generic;
using System.Text;
using Graphics;

namespace GraphicsFactory
{
    class Factory
    {
        public static object GetProduct(String graphics, double length1 = 1, double length2 = 1, double length3 = 1)
        {
            //根据传入的类型返回不同的图形
            switch(graphics.ToLower())
            {
                case "square":return new Square(length1);
                case "rectangle":return new Rectangle(length1, length2);
                case "triangle":return new Triangle(new double[3] { length1, length2, length3 });
                default:return null;
            }
        }
    }
}
