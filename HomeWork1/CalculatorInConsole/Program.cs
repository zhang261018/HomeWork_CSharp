using System;
using System.Threading;

namespace CalculatorInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool countine = true;
            string operators = "";
            double num1 = 0, num2 = 0, ans = 0;

            while (countine)
            {
                try
                {
                    //输入数据
                    Console.WriteLine("Please input a number:");
                    num1 = Double.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Please input another number:");
                    num2 = Double.Parse(Console.ReadLine().Trim());
                    Console.WriteLine("Please input the operator(+,-,*,/,%):");
                    operators = Console.ReadLine().Trim();

                    //根据输入运算符进行相应操作
                    switch (operators)
                    {
                        case "+": ans = num1 + num2; break;
                        case "-": ans = num1 - num2; break;
                        case "*": ans = num1 * num2; break;
                        //C#除0得到无穷，故此处不进行除零的异常处理
                        case "/": ans = num1 / num2; break;
                        case "%":
                            {
                                if (Math.Abs(num2) >= 1e-7)
                                    ans = num1 % num2;
                                else
                                    throw new DivideByZeroException("mod zero Exception.");
                            }
                            break;
                        default:
                            throw new FormatException("input a correct operator.");
                    }

                    Console.WriteLine($"The answer is {ans}");
                }
                //输入错误处理
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + "Please input a correct number or operator.");
                }
                //模零处理
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }

                //输入是否继续，单词输入错误默认继续
                try
                {
                    Console.WriteLine("do you want to countine? (true or false)");
                    countine = Boolean.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input a valid word please.");
                    countine = true;
                }


                //等待一段时间并清空控制台为下一次输入做准备
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
