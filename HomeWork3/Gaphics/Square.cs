using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics
{
    public class Square: Delineation
    {
        private double length;

        public Square(double length = 1)
        {
            this.length = length;
        }

        public double Length
        {
            get => length;
            set => length = value;
        }

        //根据参数是否合法返回面积或者null
        public double? GetArea
        {
            get
            {
                if (this.IsLegal)
                    return length * length;
                else
                    return null;
            }
        }

        //判断边长是否大于0（默认角度为90度）
        public bool IsLegal
        {
            get => length > 0;
        }
    }
}
