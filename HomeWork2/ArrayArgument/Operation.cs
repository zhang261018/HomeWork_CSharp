using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayArgument
{
    class Operation
    {
        public static (int, int, double, int) Operations(int[] nums)
        {
            double average = 0;
            int max = Int32.MinValue, min = Int32.MaxValue, sum = 0;

            //遍历数组求出最大值最小值以及总和
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= max) max = nums[i];
                if (nums[i] <= min) min = nums[i];
                sum += nums[i];
            }
            average = sum / nums.Length;

            //返回参数元组
            return (max, min, average, sum);
        }
    }
}
