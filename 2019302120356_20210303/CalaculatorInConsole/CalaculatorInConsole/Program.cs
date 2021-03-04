using System;

namespace CalaculatorInConsole
{
    //仅能处理含一个运算符的
    //仅支持加减乘除四种运算
    class Program
    {
        //判断是何种运算
        public static int JudgeOperate(string f)
        {
            if (f.Contains("+"))
                return 0;
            else if (f.Contains("-"))
                return 1;
            else if (f.Contains("*"))
                return 2;
            else if (f.Contains("/"))
                return 3;
            else
                return 4;
        }

        //计算表达式
        public static double Calculate(string f)
        {
            double num1 = 0, num2 = 0;
            int operate = JudgeOperate(f);
            string[] operators = { "+", "-", "*", "/" };
            num1 = Double.Parse(f.Split(operators[operate])[0].Trim());
            num2 = Double.Parse(f.Split(operators[operate])[1].Trim());

            //依次进行运算
            try
            {
                switch (operate)
                {
                    case 0:
                        return num1 + num2;
                    case 1:
                        return num1 - num2;
                    case 2:
                        return num1 * num2;
                    case 3:
                        return num1 / num2;
                    default:
                        {
                            Console.WriteLine("unsupportive!");
                            return 0;
                        }

                }
            }
            catch (DivideByZeroException e)
            {
                Console.Write("divide by zero!");
            }
            return Double.NaN;
        }

        //主函数
        static void Main(string[] args)
        {
            string formula = "";
            double answer = 0;

            Console.WriteLine("Please write your formula which has two number and a operator:");
            formula = Console.ReadLine();
            answer = Calculate(formula);
            Console.WriteLine($"the answer is {answer}");
        }
    }
}
