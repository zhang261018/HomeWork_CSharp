using System;
using Graphics;

namespace GraphicsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            object tmp = 0;
            Random rdm = new Random();
            double totalArea = 0;

            //随机创建10个图形对象
            for (int i = 0; i < 10; i++) 
            {
                int type = rdm.Next(0, 2);

                try
                { 
                    //矩形对象
                    if (type == 0)
                    {
                        tmp = Factory.GetProduct("Rectangle", i, i + 1);
                        tmp = tmp as Rectangle;
                        if (((Rectangle)tmp).GetArea != null)
                            totalArea += ((Rectangle)tmp).GetArea.Value;
                    }
                    //三角形对象
                    if (type == 1)
                    {
                        tmp = Factory.GetProduct("Triangle", i, i + 1, i + 2);
                        tmp = tmp as Triangle;
                        if (((Triangle)tmp).GetArea != null)
                            totalArea += ((Triangle)tmp).GetArea.Value;
                    }
                    //正方形对象
                    if (type == 2)
                    {
                        tmp = Factory.GetProduct("Square", i);
                        tmp = tmp as Square;
                        if (((Square)tmp).GetArea != null)
                            totalArea += ((Square)tmp).GetArea.Value;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //输出结果
            Console.WriteLine("The total area is {0}.", totalArea);
        }
    }
}
