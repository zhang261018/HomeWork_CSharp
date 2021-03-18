using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics
{
    //矩形
    public class Rectangle: Delineation
    {
        //提供长与宽
        private double length;
        private double width;

        public Rectangle(double length = 1, double width = 1)
        {
            this.length = length;
            this.width = width;     
        }

        public double Length
        {
            get => this.length;
            set => this.length = value;
        }
        public double Width
        {
            get => this.width;
            set => this.width = value;
        }

        //当长与宽均为正数判定合法（默认夹角为90度）
        public bool IsLegal
        {
            get => (length > 0) && (width > 0);
        }

        //根据参数是否合法返回面积或者null
        public double? GetArea
        {
            get
            {
                if (this.IsLegal)
                    return length * width;
                else
                    return null;
            }
        }
    }
}
