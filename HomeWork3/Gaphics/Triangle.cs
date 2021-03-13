using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics
{
    //三角形类
    public class Triangle: Delineation
    {
        private double[] length;
        public Triangle(double[] length)
        {
            this.length = length;
        }

        public double[] Length
        {
            get => length;
        }

        //public double this[int index] { get => length[index]; set => length[index] = value; }


        //根据三角形两边长大于第三遍判断是否合法
        public bool IsLegal
        {
            get {
                int max = (length[0] > length[1]) ? 0 : 1;
                max = (length[max] > length[2]) ? max : 2;
                return (length[0] + length[1] + length[2] - 2 * length[max]) > 0;
            }
        }

        //根据参数是否合法返回面积或者null
        public double? GetArea
        {
            get
            {
                double p = (length[0] + length[1] + length[2]) / 2;
                if (this.IsLegal)
                {
                    return Math.Sqrt(p * (p - length[0]) * (p - length[1]) * (p - length[2]));
                }
                else
                    return null;
            }
        }
    }
}
