using System;
using Graphics;

namespace GraphicsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Delineation tmp;
            Random rdm = new Random();
            double totalArea = 0;

            //随机创建10个图形对象
            for (int i = 1; i <= 10; i++) 
            {
                int type = rdm.Next(0, 3);

                try
                { 
                    //矩形对象
                    if (type == 0)
                    {
                        tmp = (Rectangle)Factory.GetProduct("Rectangle", i, i + 1);
                        if (((Rectangle)tmp).GetArea != null)
                            totalArea += ((Rectangle)tmp).GetArea.Value;
                    }
                    //三角形对象
                    if (type == 1)
                    {
                        tmp = (Triangle)Factory.GetProduct("Triangle", i, 2 * i, 3 * i - 1);
                        if (((Triangle)tmp).GetArea != null)
                            totalArea += ((Triangle)tmp).GetArea.Value;
                    }
                    //正方形对象
                    if (type == 2)
                    {
                        tmp = (Square)Factory.GetProduct("Square", i);
                        if (((Square)tmp).GetArea != null)
                            totalArea += ((Square)tmp).GetArea.Value;
                    }
                    //圆
                    if(type == 3)
                    {
                        tmp = (Circle)Factory.GetProduct("Circle", i);
                        if (((Circle)tmp).GetArea != null)
                            totalArea += ((Circle)tmp).GetArea.Value;
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
