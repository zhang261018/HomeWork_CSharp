using System;
using System.Collections.Generic;
using System.Text;
using Graphics;

namespace GraphicsFactory
{
    class Factory
    {
        public static object GetProduct(String graphics, params double[] length)
        {
            Delineation obj = null;
            try
            {
                //根据传入的类型返回不同的图形
                switch (graphics.ToLower())
                {
                    case "square":obj = new Square(length[0]); break;
                    case "rectangle":obj = new Rectangle(length[0], length[1]); break;
                    case "triangle":obj = new Triangle(new double[3] { length[0], length[1], length[2] }); break;
                    case "circle":obj = new Circle(length[0]); break;
                    default: break;
                }
                if(obj == null)
                {
                    throw new ArgumentException("type error!");
                }
                if(!obj.IsLegal)
                {
                    throw new ArgumentException("argument error!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return obj;
        }
    }
}
