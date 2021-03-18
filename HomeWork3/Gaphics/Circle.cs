using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics
{
    public class Circle: Delineation
    {
        private double radius;

        public double Radius
        {
            get => radius;
            set => radius = value;
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        //通过半径是否大于0判断是否合法
        public bool IsLegal
        {
            get => this.radius >= 0;
        }

        //圆形面积
        public double? GetArea
        {
            get 
            {
                if (this.IsLegal)
                    return Math.PI * radius * radius;
                else
                    return null;
            }
        }
    }
}
